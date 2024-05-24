using System;
using System.Collections.Generic;
using System.Text;
using Better.Commons.Runtime.Utility;

namespace Better.Commons.Runtime.Extensions
{
    public static class StringBuilderExtensions
    {
        private const string InfoFieldSeparator = ": ";

        public static StringBuilder AppendLine(this StringBuilder self, object value)
        {
            if (self == null)
            {
                DebugUtility.LogException<ArgumentNullException>(nameof(self));
                return null;
            }

            if (value == null)
            {
                DebugUtility.LogException<ArgumentNullException>(nameof(value));
                return self;
            }

            return self.AppendLine(value.ToString());
        }

        public static StringBuilder AppendFormatLine(this StringBuilder self, IFormatProvider provider, string format, object arg0)
        {
            if (self == null)
            {
                DebugUtility.LogException<ArgumentNullException>(nameof(self));
                return null;
            }

            if (provider == null)
            {
                DebugUtility.LogException<ArgumentNullException>(nameof(self));
                return null;
            }

            return self.AppendFormat(provider, format, arg0).AppendLine();
        }

        public static StringBuilder AppendFormatLine(this StringBuilder self, IFormatProvider provider, string format, object arg0, object arg1)
        {
            if (self == null)
            {
                DebugUtility.LogException<ArgumentNullException>(nameof(self));
                return null;
            }

            if (provider == null)
            {
                DebugUtility.LogException<ArgumentNullException>(nameof(self));
                return null;
            }

            return self.AppendFormat(provider, format, arg0, arg1).AppendLine();
        }

        public static StringBuilder AppendFormatLine(this StringBuilder self, IFormatProvider provider, string format, object arg0, object arg1, object arg2)
        {
            if (self == null)
            {
                DebugUtility.LogException<ArgumentNullException>(nameof(self));
                return null;
            }

            if (provider == null)
            {
                DebugUtility.LogException<ArgumentNullException>(nameof(self));
                return null;
            }

            return self.AppendFormat(provider, format, arg0, arg1, arg2).AppendLine();
        }

        public static StringBuilder AppendFormatLine(this StringBuilder self, IFormatProvider provider, string format, params object[] args)
        {
            if (self == null)
            {
                DebugUtility.LogException<ArgumentNullException>(nameof(self));
                return null;
            }

            if (provider == null)
            {
                DebugUtility.LogException<ArgumentNullException>(nameof(self));
                return null;
            }

            return self.AppendFormat(provider, format, args).AppendLine();
        }

        public static StringBuilder AppendFormatLine(this StringBuilder self, string format, object arg0)
        {
            if (self == null)
            {
                DebugUtility.LogException<ArgumentNullException>(nameof(self));
                return null;
            }

            return self.AppendFormat(format, arg0).AppendLine();
        }

        public static StringBuilder AppendFormatLine(this StringBuilder self, string format, object arg0, object arg1)
        {
            if (self == null)
            {
                DebugUtility.LogException<ArgumentNullException>(nameof(self));
                return null;
            }

            return self.AppendFormat(format, arg0, arg1).AppendLine();
        }

        public static StringBuilder AppendFormatLine(this StringBuilder self, string format, object arg0, object arg1, object arg2)
        {
            if (self == null)
            {
                DebugUtility.LogException<ArgumentNullException>(nameof(self));
                return null;
            }

            return self.AppendFormat(format, arg0, arg1, arg2).AppendLine();
        }

        public static StringBuilder AppendFormatLine(this StringBuilder self, string format, params object[] args)
        {
            if (self == null)
            {
                DebugUtility.LogException<ArgumentNullException>(nameof(self));
                return null;
            }

            if (args == null)
            {
                DebugUtility.LogException<ArgumentNullException>(nameof(self));
                return null;
            }

            return self.AppendFormat(format, args).AppendLine();
        }

        public static StringBuilder AppendJoinLine(this StringBuilder self, char separator, params object[] values)
        {
            if (self == null)
            {
                DebugUtility.LogException<ArgumentNullException>(nameof(self));
                return null;
            }

            if (values == null)
            {
                DebugUtility.LogException<ArgumentNullException>(nameof(self));
                return null;
            }

            return self.AppendJoin(separator, values).AppendLine();
        }

        public static StringBuilder AppendJoinLine(this StringBuilder self, char separator, params string[] values)
        {
            if (self == null)
            {
                DebugUtility.LogException<ArgumentNullException>(nameof(self));
                return null;
            }

            if (values == null)
            {
                DebugUtility.LogException<ArgumentNullException>(nameof(self));
                return null;
            }

            return self.AppendJoin(separator, values).AppendLine();
        }

        public static StringBuilder AppendJoinLine(this StringBuilder self, string separator, params object[] values)
        {
            if (self == null)
            {
                DebugUtility.LogException<ArgumentNullException>(nameof(self));
                return null;
            }

            if (values == null)
            {
                DebugUtility.LogException<ArgumentNullException>(nameof(self));
                return null;
            }

            return self.AppendJoin(separator, values).AppendLine();
        }

        public static StringBuilder AppendJoinLine(this StringBuilder self, string separator, params string[] values)
        {
            if (self == null)
            {
                DebugUtility.LogException<ArgumentNullException>(nameof(self));
                return null;
            }

            if (values == null)
            {
                DebugUtility.LogException<ArgumentNullException>(nameof(self));
                return null;
            }

            return self.AppendJoin(separator, values).AppendLine();
        }

        public static StringBuilder AppendJoinLine<T>(this StringBuilder self, char separator, IEnumerable<T> values)
        {
            if (self == null)
            {
                DebugUtility.LogException<ArgumentNullException>(nameof(self));
                return null;
            }

            if (values == null)
            {
                DebugUtility.LogException<ArgumentNullException>(nameof(self));
                return null;
            }

            return self.AppendJoin(separator, values).AppendLine();
        }

        public static StringBuilder AppendJoinLine<T>(this StringBuilder self, string separator, IEnumerable<T> values)
        {
            if (self == null)
            {
                DebugUtility.LogException<ArgumentNullException>(nameof(self));
                return null;
            }

            if (values == null)
            {
                DebugUtility.LogException<ArgumentNullException>(nameof(self));
                return null;
            }

            return self.AppendJoin(separator, values).AppendLine();
        }

        public static StringBuilder AppendField(this StringBuilder self, string fieldName, object fieldValue)
        {
            if (self == null)
            {
                DebugUtility.LogException<ArgumentNullException>(nameof(self));
                return null;
            }

            self.AppendJoin(InfoFieldSeparator, fieldName, fieldValue);
            return self;
        }

        public static StringBuilder AppendFieldLine(this StringBuilder self, string fieldName, object fieldValue)
        {
            if (self == null)
            {
                DebugUtility.LogException<ArgumentNullException>(nameof(self));
                return null;
            }

            return self.AppendField(fieldName, fieldValue).AppendLine();
        }
    }
}