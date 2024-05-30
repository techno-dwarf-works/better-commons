using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Better.Commons.EditorAddons.Drawers.Attributes;
using Better.Commons.EditorAddons.Drawers.Base;
using Better.Commons.Runtime.Comparers;
using Better.Commons.Runtime.Drawers.Attributes;
using Better.Commons.Runtime.Extensions;
using Better.Internal.Core.Runtime;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace Better.Commons.EditorAddons.Drawers
{
    // [CustomPropertyDrawer(typeof(MultiPropertyAttribute), true)]
    public sealed class MultiPropertyDrawer : PropertyDrawer
    {
        private static Dictionary<Type, Type> _fieldDrawers = new Dictionary<Type, Type>(AssignableFromComparer.Instance);

        private static Dictionary<MultiPropertyDrawer, string> _propertyDrawers =
            new Dictionary<MultiPropertyDrawer, string>();

        private bool _initialized;
        private List<FieldDrawer> _drawers;

        public MultiPropertyDrawer()
        {
            _drawers = new List<FieldDrawer>();
        }

        [InitializeOnLoadMethod]
        [DidReloadScripts]
        private static void OnInitialize()
        {
            _propertyDrawers.Clear();
            var types = typeof(FieldDrawer).GetAllInheritedTypesWithoutUnityObject();
            foreach (var type in types)
            {
                var atts = type.GetCustomAttributes<MultiCustomPropertyDrawer>();
                foreach (var att in atts)
                {
                    if (att == null) continue;
                    if (!_fieldDrawers.TryAdd(att.ForAttribute, type))
                    {
                        if (att.Override)
                        {
                            _fieldDrawers[att.ForAttribute] = type;
                        }
                    }
                }
            }
        }

        ~MultiPropertyDrawer()
        {
            EditorApplication.update += DeconstructOnMainThread;
        }


        private void DeconstructOnMainThread()
        {
            EditorApplication.update -= DeconstructOnMainThread;
            Selection.selectionChanged -= OnSelectionChanged;
            Deconstruct();
        }

        private void OnSelectionChanged()
        {
            Selection.selectionChanged -= OnSelectionChanged;
            Deconstruct();
        }

        private void Deconstruct()
        {
            _propertyDrawers.Remove(this);
            foreach (var fieldDrawer in _drawers)
            {
                fieldDrawer.Deconstruct();
            }
        }

        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            Selection.selectionChanged += OnSelectionChanged;
            if (_propertyDrawers.ContainsValue(property.propertyPath))
            {
                var visualElement = new VisualElement();
                visualElement.visible = false;
                return visualElement;
            }

            TryInitialize();
            _propertyDrawers.Add(this, property.propertyPath);
            VisualElement propertyField = new PropertyField(property);
            if (_drawers.Count > 0)
            {
                var container = new ElementsContainer(property);
                var defaultElement = container.CreateElementFrom(propertyField);
                propertyField.style.FlexGrow(new StyleFloat(1));
                defaultElement.AddTag(typeof(PropertyDrawer));
                defaultElement.AddTag(property);

                foreach (var fieldDrawer in _drawers)
                {
                    fieldDrawer.PopulateContainer(container);
                }

                propertyField = container.Generate();
            }

            return propertyField;
        }

        private IOrderedEnumerable<MultiPropertyAttribute> GetAttributes(FieldInfo field)
        {
            return field.GetCustomAttributes<MultiPropertyAttribute>().OrderBy(att => att.order);
        }

        private void TryInitialize()
        {
            if (_initialized) return;

            _initialized = true;
            var attributes = GetAttributes(fieldInfo);
            var param = new object[] { fieldInfo, null };
            foreach (var propertyAttribute in attributes)
            {
                if (!_fieldDrawers.TryGetValue(propertyAttribute.GetType(), out var drawerType)) continue;

                param[1] = propertyAttribute;
                var drawer = (FieldDrawer)Activator.CreateInstance(drawerType, Defines.ConstructorFlags, null, param, null);
                drawer.Initialize();
                _drawers.Add(drawer);
            }
        }
    }
}