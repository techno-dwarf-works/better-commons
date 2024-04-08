using System.Collections.Generic;
using Better.Commons.EditorAddons.Comparers;
using Better.Commons.EditorAddons.Drawers.Utilities;
using UnityEditor;

namespace Better.Commons.EditorAddons.Drawers.Base
{
    public class WrapperCollection<T> : Dictionary<SerializedProperty, WrapperCollectionValue<T>>
        where T : UtilityWrapper
    {
        public WrapperCollection() : base(SerializedPropertyComparer.Instance)
        {
        }

        /// <summary>
        /// Deconstruct method for stored wrappers
        /// </summary>
        public void Deconstruct()
        {
            foreach (var value in Values)
            {
                value.Wrapper.Deconstruct();
            }
        }
    }
}