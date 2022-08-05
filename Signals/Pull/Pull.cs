using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha.Signals
{
    /// <summary>
    /// Implementation of <see cref="ISignal"/> for <see cref="Pull"/>.
    /// </summary>
    public struct Pull :
        ISignal,
        IEquatable<Pull>
    {
        /// <summary>
        /// <see cref="Minimum"/> for <see cref="Pull"/>.
        /// </summary>
        public const float Minimum = 0.0f;

        /// <summary>
        /// <see cref="Maximum"/> for <see cref="Pull"/>.
        /// </summary>
        public const float Maximum = 1.0f;

        /// <summary>
        /// <see cref="Empty"/> of <see cref="Pull"/>.
        /// </summary>
        public static Pull Empty { get; } = new Pull(Minimum);

        /// <summary>
        /// <see cref="Full"/> of <see cref="Pull"/>.
        /// </summary>
        public static Pull Full { get; } = new Pull(Maximum);

        private readonly float value;

        /// <summary>
        /// Constructs instance.
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
            if (signal < Minimum)
            {
                return Empty;
            }

            if (signal > Maximum)
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
        /// Checks if <see cref="Pull"/> and <see cref="Pull"/> are equal.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(Pull left, Pull right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Checks if <see cref="Pull"/> and <see cref="Pull"/> are not equal.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(Pull left, Pull right)
        {
            return !(left == right);
        }

        /// <summary>
        /// Checks if one <see cref="Pull"/> is over another <see cref="Pull"/>.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator <(Pull left, Pull right)
        {
            return left.value < right.value;
        }

        /// <summary>
        /// Checks if one <see cref="Pull"/> is under another <see cref="Pull"/>.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator >(Pull left, Pull right)
        {
            return left.value > right.value;
        }

        /// <summary>
        /// Checks if one <see cref="Pull"/> is over another <see cref="Pull"/>.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator <=(Pull left, Pull right)
        {
            return left.value <= right.value;
        }

        /// <summary>
        /// Checks if one <see cref="Pull"/> is under another <see cref="Pull"/>.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator >=(Pull left, Pull right)
        {
            return left.value >= right.value;
        }
    }
}
