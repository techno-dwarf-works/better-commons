using System;
using System.Collections.Generic;
using Better.Commons.Runtime.Interfaces;

namespace Better.Commons.Runtime.DataStructures.Ranges
{
    public abstract class Range<T> : IEquatable<Range<T>>, ICloneable<Range<T>>
    {
        /// <summary>
        /// Gets the minimum value of the range.
        /// </summary>
        public abstract T Min { get; }

        /// <summary>
        /// Gets the maximum value of the range.
        /// </summary>
        public abstract T Max { get; }
        
        /// <summary>
        /// Determines whether the specified Range is equal to the current Range.
        /// </summary>
        /// <param name="other">The Range to compare with the current Range.</param>
        /// <returns>true if the specified Range is equal to the current Range; otherwise, false.</returns>
        public bool Equals(Range<T> other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return EqualityComparer<T>.Default.Equals(Min, other.Min) && EqualityComparer<T>.Default.Equals(Max, other.Max);
        }
        
        public abstract Range<T> Clone();

        /// <summary>
        /// Determines whether the specified object is equal to the current Range.
        /// </summary>
        /// <param name="obj">The object to compare with the current Range.</param>
        /// <returns>true if the specified object is equal to the current Range; otherwise, false.</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Range<T>)obj);
        }
        
        /// <summary>
        /// Serves as the default hash function.
        /// </summary>
        /// <returns>A hash code for the current Range.</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                return (EqualityComparer<T>.Default.GetHashCode(Min) * 397) ^ EqualityComparer<T>.Default.GetHashCode(Max);
            }
        }
    }
}
