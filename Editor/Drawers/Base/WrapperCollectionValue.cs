using System;
using Better.Commons.EditorAddons.Drawers.Utilities;

namespace Better.Commons.EditorAddons.Drawers.Base
{
    public class WrapperCollectionValue<T> where T : UtilityWrapper
    {
        public WrapperCollectionValue(T wrapper, Type type)
        {
            Wrapper = wrapper;
            Type = type;
        }

        public T Wrapper { get; }
        public Type Type { get; }
    }
}