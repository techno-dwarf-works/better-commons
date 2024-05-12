using System;
using Better.Commons.Runtime.Extensions;
using UnityEngine;

namespace Better.Commons.Runtime.Conditions
{
    [Serializable]
    public abstract class SourceCondition<TSource> : Condition
    {
        [SerializeField] private TSource _source;

        protected TSource Source => _source;

        protected SourceCondition(TSource source)
        {
            if (typeof(TSource).IsNullable() && source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            _source = source;
        }

        protected override bool Validate(out Exception exception)
        {
            if (typeof(TSource).IsNullable() && Source == null)
            {
                exception = new NullReferenceException(nameof(_source));
                return false;
            }

            exception = null;
            return true;
        }
    }

    [Serializable]
    public abstract class SourceCondition<TSource, TState> : StateCondition<TState>
    {
        [SerializeField] private TSource _source;

        protected TSource Source => _source;

        protected SourceCondition(TSource source, TState state) : base(state)
        {
            if (typeof(TSource).IsNullable() && source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            _source = source;
        }

        protected override bool Validate(out Exception exception)
        {
            if (typeof(TSource).IsNullable() && Source == null)
            {
                exception = new NullReferenceException(nameof(_source));
                return false;
            }

            exception = null;
            return true;
        }
    }
}