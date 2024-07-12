using System;
using System.Collections.Generic;
using Better.Commons.EditorAddons.Drawers.Base;
using Better.Commons.EditorAddons.Drawers.Handlers;
using Better.Commons.EditorAddons.Extensions;
using Better.Commons.Runtime.Utility;
using UnityEditor;

namespace Better.Commons.EditorAddons.Utility
{
    public static class ValidationUtility
    {
        public static void ValidateCachedProperties<THandler>(HandlerCollection<THandler> collection) where THandler : SerializedPropertyHandler
        {
            ValidateCachedProperties(collection, DefaultValidationFunc);
        }

        /// <summary>
        /// Validates stored properties if their <see cref="CollectionValue{T}.Type"/> supported
        /// </summary>
        /// <param name="collection"></param>
        /// <param name="validationFunc"></param>
        public static void ValidateCachedProperties<THandler>(HandlerCollection<THandler> collection, Func<SerializedProperty, CollectionValue<THandler>, bool> validationFunc)
            where THandler : SerializedPropertyHandler
        {
            if (validationFunc == null)
            {
                DebugUtility.LogException<ArgumentNullException>(nameof(validationFunc));
                return;
            }

            List<SerializedProperty> keysToRemove = null;
            foreach (var value in collection)
            {
                if (validationFunc.Invoke(value.Key, value.Value)) continue;
                if (keysToRemove == null)
                {
                    keysToRemove = new List<SerializedProperty>();
                }

                keysToRemove.Add(value.Key);
            }

            if (keysToRemove != null)
            {
                foreach (var serializedProperty in keysToRemove)
                {
                    collection.Remove(serializedProperty);
                }
            }
        }
        
        private static bool DefaultValidationFunc<THandler>(SerializedProperty serializedProperty, CollectionValue<THandler> collectionValue) where THandler : SerializedPropertyHandler
        {
            return serializedProperty.Verify() && !serializedProperty.IsDisposed();
        }
    }
}