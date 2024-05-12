using System;
using Better.Commons.Runtime.Extensions;
using UnityEngine;

namespace Better.Commons.Runtime.Conditions
{
    [Serializable]
    public abstract class StateCondition<TValue> : Condition
    {
        [SerializeField] private TValue _targetState;

        protected TValue TargetState => _targetState;

        protected StateCondition(TValue targetState)
        {
            if (typeof(TValue).IsNullable() && targetState == null)
            {
                throw new ArgumentNullException(nameof(targetState));
            }

            _targetState = targetState;
        }

        protected override bool Validate(out Exception exception)
        {
            if (typeof(TValue).IsNullable() && TargetState == null)
            {
                exception = new NullReferenceException(nameof(_targetState));
                return false;
            }

            exception = null;
            return true;
        }
    }
}