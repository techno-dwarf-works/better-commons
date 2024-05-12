using System;
using System.Collections.Generic;
using UnityEngine;

namespace Better.Commons.Runtime.Conditions
{
    [Serializable]
    public abstract class ComplexCondition : Condition
    {
        [SerializeField] private ConditionIterator _iterator;
        protected ConditionIterator Iterator => _iterator;

        protected ComplexCondition(bool safe, bool logException)
        {
            _iterator = new ConditionIterator(safe, logException);
        }

        public ComplexCondition(IEnumerable<Condition> conditions, bool safe = default, bool logException = DefaultLogException)
            : this(safe, logException)
        {
            if (conditions == null)
            {
                throw new ArgumentNullException(nameof(conditions));
            }

            _iterator.Add(conditions);
        }

        protected ComplexCondition() : this(false, DefaultLogException)
        {
        }

        public override void Rebuild()
        {
            base.Rebuild();

            Iterator.Rebuild();
        }

        protected override bool Validate(out Exception exception)
        {
            if (Iterator == null)
            {
                var message = $"{nameof(Iterator)} cannot be null";
                exception = new InvalidOperationException(message);
                return false;
            }

            exception = null;
            return true;
        }
    }
}