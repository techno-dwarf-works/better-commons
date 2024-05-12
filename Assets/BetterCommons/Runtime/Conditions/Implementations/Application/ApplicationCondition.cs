using System;

namespace Better.Commons.Runtime.Conditions
{
    [Serializable]
    public abstract class ApplicationCondition<TState> : StateCondition<TState>
    {
        protected ApplicationCondition(TState targetState) : base(targetState)
        {
        }
    }
}