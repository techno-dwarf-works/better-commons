using System;
using UnityEngine;
using Better.Commons.Runtime.DataStructures.Ranges;

namespace Better.Commons.Runtime.DataStructures.SerializedTypes
{
    /// <summary>
    /// Represents a range with minimum and maximum values of a generic type.
    /// </summary>
    /// <typeparam name="T">The type of the values defining the range.</typeparam>
    [Serializable]
    public class SerializedRange<T> : Range<T>
    {
        [SerializeField] private T _min;
        [SerializeField] private T _max;

        /// <summary>
        /// Initializes a new instance of the Range class with default minimum and maximum values.
        /// </summary>
        public SerializedRange()
        {
            _min = default;
            _max = default;
        }

        /// <summary>
        /// Initializes a new instance of the Range class by copying another range.
        /// </summary>
        /// <param name="range">The range to copy.</param>
        public SerializedRange(Range<T> range)
        {
            _min = range.Min;
            _max = range.Max;
        }

        /// <summary>
        /// Initializes a new instance of the Range class with specified minimum and maximum values.
        /// </summary>
        /// <param name="min">The minimum value of the range.</param>
        /// <param name="max">The maximum value of the range.</param>
        public SerializedRange(T min, T max)
        {
            _min = min;
            _max = max;
        }

        /// <summary>
        /// Gets the minimum value of the range.
        /// </summary>
        public override T Min => _min;

        /// <summary>
        /// Gets the maximum value of the range.
        /// </summary>
        public override T Max => _max;

        /// <summary>
        /// Creates a new instance of the Range that is a copy of the current Range.
        /// </summary>
        /// <returns>A new Range instance that is a copy of this Range.</returns>
        public override Range<T> Clone()
        {
            return new SerializedRange<T>(_min, _max);
        }

        /// <summary>
        /// Creates a new instance of the Range with the same minimum value as this instance and a new maximum value.
        /// </summary>
        /// <param name="maxValue">The new maximum value for the range.</param>
        /// <returns>A new Range instance with the updated maximum value while retaining the original minimum value.</returns>
        public SerializedRange<T> CopyWithMax(T maxValue)
        {
            return new SerializedRange<T>(_min, maxValue);
        }

        /// <summary>
        /// Creates a new instance of the Range with the same maximum value as this instance and a new minimum value.
        /// </summary>
        /// <param name="minValue">The new minimum value for the range.</param>
        /// <returns>A new Range instance with the updated minimum value while retaining the original maximum value.</returns>
        public SerializedRange<T> CopyWithMin(T minValue)
        {
            return new SerializedRange<T>(minValue, _max);
        }
    }
}