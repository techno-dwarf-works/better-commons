using System.Collections.Generic;
using Better.Commons.Runtime.Enums;
using Better.Commons.Runtime.Extensions;
using UnityEngine;

namespace Better.Commons.Runtime.Utility
{
    public struct Vector4Utility
    {
        public static bool Approximately(Vector4 current, Vector4 other)
        {
            return Mathf.Approximately(current.x, other.x)
                   && Mathf.Approximately(current.y, other.y)
                   && Mathf.Approximately(current.z, other.z)
                   && Mathf.Approximately(current.w, other.w);
        }

        public static Vector4 MiddlePoint(Vector4 start, Vector4 end)
        {
            var t = start + end;
            return t / 2;
        }

        public static Vector4 MiddlePoint(Vector4 start, Vector4 end, Vector4 offset)
        {
            var middlePoint = MiddlePoint(start, end);
            return middlePoint + offset;
        }

        public static Vector4 SlerpUnclamped(Vector4 a, Vector4 b, float t)
        {
            a.Normalize();
            b.Normalize();

            var dot = Vector4.Dot(a, b);
            dot = Mathf.Clamp(dot, -1.0f, 1.0f);

            var theta = Mathf.Acos(dot) * t;
            var relativeVector = b - a * dot;
            relativeVector.Normalize();

            return a * Mathf.Cos(theta) + relativeVector * Mathf.Sin(theta);
        }

        public static Vector4 Slerp(Vector4 a, Vector4 b, float t)
        {
            t = Mathf.Clamp01(t);
            return SlerpUnclamped(a, b, t);
        }

        public static Vector4 AxesInverseLerp(Vector4 a, Vector4 b, Vector4 value)
        {
            return new Vector4(
                Mathf.InverseLerp(a.x, b.x, value.x),
                Mathf.InverseLerp(a.y, b.y, value.y)
            );
        }

        public static float InverseLerp(Vector4 a, Vector4 b, Vector4 value)
        {
            if (a == b)
            {
                return default;
            }

            var ab = b - a;
            var av = value - a;

            var result = Vector4.Dot(av, ab) / Vector4.Dot(ab, ab);
            return Mathf.Clamp01(result);
        }

        public static Vector4 Direction(Vector4 from, Vector4 to)
        {
            var difference = to - from;
            return difference.normalized;
        }

        public static float SqrDistanceTo(Vector4 from, Vector4 to)
        {
            var difference = to - from;
            return difference.sqrMagnitude;
        }

        public static Vector4 Abs(Vector4 source)
        {
            source.x = Mathf.Abs(source.x);
            source.y = Mathf.Abs(source.y);
            return source;
        }

        public static Vector4 ApplyAxes(Vector4 target, Vector4 source, IEnumerable<Vector4Axis> axes)
        {
            foreach (var axis in axes)
            {
                target[(int)axis] = source.GetAxis(axis);
            }

            return target;
        }
    }
}