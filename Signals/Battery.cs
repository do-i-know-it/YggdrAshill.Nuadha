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
        /// <see cref="Empty"/> of <see cref="Battery"/>.
        /// </summary>
        public const float Empty = 0.0f;

        /// <summary>
        /// <see cref="Full"/> of <see cref="Battery"/>.
        /// </summary>
        public const float Full = 1.0f;

        private readonly float level;

        /// <summary>
        /// Construcs instance.
        /// </summary>
        /// <param name="level">
        /// <see cref="float"/> for <see cref="Battery"/>
        /// </param>
        /// <exception cref="ArgumentException">
        /// Thrown if <paramref name="level"/> is <see cref="float.NaN"/>.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown if <paramref name="level"/> is out of range between <see cref="Empty"/> and <see cref="Full"/>.
        /// </exception>
        public Battery(float level)
        {
            if (float.IsNaN(level))
            {
                throw new ArgumentException($"{nameof(level)} is NaN.");
            }

            if (level < Empty || Full < level)
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
    }
}
