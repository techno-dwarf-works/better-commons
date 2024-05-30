using System;
using System.Reflection;
using Better.Commons.EditorAddons.Drawers.Base;
using Better.Commons.EditorAddons.Drawers.Caching;
using Better.Commons.EditorAddons.Drawers.Utility;
using Better.Commons.Runtime.Drawers.Attributes;
using Better.Commons.Runtime.Extensions;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace Better.Commons.EditorAddons.Drawers
{
    public abstract class BasePropertyDrawer<T> : PropertyDrawer where T : SerializedPropertyHandler
    {
        protected FieldInfo _fieldInfo => fieldInfo;
        protected MultiPropertyAttribute _attribute => (MultiPropertyAttribute)attribute;
        private static readonly CacheValue CacheValueField = new CacheValue();
    
        protected HandlerCollection<T> _handlers;
        
        protected class CacheValue : CacheValue<CollectionValue<T>>
        {
        }
    
        protected BasePropertyDrawer()
        {
            Selection.selectionChanged += OnSelectionChanged;
        }
    
        ~BasePropertyDrawer()
        {
            EditorApplication.update += DeconstructOnMainThread;
        }
    
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            var container = new ElementsContainer(property);
            var propertyField = new PropertyField(property);
            propertyField.style.FlexGrow(new StyleFloat(1));
            var defaultElement = container.CreateElementFrom(propertyField);
            defaultElement.AddTag(typeof(PropertyDrawer));
            defaultElement.AddTag(property);
    
            _handlers = GenerateCollection();
            PopulateContainer(container);
    
            return container.Generate();
        }
        
        /// <summary>
        /// Method generates explicit typed collection inherited from <see cref="HandlerCollection{T}"/> 
        /// </summary>
        /// <returns></returns>
        protected abstract HandlerCollection<T> GenerateCollection();
    
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
            var fieldType = _fieldInfo.FieldType;
            if (fieldType.IsArrayOrList())
                return fieldType.GetCollectionElementType();
    
            return fieldType;
        }
        
        /// <summary>
        /// Validates if <see cref="_handlers"/> contains property by <see cref="SerializedPropertyComparer"/>
        /// </summary>
        /// <param name="property">SerializedProperty what will be stored into <see cref="_handlers"/></param>
        /// <param name="handler"><see cref="HandlerMap{THandler}"/> used to validate current stored wrappers and gets instance for recently added property</param>
        /// <typeparam name="THandler"></typeparam>
        /// <returns>Returns true if wrapper for <paramref name="property"/> was already stored into <see cref="_handlers"/></returns>
        protected CacheValue ValidateCachedProperties<THandler>(SerializedProperty property, HandlerMap<THandler> handler)
            where THandler : HandlerMap<THandler>, new()
        {
            ValidateCachedPropertiesUtility.Validate(_handlers, CacheValueField, property, GetFieldOrElementType(), _attribute.GetType(), handler);
            return CacheValueField;
        }
    
        protected virtual void Deconstruct()
        {
            _handlers?.Deconstruct();
        }
    }
}