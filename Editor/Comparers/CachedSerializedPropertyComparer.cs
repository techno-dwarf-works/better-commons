using System.Collections.Generic;
using Better.Commons.EditorAddons.Drawers.Base;
using Better.Commons.Runtime.Comparers;

namespace Better.Commons.EditorAddons.Comparers
{
    public class CachedSerializedPropertyComparer : BaseComparer<CachedSerializedPropertyComparer, CachedSerializedProperty>,
        IEqualityComparer<CachedSerializedProperty>
    {
        public bool Equals(CachedSerializedProperty x, CachedSerializedProperty y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (ReferenceEquals(x, null)) return false;
            if (ReferenceEquals(y, null)) return false;
            if (x.GetType() != y.GetType()) return false;
            return x == y;
        }

        public int GetHashCode(CachedSerializedProperty obj)
        {
            return obj.GetHashCode();
        }
        
    }
}