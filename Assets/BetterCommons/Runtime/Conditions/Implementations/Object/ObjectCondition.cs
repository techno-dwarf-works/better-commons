using System;
using UnityObject = UnityEngine.Object;

namespace Better.Commons.Runtime.Conditions
{
    [Serializable]
    public abstract class ObjectCondition<TSource, TState> : SourceCondition<TSource, TState>
        where TSource : UnityObject
    {
        public ObjectCondition(TSource source, TState state) : base(source, state)
        {
        }
    }

    [Serializable]
    public abstract class ObjectCondition<TState> : ObjectCondition<UnityObject, TState>
    {
        protected ObjectCondition(UnityObject source, TState state) : base(source, state)
        {
        }
    }
}