using System;
using System.Collections.Generic;
using System.Linq;
using Better.Commons.Runtime.Conditions;
using Better.Commons.Runtime.Utility;

namespace Better.Commons.Runtime.Extensions
{
    public static class ConditionExtensions
    {
        public static void Rebuild(this IEnumerable<Condition> self)
        {
            if (self == null)
            {
                DebugUtility.LogException<ArgumentNullException>(nameof(self));
                return;
            }

            foreach (var condition in self)
            {
                condition.Rebuild();
            }
        }

        public static bool Validate(this IEnumerable<Condition> self, bool logException = Condition.DefaultLogException)
        {
            if (self == null)
            {
                DebugUtility.LogException<ArgumentNullException>(nameof(self));
                return false;
            }

            foreach (var condition in self)
            {
                if (!condition.Validate(logException))
                {
                    return false;
                }
            }

            return true;
        }

        public static bool InvokeAll(this IEnumerable<Condition> self)
        {
            if (self == null)
            {
                DebugUtility.LogException<ArgumentNullException>(nameof(self));
                return false;
            }

            foreach (var condition in self)
            {
                if (!condition.Invoke())
                {
                    return false;
                }
            }

            return true;
        }

        public static bool SafeInvokeAll(this IEnumerable<Condition> self, bool logException = Condition.DefaultLogException)
        {
            if (self == null)
            {
                DebugUtility.LogException<ArgumentNullException>(nameof(self));
                return false;
            }

            foreach (var condition in self)
            {
                if (!condition.SafeInvoke(logException))
                {
                    return false;
                }
            }

            return true;
        }

        public static bool InvokeAny(this IEnumerable<Condition> self)
        {
            if (self == null)
            {
                DebugUtility.LogException<ArgumentNullException>(nameof(self));
                return false;
            }

            foreach (var condition in self)
            {
                if (condition.Invoke())
                {
                    return true;
                }
            }

            return false;
        }

        public static bool SafeInvokeAny(this IEnumerable<Condition> self, bool logException = Condition.DefaultLogException)
        {
            if (self == null)
            {
                DebugUtility.LogException<ArgumentNullException>(nameof(self));
                return false;
            }

            foreach (var condition in self)
            {
                if (condition.SafeInvoke(logException))
                {
                    return true;
                }
            }

            return false;
        }

        public static void CollectByValidation(this IEnumerable<Condition> self, IEnumerable<Condition> source, bool logException = true)
        {
            if (self == null)
            {
                DebugUtility.LogException<ArgumentNullException>(nameof(self));
                return;
            }

            if (source == null)
            {
                DebugUtility.LogException<ArgumentNullException>(nameof(source));
                return;
            }

            foreach (var condition in source)
            {
                if (condition.Validate(logException)
                    && !self.Contains(condition))
                {
                    self.Append(condition);
                }
            }
        }
    }
}