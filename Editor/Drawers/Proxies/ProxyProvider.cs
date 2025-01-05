using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Better.Commons.EditorAddons.Utility;
using Better.Commons.Runtime.Extensions;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;
using Object = UnityEngine.Object;

namespace Better.Commons.EditorAddons.Drawers.Proxies
{
    public static class ProxyProvider
    {
        private const string ObjectFieldDisplayClassName = "unity-object-field-display";
        
        //TODO: Allow users add theirs factories with priorities
        private static List<ProxyViewFactory> _factories;

        static ProxyProvider()
        {
            _factories = new List<ProxyViewFactory>();

            _factories.Add(SupportDirectType<int>, ConfigureIntegerDrawer);

            _factories.Add(SupportDirectType<long>, ConfigureField<LongField, long>);

            _factories.Add(SupportDirectType<bool>, ConfigureField<Toggle, bool>);

            _factories.Add(SupportDirectType<float>, ConfigureField<FloatField, float>);

            _factories.Add(SupportDirectType<double>, ConfigureField<DoubleField, double>);

            _factories.Add(SupportDirectType<string>, ConfigureStringDrawer);

            _factories.Add(SupportDirectType<char>, ConfigureCharDrawer);

            _factories.Add(type => SupportDirectType<Color>(type) || SupportDirectType<Color32>(type), ConfigureField<ColorField, Color>);

            _factories.Add(SupportDirectType<LayerMask>, ConfigureField<LayerMaskField, int>);

            _factories.Add(type => type.IsSubclassOf<Enum>(), ConfigureEnumDrawer);

            _factories.Add(SupportDirectType<Vector2>, ConfigureField<Vector2Field, Vector2>);

            _factories.Add(SupportDirectType<Vector3>, ConfigureField<Vector3Field, Vector3>);

            _factories.Add(SupportDirectType<Vector4>, ConfigureField<Vector4Field, Vector4>);

            _factories.Add(SupportDirectType<Rect>, ConfigureField<RectField, Rect>);

            _factories.Add(SupportDirectType<AnimationCurve>, ConfigureField<CurveField, AnimationCurve>);

            _factories.Add(SupportDirectType<Bounds>, ConfigureField<BoundsField, Bounds>);

            _factories.Add(SupportDirectType<Gradient>, ConfigureField<GradientField, Gradient>);

            _factories.Add(SupportDirectType<Vector2Int>, ConfigureField<Vector2IntField, Vector2Int>);

            _factories.Add(SupportDirectType<Vector3Int>, ConfigureField<Vector3IntField, Vector3Int>);

            _factories.Add(SupportDirectType<RectInt>, ConfigureField<RectIntField, RectInt>);

            _factories.Add(SupportDirectType<BoundsInt>, ConfigureField<BoundsIntField, BoundsInt>);

            _factories.Add(SupportDirectType<Hash128>, ConfigureField<Hash128Field, Hash128>);

            _factories.Add(SupportUnityObject, ConfigureObjectDrawer);

            _factories.Add(SupportSerializableType, ConfigureSerializableDrawer);
        }

        private static bool SupportUnityObject(Type type)
        {
            return type.IsSubclassOf<Object>();
        }

        private static bool SupportDirectType<T>(Type type)
        {
            return type == typeof(T);
        }

        private static bool SupportSerializableType(Type type)
        {
            return type.IsSerializable;
        }

        private static VisualElement ConfigureSerializableDrawer(InfoProxy proxy)
        {
            var fieldInfos = proxy.Type.GetMembersRecursive()
                .OfType<FieldInfo>()
                .Where(fieldInfo => fieldInfo.IsDefined(typeof(SerializeField)) || fieldInfo.IsPublic || fieldInfo.IsFamily);

            var foldout = new Foldout();
            foldout.text = proxy.Name;
            foldout.style.FlexGrow(StyleDefinition.OneStyleFloat)
                .PaddingLeft(StyleDefinition.IndentLevelPadding)
                .AlignSelf(Align.Stretch);

            var fields = fieldInfos.Select(field =>
            {
                var instance = proxy.GetData();
                return new FieldProxy(field, instance);
            });

            var vertical = VisualElementUtility.CreateVerticalGroup();
            foldout.contentContainer.Add(vertical);

            //TODO: Add callback on data changed
            foreach (var field in fields)
            {
                var element = CreateDrawer(field);
                vertical.Add(element);
            }

            return foldout;
        }

        private static VisualElement ConfigureEnumDrawer(InfoProxy proxy)
        {
            var enumType = proxy.Type;
            var enumValues = enumType.GetEnumValues().Cast<object>().ToList();
            var enumDisplayNames = enumValues.Select(enumValue => ObjectNames.NicifyVariableName(enumValue.ToString())).ToList();
            var enumValueIndex = enumValues.IndexOf(proxy.GetData());
            if (enumType.IsDefined(typeof(FlagsAttribute), false))
            {
                var enumField = ConfigureField<EnumFlagsField, Enum>(proxy);
                enumField.choices = enumDisplayNames;
                enumField.value = (Enum)Enum.ToObject(enumType, enumValueIndex);
                return enumField;
            }

            var propertyFieldIndex = enumValueIndex < 0 || enumValueIndex >= enumDisplayNames.Count ? -1 : enumValueIndex;

            var popupField = ConfigureField<PopupField<string>, string>(proxy);

            popupField.choices = enumDisplayNames;
            popupField.index = propertyFieldIndex;

            return popupField;
        }

        private static VisualElement ConfigureStringDrawer(InfoProxy proxy)
        {
            var textField = ConfigureField<TextField, string>(proxy);
            textField.maxLength = -1;
            return textField;
        }

        private static VisualElement ConfigureCharDrawer(InfoProxy proxy)
        {
            var textField = ConfigureField<TextField, string>(proxy);
            textField.maxLength = 1;
            return textField;
        }

        private static VisualElement ConfigureObjectDrawer(InfoProxy proxy)
        {
            var objectField = ConfigureField<ObjectField, Object>(proxy);
            objectField.objectType = proxy.Type;
            objectField.allowSceneObjects = true;

            var visualElement = objectField.Q<VisualElement>(ObjectFieldDisplayClassName);
            visualElement?.style.Width(StyleDefinition.OneStyleLength);

            return objectField;
        }

        private static VisualElement ConfigureIntegerDrawer(InfoProxy proxy)
        {
            var integerField = ConfigureField<IntegerField, int>(proxy);
            integerField.isDelayed = false;
            return integerField;
        }

        private static TField ConfigureField<TField, TValue>(InfoProxy proxy)
            where TField : BaseField<TValue>, new()
        {
            var field = new TField();
            field.RegisterValueChangedCallback(evt =>
            {
                proxy.SetData(evt.newValue);
                proxy.SetDirty();
            });
            
            field.value = (TValue)proxy.GetData();
            field.label = ObjectNames.NicifyVariableName(proxy.Name);
            field.style.FlexGrow(StyleDefinition.OneStyleFloat);
            field.labelElement.style.MinWidth(StyleKeyword.Auto);
            return field;
        }

        public static bool IsSupported(Type type)
        {
            foreach (var factory in _factories)
            {
                if (factory.SupportedFunc.Invoke(type))
                {
                    return true;
                }
            }

            return false;
        }

        public static VisualElement CreateDrawer(InfoProxy proxy)
        {
            foreach (var factory in _factories)
            {
                if (factory.SupportedFunc.Invoke(proxy.Type))
                {
                    return factory.CreateFunc.Invoke(proxy);
                }
            }

            return null;
        }
    }
}