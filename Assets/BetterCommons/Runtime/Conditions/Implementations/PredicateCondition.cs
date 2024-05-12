using System;
using Better.Commons.Runtime.Extensions;

namespace Better.Commons.Runtime.Conditions
{
    public class PredicateCondition : Condition
    {
        private readonly Action _rebuildAction;
        private readonly Func<bool> _predicate;
        private readonly bool _safe;

        public PredicateCondition(Func<bool> predicate, bool safe = default)
        {
            if (predicate == null)
            {
                throw new ArgumentNullException(nameof(predicate));
            }

            _predicate = predicate;
            _safe = safe;
        }

        public PredicateCondition(Action rebuildAction, Func<bool> predicate, bool safe = default)
            : this(predicate, safe)
        {
            if (rebuildAction == null)
            {
                throw new ArgumentNullException(nameof(rebuildAction));
            }

            _rebuildAction = rebuildAction;
        }

        public override void Rebuild()
        {
            base.Rebuild();

            if (_rebuildAction != null)
            {
                if (_safe) _rebuildAction.SafeInvoke();
                else _rebuildAction.Invoke();
            }
        }

        public override bool Invoke()
        {
            if (_safe)
            {
                return _predicate.SafeInvoke();
            }

            return _predicate.Invoke();
        }

        protected override bool Validate(out Exception exception)
        {
            if (_predicate == null)
            {
                exception = new NullReferenceException(nameof(_predicate));
                return false;
            }

            exception = null;
            return true;
        }
    }
}