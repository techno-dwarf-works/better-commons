using System;
using Better.Commons.EditorAddons.Drawers.Handlers;

namespace Better.Commons.EditorAddons.Drawers.Base
{
    public class CollectionValue<T> where T : SerializedPropertyHandler
    {
        public CollectionValue(T handler, Type type)
        {
            Handler = handler;
            Type = type;
        }

        public T Handler { get; }
        public Type Type { get; }
    }
}