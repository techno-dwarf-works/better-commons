using System.Collections.Generic;

namespace Better.Commons.Runtime.Conditions
{
    public class AllComplexCondition : ComplexCondition
    {
        public AllComplexCondition(IEnumerable<Condition> conditions, bool safe = default, bool logException = DefaultLogException)
            : base(conditions, safe, logException)
        {
        }

        protected AllComplexCondition()
        {
        }

        public override bool Invoke()
        {
            return Iterator.IterateAll();
        }
    }
}