using System;
using System.Collections.Generic;
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
    public abstract class PropertyDrawer<THandler> : PropertyDrawer where THandler : SerializedPropertyHandler
    {
        protected FieldInfo FieldInfo { get; private set; }
        protected HandlerCollection<THandler> Handlers { get; private set; }
        protected ElementsContainer Container { get; private set; }
        protected TypeHandlerBinder<THandler> TypeHandlersBinder { get; private set; }

        protected PropertyDrawer()
        {
            EditorApplication.update += ScheduleSubscribe;
        }

        private void ScheduleSubscribe()
        {
            EditorApplication.update -= ScheduleSubscribe;
            Selection.selectionChanged += OnSelectionChanged;
        }

        ~PropertyDrawer()
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

            var fieldType = GetFieldOrElementType();

            var cached = new CachedSerializedProperty(property);
            Handlers.Revalidate();

            if (Handlers.TryGetValue(cached, out var value))
            {
                return value.Handler;
            }

            var filter = GetFilter();
            if (TypeHandlersBinder.TryFindByFilter(filter, out var handler))
            {
                var collectionValue = new CollectionValue<THandler>(handler, fieldType);
                Handlers.Add(cached, collectionValue);

                return handler;
            }

            DebugUtility.LogException<KeyNotFoundException>(nameof(handler));
            return null;
        }

        protected virtual HandlersFilter GetFilter()
        {
            var fieldType = GetFieldOrElementType();
            var filter = new FieldHandlersFilter(fieldType);
            return filter;
        }

        public sealed override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            if (Container == null)
            {
                OnInitialized();
            }

            if (Container != null)
            {
                ContainerReleased(Container);
                Container = null;
            }

            Container = new ElementsContainer(property);
            FieldInfo = fieldInfo;
            Handlers = new HandlerCollection<THandler>();
            TypeHandlersBinder = BindingRegistry.GetBinder<THandler>();

            PopulateContainer(Container);
            Container.Use();

            var subState = GetContainerClassName();
            Container.RootElement.AddToClassList(subState);
            return Container.RootElement;
        }

        protected virtual void OnInitialized()
        {
        }

        protected virtual string GetContainerClassName()
        {
            return StyleDefinition.CombineSubState(typeof(THandler).Name, GetType().Name);
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

    public abstract class PropertyDrawer<THandler, TAttribute> : PropertyDrawer<THandler> where THandler : SerializedPropertyHandler where TAttribute : MultiPropertyAttribute
    {
        protected TAttribute Attribute { get; private set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            Attribute = (TAttribute)attribute;
        }

        protected override HandlersFilter GetFilter()
        {
            var fieldType = GetFieldOrElementType();
            var attributeType = Attribute.GetType();
            var filter = new AttributeHandlersFilter(fieldType, attributeType);
            return filter;
        }

        protected override string GetContainerClassName()
        {
            var baseName = base.GetContainerClassName();
            return StyleDefinition.CombineSubState(typeof(TAttribute).Name, baseName);
        }
    }
}