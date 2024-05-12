using System;
using Better.Commons.Runtime.Utility;

namespace Better.Commons.Runtime.Extensions
{
    public static class FuncExtensions
    {
        private const bool DefaultLogException = true;

        #region SafeInvoke`16

        public static TResult SafeInvoke<TResult>(this Func<TResult> self, bool logException = DefaultLogException)
        {
            try
            {
                return self.Invoke();
            }
            catch (Exception exception)
            {
                if (logException)
                {
                    DebugUtility.LogException(exception);
                }

                return default;
            }
        }

        public static TResult SafeInvoke<T, TResult>(
            this Func<T, TResult> self,
            T arg,
            bool logException = DefaultLogException)
        {
            try
            {
                return self.Invoke(arg);
            }
            catch (Exception exception)
            {
                if (logException)
                {
                    DebugUtility.LogException(exception);
                }

                return default;
            }
        }

        public static TResult SafeInvoke<T1, T2, TResult>(
            this Func<T1, T2, TResult> self,
            T1 arg1, T2 arg2,
            bool logException = DefaultLogException)
        {
            try
            {
                return self.Invoke(arg1, arg2);
            }
            catch (Exception exception)
            {
                if (logException)
                {
                    DebugUtility.LogException(exception);
                }

                return default;
            }
        }

        public static TResult SafeInvoke<T1, T2, T3, TResult>(
            this Func<T1, T2, T3, TResult> self,
            T1 arg1, T2 arg2, T3 arg3,
            bool logException = DefaultLogException)
        {
            try
            {
                return self.Invoke(arg1, arg2, arg3);
            }
            catch (Exception exception)
            {
                if (logException)
                {
                    DebugUtility.LogException(exception);
                }

                return default;
            }
        }

        public static TResult SafeInvoke<T1, T2, T3, T4, TResult>(
            this Func<T1, T2, T3, T4, TResult> self,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4,
            bool logException = DefaultLogException)
        {
            try
            {
                return self.Invoke(arg1, arg2, arg3, arg4);
            }
            catch (Exception exception)
            {
                if (logException)
                {
                    DebugUtility.LogException(exception);
                }

                return default;
            }
        }

        public static TResult SafeInvoke<T1, T2, T3, T4, T5, TResult>(
            this Func<T1, T2, T3, T4, T5, TResult> self,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5,
            bool logException = DefaultLogException)
        {
            try
            {
                return self.Invoke(arg1, arg2, arg3, arg4, arg5);
            }
            catch (Exception exception)
            {
                if (logException)
                {
                    DebugUtility.LogException(exception);
                }

                return default;
            }
        }

        public static TResult SafeInvoke<T1, T2, T3, T4, T5, T6, TResult>(
            this Func<T1, T2, T3, T4, T5, T6, TResult> self,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6,
            bool logException = DefaultLogException)
        {
            try
            {
                return self.Invoke(arg1, arg2, arg3, arg4, arg5, arg6);
            }
            catch (Exception exception)
            {
                if (logException)
                {
                    DebugUtility.LogException(exception);
                }

                return default;
            }
        }

        public static TResult SafeInvoke<T1, T2, T3, T4, T5, T6, T7, TResult>(
            this Func<T1, T2, T3, T4, T5, T6, T7, TResult> self,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7,
            bool logException = DefaultLogException)
        {
            try
            {
                return self.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7);
            }
            catch (Exception exception)
            {
                if (logException)
                {
                    DebugUtility.LogException(exception);
                }

                return default;
            }
        }

        public static TResult SafeInvoke<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(
            this Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult> self,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8,
            bool logException = DefaultLogException)
        {
            try
            {
                return self.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
            }
            catch (Exception exception)
            {
                if (logException)
                {
                    DebugUtility.LogException(exception);
                }

                return default;
            }
        }

        public static TResult SafeInvoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(
            this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> self,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9,
            bool logException = DefaultLogException)
        {
            try
            {
                return self.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
            }
            catch (Exception exception)
            {
                if (logException)
                {
                    DebugUtility.LogException(exception);
                }

                return default;
            }
        }

        public static TResult SafeInvoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>(
            this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> self,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10,
            bool logException = DefaultLogException)
        {
            try
            {
                return self.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
            }
            catch (Exception exception)
            {
                if (logException)
                {
                    DebugUtility.LogException(exception);
                }

                return default;
            }
        }

        public static TResult SafeInvoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>(
            this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> self,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11,
            bool logException = DefaultLogException)
        {
            try
            {
                return self.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
            }
            catch (Exception exception)
            {
                if (logException)
                {
                    DebugUtility.LogException(exception);
                }

                return default;
            }
        }

        public static TResult SafeInvoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>(
            this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> self,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12,
            bool logException = DefaultLogException)
        {
            try
            {
                return self.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
            }
            catch (Exception exception)
            {
                if (logException)
                {
                    DebugUtility.LogException(exception);
                }

                return default;
            }
        }

        public static TResult SafeInvoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>(
            this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> self,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13,
            bool logException = DefaultLogException)
        {
            try
            {
                return self.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
            }
            catch (Exception exception)
            {
                if (logException)
                {
                    DebugUtility.LogException(exception);
                }

                return default;
            }
        }

        public static TResult SafeInvoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>(
            this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> self,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14,
            bool logException = DefaultLogException)
        {
            try
            {
                return self.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
            }
            catch (Exception exception)
            {
                if (logException)
                {
                    DebugUtility.LogException(exception);
                }

                return default;
            }
        }

        public static TResult SafeInvoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>(
            this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> self,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15,
            bool logException = DefaultLogException)
        {
            try
            {
                return self.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15);
            }
            catch (Exception exception)
            {
                if (logException)
                {
                    DebugUtility.LogException(exception);
                }

                return default;
            }
        }

        public static TResult SafeInvoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult>(
            this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult> self,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15, T16 arg16,
            bool logException = DefaultLogException)
        {
            try
            {
                return self.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15, arg16);
            }
            catch (Exception exception)
            {
                if (logException)
                {
                    DebugUtility.LogException(exception);
                }

                return default;
            }
        }

        #endregion
    }
}