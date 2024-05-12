using System;
using System.Collections.Generic;
using Better.Commons.Runtime.Extensions;
using UnityEngine;
using UnityEngine.Serialization;

namespace Better.Commons.Runtime.Conditions
{
    [Serializable]
    public class TriggerStateCondition<TState> : EqualityStateCondition<TState>
    {
        [SerializeField] private TState _defaultState;
        protected TState DefaultState => _defaultState;

        public TriggerStateCondition(IEqualityComparer<TState> comparer, TState targetState, TState defaultState = default)
            : base(comparer, targetState, defaultState)
        {
            _defaultState = defaultState;
        }

        public TriggerStateCondition(TState targetValue, TState defaultValue = default)
            : this(EqualityComparer<TState>.Default, targetValue, defaultValue)
        {
        }

        protected TriggerStateCondition() : this(EqualityComparer<TState>.Default, default)
        {
        }

        public override void Rebuild()
        {
            base.Rebuild();

            State = DefaultState;
        }
    }

    [Serializable]
    public class TriggerStateCondition : TriggerStateCondition<bool>
    {
        public TriggerStateCondition() : base(true)
        {
        }
    }
}