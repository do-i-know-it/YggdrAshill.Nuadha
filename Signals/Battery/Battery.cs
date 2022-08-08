using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha.Signals
{
    /// <summary>
    /// Implementation of <see cref="ISignal"/> for batter.
    /// </summary>
    public struct Battery :
        ISignal,
        IEquatable<Battery>
    {
        /// <summary>
        /// Minimum <see cref="float"/> for <see cref="Battery"/>.
        /// </summary>
        public const float Minimum = 0.0f;

        /// <summary>
        /// Maximum <see cref="float"/> for <see cref="Battery"/>.
        /// </summary>
        public const float Maximum = 1.0f;

        /// <summary>
        /// Empty <see cref="Battery"/>.
        /// </summary>
        public static Battery Empty { get; } = new Battery(Minimum);

        /// <summary>
        /// Full <see cref="Battery"/>.
        /// </summary>
        public static Battery Full { get; } = new Battery(Maximum);

        private readonly float level;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="level">
        /// <see cref="float"/> for <see cref="Battery"/>.
        /// </param>
        /// <exception cref="ArgumentException">
        /// Thrown if <paramref name="level"/> is <see cref="float.NaN"/>.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown if <paramref name="level"/> is out of range between <see cref="Minimum"/> and <see cref="Maximum"/>.
        /// </exception>
        public Battery(float level)
        {
            if (float.IsNaN(level))
            {
                throw new ArgumentException($"{nameof(level)} is NaN.");
            }

            if (level < Minimum || Maximum < level)
            {
                throw new ArgumentOutOfRangeException(nameof(level));
            }

            this.level = level;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"{level}";
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return level.GetHashCode();
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj is Battery signal)
            {
                return Equals(signal);
            }

            return false;
        }

        /// <inheritdoc/>
        public bool Equals(Battery other)
        {
            return level.Equals(other.level);
        }

        /// <summary>
        /// Converts explicitly <see cref="float"/> to <see cref="Battery"/>.
        /// </summary>
        /// <param name="signal">
        /// <see cref="float"/> to covert.
        /// </param>
        /// <returns>
        /// <see cref="Battery"/> converted.
        /// </returns>
        public static explicit operator Battery(float signal)
        {
            if (signal <= Minimum)
            {
                return Empty;
            }
            if (Maximum <= signal)
            {
                return Full;
            }

            return new Battery(signal);
        }

        /// <summary>
        /// Converts explicitly <see cref="Battery"/> to <see cref="float"/>.
        /// </summary>
        /// <param name="signal">
        /// <see cref="Battery"/> to covert.
        /// </param>
        /// <returns>
        /// <see cref="float"/> converted.
        /// </returns>
        public static explicit operator float(Battery signal)
        {
            return signal.level;
        }

        /// <summary>
        /// Checks if <paramref name="left"/> and <paramref name="right"/> are equal.
        /// </summary>
        /// <param name="left">
        /// <see cref="Battery"/> to check.
        /// </param>
        /// <param name="right">
        /// <see cref="Battery"/> to check.
        /// </param>
        /// <returns>
        /// True if <paramref name="left"/> and <paramref name="right"/> are equal.
        /// </returns>
        public static bool operator ==(Battery left, Battery right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Checks if <paramref name="left"/> and <paramref name="right"/> are not equal.
        /// </summary>
        /// <param name="left">
        /// <see cref="Battery"/> to check.
        /// </param>
        /// <param name="right">
        /// <see cref="Battery"/> to check.
        /// </param>
        /// <returns>
        /// True if <paramref name="left"/> and <paramref name="right"/> are not equal.
        /// </returns>
        public static bool operator !=(Battery left, Battery right)
        {
            return !(left == right);
        }

        /// <summary>
        /// Checks if <paramref name="left"/> is more than <paramref name="right"/>.
        /// </summary>
        /// <param name="left">
        /// <see cref="Battery"/> to check.
        /// </param>
        /// <param name="right">
        /// <see cref="Battery"/> to check.
        /// </param>
        /// <returns>
        /// True if <paramref name="left"/> is more than <paramref name="right"/>.
        /// </returns>
        public static bool operator <(Battery left, Battery right)
        {
            return left.level < right.level;
        }

        /// <summary>
        /// Checks if <paramref name="left"/> is less than <paramref name="right"/>.
        /// </summary>
        /// <param name="left">
        /// <see cref="Battery"/> to check.
        /// </param>
        /// <param name="right">
        /// <see cref="Battery"/> to check.
        /// </param>
        /// <returns>
        /// True if <paramref name="left"/> is more than <paramref name="right"/>.
        /// </returns>
        public static bool operator >(Battery left, Battery right)
        {
            return left.level > right.level;
        }

        /// <summary>
        /// Checks if <paramref name="left"/> is <paramref name="right"/> or more.
        /// </summary>
        /// <param name="left">
        /// <see cref="Battery"/> to check.
        /// </param>
        /// <param name="right">
        /// <see cref="Battery"/> to check.
        /// </param>
        /// <returns>
        /// True if <paramref name="left"/> is <paramref name="right"/> or more.
        /// </returns>
        public static bool operator <=(Battery left, Battery right)
        {
            return left.level <= right.level;
        }

        /// <summary>
        /// Checks if <paramref name="left"/> is <paramref name="right"/> or less.
        /// </summary>
        /// <param name="left">
        /// <see cref="Battery"/> to check.
        /// </param>
        /// <param name="right">
        /// <see cref="Battery"/> to check.
        /// </param>
        /// <returns>
        /// True if <paramref name="left"/> is <paramref name="right"/> or less.
        /// </returns>
        public static bool operator >=(Battery left, Battery right)
        {
            return left.level >= right.level;
        }
    }
}
