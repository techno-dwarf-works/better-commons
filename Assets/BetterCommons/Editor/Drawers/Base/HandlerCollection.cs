using System.Collections.Generic;
using Better.Commons.EditorAddons.Comparers;
using Better.Commons.EditorAddons.Drawers.Handlers;
using UnityEditor;

namespace Better.Commons.EditorAddons.Drawers.Base
{
    public class HandlerCollection<T> : Dictionary<CachedSerializedProperty, CollectionValue<T>> where T : SerializedPropertyHandler
    {
        public HandlerCollection() : base(CachedSerializedPropertyComparer.Instance)
        {
        }

        /// <summary>
        /// ContainerReleased method for stored wrappers
        /// </summary>
        public void Deconstruct()
        {
            foreach (var value in Values)
            {
                value.Handler.Deconstruct();
            }
        }

        public void Revalidate()
        {
            var listToRemove = new List<CachedSerializedProperty>();
            foreach (var property in Keys)
            {
                if (!property.IsValid())
                {
                    listToRemove.Add(property);
                }
            }

            foreach (var property in listToRemove)
            {
                Remove(property);
            }
        }
    }
}