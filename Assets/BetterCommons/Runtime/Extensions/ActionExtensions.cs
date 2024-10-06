using System;
using Better.Commons.Runtime.Utility;

namespace Better.Commons.Runtime.Extensions
{
    public static class ActionExtensions
    {
        private const bool DefaultLogException = true;

        #region TryInvoke`16

        public static bool TryInvoke(this Action self, bool logException = DefaultLogException)
        {
            try
            {
                self.Invoke();
                return true;
            }
            catch (Exception exception)
            {
                if (logException)
                {
                    DebugUtility.LogException(exception);
                }

                return false;
            }
        }

        public static bool TryInvoke<T>(this Action<T> self, T obj, bool logException = DefaultLogException)
        {
            try
            {
                self.Invoke(obj);
                return true;
            }
            catch (Exception exception)
            {
                if (logException)
                {
                    DebugUtility.LogException(exception);
                }

                return false;
            }
        }

        public static bool TryInvoke<T1, T2>(
            this Action<T1, T2> self,
            T1 arg1, T2 arg2,
            bool logException = DefaultLogException)
        {
            try
            {
                self.Invoke(arg1, arg2);
                return true;
            }
            catch (Exception exception)
            {
                if (logException)
                {
                    DebugUtility.LogException(exception);
                }

                return false;
            }
        }

        public static bool TryInvoke<T1, T2, T3>(
            this Action<T1, T2, T3> self,
            T1 arg1, T2 arg2, T3 arg3,
            bool logException = DefaultLogException)
        {
            try
            {
                self.Invoke(arg1, arg2, arg3);
                return true;
            }
            catch (Exception exception)
            {
                if (logException)
                {
                    DebugUtility.LogException(exception);
                }

                return false;
            }
        }

        public static bool TryInvoke<T1, T2, T3, T4>(
            this Action<T1, T2, T3, T4> self,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4,
            bool logException = DefaultLogException)
        {
            try
            {
                self.Invoke(arg1, arg2, arg3, arg4);
                return true;
            }
            catch (Exception exception)
            {
                if (logException)
                {
                    DebugUtility.LogException(exception);
                }

                return false;
            }
        }

        public static bool TryInvoke<T1, T2, T3, T4, T5>(
            this Action<T1, T2, T3, T4, T5> self,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5,
            bool logException = DefaultLogException)
        {
            try
            {
                self.Invoke(arg1, arg2, arg3, arg4, arg5);
                return true;
            }
            catch (Exception exception)
            {
                if (logException)
                {
                    DebugUtility.LogException(exception);
                }

                return false;
            }
        }

        public static bool TryInvoke<T1, T2, T3, T4, T5, T6>(
            this Action<T1, T2, T3, T4, T5, T6> self,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6,
            bool logException = DefaultLogException)
        {
            try
            {
                self.Invoke(arg1, arg2, arg3, arg4, arg5, arg6);
                return true;
            }
            catch (Exception exception)
            {
                if (logException)
                {
                    DebugUtility.LogException(exception);
                }

                return false;
            }
        }

        public static bool TryInvoke<T1, T2, T3, T4, T5, T6, T7>(
            this Action<T1, T2, T3, T4, T5, T6, T7> self,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7,
            bool logException = DefaultLogException)
        {
            try
            {
                self.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7);
                return true;
            }
            catch (Exception exception)
            {
                if (logException)
                {
                    DebugUtility.LogException(exception);
                }

                return false;
            }
        }

        public static bool TryInvoke<T1, T2, T3, T4, T5, T6, T7, T8>(
            this Action<T1, T2, T3, T4, T5, T6, T7, T8> self,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8,
            bool logException = DefaultLogException)
        {
            try
            {
                self.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
                return true;
            }
            catch (Exception exception)
            {
                if (logException)
                {
                    DebugUtility.LogException(exception);
                }

                return false;
            }
        }

        public static bool TryInvoke<T1, T2, T3, T4, T5, T6, T7, T8, T9>(
            this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> self,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9,
            bool logException = DefaultLogException)
        {
            try
            {
                self.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
                return true;
            }
            catch (Exception exception)
            {
                if (logException)
                {
                    DebugUtility.LogException(exception);
                }

                return false;
            }
        }

        public static bool TryInvoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(
            this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> self,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10,
            bool logException = DefaultLogException)
        {
            try
            {
                self.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
                return true;
            }
            catch (Exception exception)
            {
                if (logException)
                {
                    DebugUtility.LogException(exception);
                }

                return false;
            }
        }

        public static bool TryInvoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(
            this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> self,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11,
            bool logException = DefaultLogException)
        {
            try
            {
                self.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
                return true;
            }
            catch (Exception exception)
            {
                if (logException)
                {
                    DebugUtility.LogException(exception);
                }

                return false;
            }
        }

        public static bool TryInvoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(
            this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> self,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12,
            bool logException = DefaultLogException)
        {
            try
            {
                self.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
                return true;
            }
            catch (Exception exception)
            {
                if (logException)
                {
                    DebugUtility.LogException(exception);
                }

                return false;
            }
        }

        public static bool TryInvoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(
            this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> self,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13,
            bool logException = DefaultLogException)
        {
            try
            {
                self.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
                return true;
            }
            catch (Exception exception)
            {
                if (logException)
                {
                    DebugUtility.LogException(exception);
                }

                return false;
            }
        }

        public static bool TryInvoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(
            this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> self,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14,
            bool logException = DefaultLogException)
        {
            try
            {
                self.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
                return true;
            }
            catch (Exception exception)
            {
                if (logException)
                {
                    DebugUtility.LogException(exception);
                }

                return false;
            }
        }

        public static bool TryInvoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(
            this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> self,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15,
            bool logException = DefaultLogException)
        {
            try
            {
                self.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15);
                return true;
            }
            catch (Exception exception)
            {
                if (logException)
                {
                    DebugUtility.LogException(exception);
                }

                return false;
            }
        }

        public static bool TryInvoke<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(
            this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> self,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15, T16 arg16,
            bool logException = DefaultLogException)
        {
            try
            {
                self.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15, arg16);
                return true;
            }
            catch (Exception exception)
            {
                if (logException)
                {
                    DebugUtility.LogException(exception);
                }

                return false;
            }
        }

        #endregion
    }
}