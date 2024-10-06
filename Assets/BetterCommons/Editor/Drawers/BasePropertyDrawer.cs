using System;
using System.Reflection;
using Better.Commons.EditorAddons.Drawers.Base;
using Better.Commons.EditorAddons.Drawers.Container;
using Better.Commons.EditorAddons.Drawers.Handlers;
using Better.Commons.EditorAddons.Utility;
using Better.Commons.Runtime.Drawers.Attributes;
using Better.Commons.Runtime.Extensions;
using Better.Commons.Runtime.Utility;
using UnityEditor;
using UnityEngine.UIElements;

namespace Better.Commons.EditorAddons.Drawers
{
    public abstract class BasePropertyDrawer<THandler, TAttribute> : PropertyDrawer where THandler : SerializedPropertyHandler where TAttribute : MultiPropertyAttribute
    {
        protected FieldInfo FieldInfo { get; private set; }
        protected TAttribute Attribute { get; private set; }

        protected HandlerCollection<THandler> Handlers { get; private set; }
        protected ElementsContainer Container { get; private set; }
        protected TypeHandlerBinder<THandler> TypeHandlersBinder { get; private set; }

        protected BasePropertyDrawer()
        {
            EditorApplication.update += ScheduleSubscribe;
        }

        private void ScheduleSubscribe()
        {
            EditorApplication.update -= ScheduleSubscribe;
            Selection.selectionChanged += OnSelectionChanged;
        }

        ~BasePropertyDrawer()
        {
            EditorApplication.update += DeconstructOnMainThread;
        }

        protected THandler GetHandler(SerializedProperty property)
        {
            if (Handlers == null)
            {
                DebugUtility.LogException<ArgumentNullException>(nameof(Handlers));
                return null;
            }

            if (property == null)
            {
                DebugUtility.LogException<ArgumentNullException>(nameof(property));
                return null;
            }

            var attributeType = Attribute.GetType();
            var fieldType = GetFieldOrElementType();

            var cached = new CachedSerializedProperty(property);
            Handlers.Revalidate();
            
            if (Handlers.TryGetValue(cached, out var value))
            {
                return value.Handler;
            }

            var handler = TypeHandlersBinder.GetHandler(fieldType, attributeType);
            if (handler == null)
            {
                return null;
            }

            var collectionValue = new CollectionValue<THandler>(handler, fieldType);
            Handlers.Add(cached, collectionValue);

            return handler;
        }

        public sealed override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            if (Container != null)
            {
                ContainerReleased(Container);
                Container = null;
            }
            
            Container = new ElementsContainer(property);
            FieldInfo = fieldInfo;
            Attribute = (TAttribute)attribute;
            Handlers = new HandlerCollection<THandler>();
            TypeHandlersBinder = HandlerBinderRegistry.GetMap<THandler>();

            PopulateContainer(Container);
            Container.Use();
            
            var subState = StyleDefinition.CombineSubState(typeof(TAttribute).Name, GetType().Name);
            Container.RootElement.AddToClassList(subState);
            return Container.RootElement;
        }

        protected abstract void PopulateContainer(ElementsContainer container);

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

        protected virtual Type GetFieldOrElementType()
        {
            var fieldType = FieldInfo.FieldType;
            if (fieldType.IsArrayOrList())
                return fieldType.GetCollectionElementType();

            return fieldType;
        }

        private void Deconstruct()
        {
            Handlers?.Deconstruct();
            ContainerReleased(Container);
        }
        
        protected virtual void ContainerReleased(ElementsContainer container)
        {
        }
    }
}