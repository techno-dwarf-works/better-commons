using System;
using System.Collections.Generic;
using Better.Commons.Runtime.Extensions;
using UnityEngine;

namespace Better.Commons.Runtime.Conditions
{
    [Serializable]
    public class EqualityStateCondition<TState> : StateCondition<TState>
    {
        [SerializeField] private TState _state;
        [SerializeReference] private IEqualityComparer<TState> _comparer;

        public TState State
        {
            get => _state;
            set => _state = value;
        }

        public EqualityStateCondition(IEqualityComparer<TState> comparer, TState targetState, TState state = default)
            : base(targetState)
        {
            if (comparer == null)
            {
                throw new ArgumentNullException(nameof(comparer));
            }

            _comparer = comparer;
            _state = state;
        }

        public EqualityStateCondition(TState targetValue, TState value = default)
            : this(EqualityComparer<TState>.Default, targetValue, value)
        {
        }

        protected EqualityStateCondition() : this(default)
        {
        }

        public override bool Invoke()
        {
            return _comparer.Equals(State, TargetState);
        }

        protected override bool Validate(out Exception exception)
        {
            if (_comparer == null)
            {
                exception = new NullReferenceException(nameof(_comparer));
                return false;
            }

            if (typeof(TState).IsNullable() && _state == null)
            {
                exception = new NullReferenceException(nameof(_state));
                return false;
            }

            exception = null;
            return true;
        }
    }
}