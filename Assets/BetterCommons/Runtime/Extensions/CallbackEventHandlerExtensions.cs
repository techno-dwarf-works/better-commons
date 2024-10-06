using UnityEngine.UIElements;

namespace Better.Commons.Runtime.Extensions
{
    public static class CallbackEventHandlerExtensions
    {
        #region RegisterCallback`16

        public static void RegisterCallback<TEventType, T1, T2>(
            this CallbackEventHandler self,
            EventCallback<TEventType, (T1, T2)> callback,
            T1 arg1, T2 arg2
        ) where TEventType : EventBase<TEventType>, new()
        {
            self.RegisterCallback(callback, (arg1, arg2));
        }

        public static void RegisterCallback<TEventType, T1, T2, T3>(
            this CallbackEventHandler self,
            EventCallback<TEventType, (T1, T2, T3)> callback,
            T1 arg1, T2 arg2, T3 arg3
        ) where TEventType : EventBase<TEventType>, new()
        {
            self.RegisterCallback(callback, (arg1, arg2, arg3));
        }

        public static void RegisterCallback<TEventType, T1, T2, T3, T4>(
            this CallbackEventHandler self,
            EventCallback<TEventType, (T1, T2, T3, T4)> callback,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4
        ) where TEventType : EventBase<TEventType>, new()
        {
            self.RegisterCallback(callback, (arg1, arg2, arg3, arg4));
        }

        public static void RegisterCallback<TEventType, T1, T2, T3, T4, T5>(
            this CallbackEventHandler self,
            EventCallback<TEventType, (T1, T2, T3, T4, T5)> callback,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5
        ) where TEventType : EventBase<TEventType>, new()
        {
            self.RegisterCallback(callback, (arg1, arg2, arg3, arg4, arg5));
        }

        public static void RegisterCallback<TEventType, T1, T2, T3, T4, T5, T6>(
            this CallbackEventHandler self,
            EventCallback<TEventType, (T1, T2, T3, T4, T5, T6)> callback,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6
        ) where TEventType : EventBase<TEventType>, new()
        {
            self.RegisterCallback(callback, (arg1, arg2, arg3, arg4, arg5, arg6));
        }

        public static void RegisterCallback<TEventType, T1, T2, T3, T4, T5, T6, T7>(
            this CallbackEventHandler self,
            EventCallback<TEventType, (T1, T2, T3, T4, T5, T6, T7)> callback,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7
        ) where TEventType : EventBase<TEventType>, new()
        {
            self.RegisterCallback(callback, (arg1, arg2, arg3, arg4, arg5, arg6, arg7));
        }

        public static void RegisterCallback<TEventType, T1, T2, T3, T4, T5, T6, T7, T8>(
            this CallbackEventHandler self,
            EventCallback<TEventType, (T1, T2, T3, T4, T5, T6, T7, T8)> callback,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8
        ) where TEventType : EventBase<TEventType>, new()
        {
            self.RegisterCallback(callback, (arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8));
        }

        public static void RegisterCallback<TEventType, T1, T2, T3, T4, T5, T6, T7, T8, T9>(
            this CallbackEventHandler self,
            EventCallback<TEventType, (T1, T2, T3, T4, T5, T6, T7, T8, T9)> callback,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9
        ) where TEventType : EventBase<TEventType>, new()
        {
            self.RegisterCallback(callback, (arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9));
        }

        public static void RegisterCallback<TEventType, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(
            this CallbackEventHandler self,
            EventCallback<TEventType, (T1, T2, T3, T4, T5, T6, T7, T8, T9, T10)> callback,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10
        ) where TEventType : EventBase<TEventType>, new()
        {
            self.RegisterCallback(callback, (arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10));
        }

        public static void RegisterCallback<TEventType, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(
            this CallbackEventHandler self,
            EventCallback<TEventType, (T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11)> callback,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11
        ) where TEventType : EventBase<TEventType>, new()
        {
            self.RegisterCallback(callback, (arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11));
        }

        public static void RegisterCallback<TEventType, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(
            this CallbackEventHandler self,
            EventCallback<TEventType, (T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12)> callback,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12
        ) where TEventType : EventBase<TEventType>, new()
        {
            self.RegisterCallback(callback, (arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12));
        }

        public static void RegisterCallback<TEventType, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(
            this CallbackEventHandler self,
            EventCallback<TEventType, (T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13)> callback,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13
        ) where TEventType : EventBase<TEventType>, new()
        {
            self.RegisterCallback(callback, (arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13));
        }

        public static void RegisterCallback<TEventType, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(
            this CallbackEventHandler self,
            EventCallback<TEventType, (T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14)> callback,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14
        ) where TEventType : EventBase<TEventType>, new()
        {
            self.RegisterCallback(callback, (arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14));
        }

        public static void RegisterCallback<TEventType, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(
            this CallbackEventHandler self,
            EventCallback<TEventType, (T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15)> callback,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15
        ) where TEventType : EventBase<TEventType>, new()
        {
            self.RegisterCallback(callback, (arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15));
        }

        public static void RegisterCallback<TEventType, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(
            this CallbackEventHandler self,
            EventCallback<TEventType, (T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16)> callback,
            T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15, T16 arg16
        ) where TEventType : EventBase<TEventType>, new()
        {
            self.RegisterCallback(callback, (arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15, arg16));
        }

        #endregion
    }
}