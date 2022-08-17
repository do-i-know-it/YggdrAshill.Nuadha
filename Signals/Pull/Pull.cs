using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha.Signals
{
    /// <summary>
    /// Implementation of <see cref="ISignal"/> for pull.
    /// </summary>
    public struct Pull :
        ISignal,
        IEquatable<Pull>
    {
        /// <summary>
        /// Minimum <see cref="float"/> for <see cref="Pull"/>.
        /// </summary>
        public const float Minimum = 0.0f;

        /// <summary>
        /// Maximum <see cref="float"/> for <see cref="Pull"/>.
        /// </summary>
        public const float Maximum = 1.0f;

        /// <summary>
        /// Empty <see cref="Pull"/>.
        /// </summary>
        public static Pull Empty { get; } = new Pull(Minimum);

        /// <summary>
        /// Full <see cref="Pull"/>.
        /// </summary>
        public static Pull Full { get; } = new Pull(Maximum);

        private readonly float value;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="value">
        /// <see cref="float"/> for <see cref="Pull"/>.
        /// </param>
        /// <exception cref="ArgumentException">
        /// Thrown if <paramref name="value"/> is <see cref="float.NaN"/>.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown if <paramref name="value"/> is not between <see cref="Minimum"/> and <see cref="Maximum"/>.
        /// </exception>
        public Pull(float value)
        {
            if (float.IsNaN(value))
            {
                throw new ArgumentException($"{nameof(value)} is NaN.");
            }
            
            if (value < Minimum || Maximum < value)
            {
                throw new ArgumentOutOfRangeException(nameof(value));
            }

            this.value = value;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"{value}";
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return value.GetHashCode();
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj is Pull signal)
            {
                return Equals(signal);
            }

            return false;
        }

        /// <inheritdoc/>
        public bool Equals(Pull other)
        {
            return value.Equals(other.value);
        }

        /// <summary>
        /// Converts explicitly <see cref="bool"/> to <see cref="Pull"/>.
        /// </summary>
        /// <param name="signal">
        /// <see cref="bool"/> to covert.
        /// </param>
        /// <returns>
        /// <see cref="Pull"/> converted.
        /// </returns>
        public static explicit operator Pull(bool signal)
        {
            return signal ? Full : Empty;
        }

        /// <summary>
        /// Converts explicitly <see cref="float"/> to <see cref="Pull"/>.
        /// </summary>
        /// <param name="signal">
        /// <see cref="float"/> to covert.
        /// </param>
        /// <returns>
        /// <see cref="Pull"/> converted.
        /// </returns>
        public static explicit operator Pull(float signal)
        {
            if (signal <= Minimum)
            {
                return Empty;
            }

            if (Maximum <= signal)
            {
                return Full;
            }

            return new Pull(signal);
        }

        /// <summary>
        /// Converts explicitly <see cref="Pull"/> to <see cref="float"/>.
        /// </summary>
        /// <param name="signal">
        /// <see cref="Pull"/> to covert.
        /// </param>
        /// <returns>
        /// <see cref="float"/> converted.
        /// </returns>
        public static explicit operator float(Pull signal)
        {
            return signal.value;
        }

        /// <summary>
        /// Checks if <paramref name="left"/> and <paramref name="right"/> are equal.
        /// </summary>
        /// <param name="left">
        /// <see cref="Pull"/> to check.
        /// </param>
        /// <param name="right">
        /// <see cref="Pull"/> to check.
        /// </param>
        /// <returns>
        /// True if <paramref name="left"/> and <paramref name="right"/> are equal.
        /// </returns>
        public static bool operator ==(Pull left, Pull right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Checks if <paramref name="left"/> and <paramref name="right"/> are not equal.
        /// </summary>
        /// <param name="left">
        /// <see cref="Pull"/> to check.
        /// </param>
        /// <param name="right">
        /// <see cref="Pull"/> to check.
        /// </param>
        /// <returns>
        /// True if <paramref name="left"/> and <paramref name="right"/> are not equal.
        /// </returns>
        public static bool operator !=(Pull left, Pull right)
        {
            return !(left == right);
        }

        /// <summary>
        /// Checks if <paramref name="left"/> is more than <paramref name="right"/>.
        /// </summary>
        /// <param name="left">
        /// <see cref="Pull"/> to check.
        /// </param>
        /// <param name="right">
        /// <see cref="Pull"/> to check.
        /// </param>
        /// <returns>
        /// True if <paramref name="left"/> is more than <paramref name="right"/>.
        /// </returns>
        public static bool operator <(Pull left, Pull right)
        {
            return left.value < right.value;
        }

        /// <summary>
        /// Checks if <paramref name="left"/> is less than <paramref name="right"/>.
        /// </summary>
        /// <param name="left">
        /// <see cref="Pull"/> to check.
        /// </param>
        /// <param name="right">
        /// <see cref="Pull"/> to check.
        /// </param>
        /// <returns>
        /// True if <paramref name="left"/> is more than <paramref name="right"/>.
        /// </returns>
        public static bool operator >(Pull left, Pull right)
        {
            return left.value > right.value;
        }

        /// <summary>
        /// Checks if <paramref name="left"/> is <paramref name="right"/> or more.
        /// </summary>
        /// <param name="left">
        /// <see cref="Pull"/> to check.
        /// </param>
        /// <param name="right">
        /// <see cref="Pull"/> to check.
        /// </param>
        /// <returns>
        /// True if <paramref name="left"/> is <paramref name="right"/> or more.
        /// </returns>
        public static bool operator <=(Pull left, Pull right)
        {
            return left.value <= right.value;
        }

        /// <summary>
        /// Checks if <paramref name="left"/> is <paramref name="right"/> or less.
        /// </summary>
        /// <param name="left">
        /// <see cref="Pull"/> to check.
        /// </param>
        /// <param name="right">
        /// <see cref="Pull"/> to check.
        /// </param>
        /// <returns>
        /// True if <paramref name="left"/> is <paramref name="right"/> or less.
        /// </returns>
        public static bool operator >=(Pull left, Pull right)
        {
            return left.value >= right.value;
        }
    }
}
