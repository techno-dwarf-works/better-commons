using System.Collections.Generic;
using Better.Commons.Runtime.Enums;
using Better.Commons.Runtime.Utility;
using Unity.Collections;
using UnityEngine;

namespace Better.Commons.Runtime.Extensions
{
    public static class Vector4Extensions
    {
        public static bool Approximately(this Vector4 self, Vector4 other)
        {
            return Vector4Utility.Approximately(self, other);
        }

        public static Vector4 DirectionTo(this Vector4 self, Vector4 to)
        {
            return Vector4Utility.Direction(self, to);
        }

        public static float DistanceTo(this Vector4 self, Vector4 to)
        {
            return Vector4.Distance(self, to);
        }

        public static float SqrDistanceTo(this Vector4 self, Vector4 to)
        {
            return Vector4Utility.SqrDistanceTo(self, to);
        }

        public static Vector4 Abs(this Vector4 self)
        {
            return Vector4Utility.Abs(self);
        }

        public static float GetAxis(this Vector4 self, Vector4Axis axis)
        {
            return self[(int)axis];
        }
    }
}