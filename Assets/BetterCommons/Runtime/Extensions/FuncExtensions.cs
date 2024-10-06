﻿using System;
using Better.Commons.Runtime.Utility;

namespace Better.Commons.Runtime.Extensions
{
    public static class FuncExtensions
    {
        private const bool DefaultLogException = true;

        #region TryInvoke`16

        public static bool TryInvoke<TResult>(this Func<TResult> self, out TResult result, bool logException = DefaultLogException)
        {
            try
            {
                result = self.Invoke();
                return true;
            }
            catch (Exception exception)
            {
                if (logException)
                {
                    DebugUtility.LogException(exception);
                }

                result = default;
                return false;
            }
        }

        public static bool TryInvoke<T, TResult>(
            this Func<T, TResult> self,
            T arg,
            out TResult result, bool logException = DefaultLogException)
        {
            try
            {
                result = self.Invoke(arg);
                return true;
            }
            catch (Exception exception)
            {
                if (logException)
                {
                    DebugUtility.LogException(exception);
                }

                result = default;
                return false;
            }
        }

        public static bool TryInvoke<T1, T2, TResult>(
            this Func<T1, T2, TResult> self,
            T1 arg1, T2 arg2,
            out TResult result, bool logException = DefaultLogException)
        {
            try
            {
                result = self.Invoke(arg1, arg2);
                return true;
            }
            catch (Exception exception)
            {
                if (logException)
                {
                    DebugUtility.LogException(exception);
                }

                result = default;
                return false;
            }
        }

        public static bool TryInvoke<T1, T2, T3, TResult>(
            this Func<T1, T2, T3, TResult> self,
            T1 arg1, T2 arg2, T3 arg3,
            out TResult result, bool logException = DefaultLogException)
        {
            try
            {
                result = self.Invoke(arg1, arg2, arg3);
                return true;
            }
            catch (Exception exception)
            {
                if (logException)
                {
                    DebugUtility.LogException(exception);
                }

                result = default;
                return false;
            }
        }

        public static bool TryInvoke<T1, T2, T3, T4, TResult>(
            this Func<T1, T2, T3, T4, TResult> self,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4,
            out TResult result, bool logException = DefaultLogException)
        {
            try
            {
                result = self.Invoke(arg1, arg2, arg3, arg4);
                return true;
            }
            catch (Exception exception)
            {
                if (logException)
                {
                    DebugUtility.LogException(exception);
                }

                result = default;
                return false;
            }
        }

        public static bool TryInvoke<T1, T2, T3, T4, T5, TResult>(
            this Func<T1, T2, T3, T4, T5, TResult> self,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5,
            out TResult result, bool logException = DefaultLogException)
        {
            try
            {
                result = self.Invoke(arg1, arg2, arg3, arg4, arg5);
                return true;
            }
            catch (Exception exception)
            {
                if (logException)
                {
                    DebugUtility.LogException(exception);
                }

                result = default;
                return false;
            }
        }

        public static bool TryInvoke<T1, T2, T3, T4, T5, T6, TResult>(
            this Func<T1, T2, T3, T4, T5, T6, TResult> self,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6,
            out TResult result, bool logException = DefaultLogException)
        {
            try
            {
                result = self.Invoke(arg1, arg2, arg3, arg4, arg5, arg6);
                return true;
            }
            catch (Exception exception)
            {
                if (logException)
                {
                    DebugUtility.LogException(exception);
                }

                result = default;
                return false;
            }
        }

        public static bool TryInvoke<T1, T2, T3, T4, T5, T6, T7, TResult>(
            this Func<T1, T2, T3, T4, T5, T6, T7, TResult> self,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7,
            out TResult result, bool logException = DefaultLogException)
        {
            try
            {
                result = self.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7);
                return true;
            }
            catch (Exception exception)
            {
                if (logException)
                {
                    DebugUtility.LogException(exception);
                }

                result = default;
                return false;
            }
        }

        public static bool TryInvoke<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(
            this Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult> self,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8,
            out TResult result, bool logException = DefaultLogException)
        {
            try
            {
                result = self.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
                return true;
            }
            catch (Exception exception)
            {
                if (logException)
                {
                    DebugUtility.LogException(exception);
                }

                result = default;
                return false;
            }
        }

        public static bool TryInvoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(
            this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> self,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9,
            out TResult result, bool logException = DefaultLogException)
        {
            try
            {
                result = self.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
                return true;
            }
            catch (Exception exception)
            {
                if (logException)
                {
                    DebugUtility.LogException(exception);
                }

                result = default;
                return false;
            }
        }

        public static bool TryInvoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>(
            this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> self,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10,
            out TResult result, bool logException = DefaultLogException)
        {
            try
            {
                result = self.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
                return true;
            }
            catch (Exception exception)
            {
                if (logException)
                {
                    DebugUtility.LogException(exception);
                }

                result = default;
                return false;
            }
        }

        public static bool TryInvoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>(
            this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> self,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11,
            out TResult result, bool logException = DefaultLogException)
        {
            try
            {
                result = self.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
                return true;
            }
            catch (Exception exception)
            {
                if (logException)
                {
                    DebugUtility.LogException(exception);
                }

                result = default;
                return false;
            }
        }

        public static bool TryInvoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>(
            this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> self,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12,
            out TResult result, bool logException = DefaultLogException)
        {
            try
            {
                result = self.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
                return true;
            }
            catch (Exception exception)
            {
                if (logException)
                {
                    DebugUtility.LogException(exception);
                }

                result = default;
                return false;
            }
        }

        public static bool TryInvoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>(
            this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> self,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13,
            out TResult result, bool logException = DefaultLogException)
        {
            try
            {
                result = self.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
                return true;
            }
            catch (Exception exception)
            {
                if (logException)
                {
                    DebugUtility.LogException(exception);
                }

                result = default;
                return false;
            }
        }

        public static bool TryInvoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>(
            this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> self,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14,
            out TResult result, bool logException = DefaultLogException)
        {
            try
            {
                result = self.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
                return true;
            }
            catch (Exception exception)
            {
                if (logException)
                {
                    DebugUtility.LogException(exception);
                }

                result = default;
                return false;
            }
        }

        public static bool TryInvoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>(
            this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> self,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15,
            out TResult result, bool logException = DefaultLogException)
        {
            try
            {
                result = self.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15);
                return true;
            }
            catch (Exception exception)
            {
                if (logException)
                {
                    DebugUtility.LogException(exception);
                }

                result = default;
                return false;
            }
        }

        public static bool TryInvoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult>(
            this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult> self,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15, T16 arg16,
            out TResult result, bool logException = DefaultLogException)
        {
            try
            {
                result = self.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15, arg16);
                return true;
            }
            catch (Exception exception)
            {
                if (logException)
                {
                    DebugUtility.LogException(exception);
                }

                result = default;
                return false;
            }
        }

        #endregion
    }
}