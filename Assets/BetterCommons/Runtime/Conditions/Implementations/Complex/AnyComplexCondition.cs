using System;
using System.Collections.Generic;

namespace Better.Commons.Runtime.Conditions
{
    [Serializable]
    public class AnyComplexCondition : ComplexCondition
    {
        public AnyComplexCondition(IEnumerable<Condition> conditions, bool safe = default, bool logException = DefaultLogException)
            : base(conditions, safe, logException)
        {
        }

        protected AnyComplexCondition()
        {
        }

        public override bool Invoke()
        {
            return Iterator.IterateAny();
        }
    }
}