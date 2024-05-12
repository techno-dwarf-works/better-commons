﻿using System;
using Better.Commons.Runtime.Utility;

namespace Better.Commons.Runtime.Extensions
{
    public static class EnumExtensions
    {
        public static int ToFlagInt(this Enum self)
        {
            if (self == null)
            {
                DebugUtility.LogException<ArgumentNullException>(nameof(self));
                return -1;
            }

            if (Enum.GetUnderlyingType(self.GetType()) != typeof(ulong))
            {
                return (int)Convert.ToInt64(self);
            }

            return (int)Convert.ToUInt64(self);
        }

        public static bool IsFlagAll(this Enum self)
        {
            if (self == null)
            {
                DebugUtility.LogException<ArgumentNullException>(nameof(self));
                return false;
            }

            var everythingFlag = EnumUtility.EverythingFlag(self.GetType());
            return Equals(self, everythingFlag);
        }

        public static bool IsFlagDefault(this Enum self)
        {
            if (self == null)
            {
                DebugUtility.LogException<ArgumentNullException>(nameof(self));
                return default;
            }

            return self.ToFlagInt() == EnumUtility.DefaultIntFlag;
        }

        public static TEnum Add<TEnum>(this TEnum self, TEnum value)
            where TEnum : Enum
        {
            return (TEnum)EnumUtility.Add(self, value);
        }

        public static TEnum Remove<TEnum>(this TEnum self, TEnum value)
            where TEnum : Enum
        {
            return (TEnum)EnumUtility.Remove(self, value);
        }
    }
}