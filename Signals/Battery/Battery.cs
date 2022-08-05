using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha.Signals
{
    /// <summary>
    /// Implementation of <see cref="ISignal"/> for <see cref="Battery"/>.
    /// </summary>
    public struct Battery :
        ISignal,
        IEquatable<Battery>
    {
        /// <summary>
        /// <see cref="Minimum"/> for <see cref="Battery"/>.
        /// </summary>
        public const float Minimum = 0.0f;

        /// <summary>
        /// <see cref="Maximum"/> for <see cref="Battery"/>.
        /// </summary>
        public const float Maximum = 1.0f;

        /// <summary>
        /// <see cref="Battery"/> that is <see cref="Minimum"/>.
        /// </summary>
        public static Battery Empty { get; } = new Battery(Minimum);

        /// <summary>
        /// <see cref="Battery"/> that is <see cref="Maximum"/>.
        /// </summary>
        public static Battery Full { get; } = new Battery(Maximum);

        private readonly float level;

        /// <summary>
        /// Constructs instance.
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
            if (signal < Minimum)
            {
                return Empty;
            }
            if (signal > Maximum)
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
        /// Checks if <see cref="Battery"/> and <see cref="Battery"/> are equal.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(Battery left, Battery right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Checks if <see cref="Battery"/> and <see cref="Battery"/> are not equal.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(Battery left, Battery right)
        {
            return !(left == right);
        }

        /// <summary>
        /// Checks if one <see cref="Battery"/> is over another <see cref="Battery"/>.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator <(Battery left, Battery right)
        {
            return left.level < right.level;
        }

        /// <summary>
        /// Checks if one <see cref="Battery"/> is under another <see cref="Battery"/>.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator >(Battery left, Battery right)
        {
            return left.level > right.level;
        }

        /// <summary>
        /// Checks if one <see cref="Battery"/> is over another <see cref="Battery"/>.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator <=(Battery left, Battery right)
        {
            return left.level <= right.level;
        }

        /// <summary>
        /// Checks if one <see cref="Battery"/> is under another <see cref="Battery"/>.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator >=(Battery left, Battery right)
        {
            return left.level >= right.level;
        }
    }
}
