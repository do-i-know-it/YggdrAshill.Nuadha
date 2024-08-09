using System;
using YggdrAshill.Nuadha.Signalization;

namespace YggdrAshill.Nuadha.Evaluation
{
    /// <summary>
    /// Implementation of <see cref="ISignal"/> for edge.
    /// </summary>
    public readonly struct Edge : ISignal, IEquatable<Edge>
    {
        /// <summary>
        /// Negative value of <see cref="Edge"/>.
        /// </summary>
        public static Edge Negative { get; } = new(false);

        /// <summary>
        /// Positive value of <see cref="Edge"/>.
        /// </summary>
        public static Edge Positive { get; } = new(true);

        private readonly bool value;

        private Edge(bool value)
        {
            this.value = value;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return value ? nameof(Positive) : nameof(Negative);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return value.GetHashCode();
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is Edge signal)
            {
                return Equals(signal);
            }

            return false;
        }

        /// <inheritdoc/>
        public bool Equals(Edge other)
        {
            return value.Equals(other.value);
        }

        /// <summary>
        /// Converts explicitly <see cref="bool"/> to <see cref="Edge"/>.
        /// </summary>
        /// <param name="signal">
        /// <see cref="bool"/> to covert.
        /// </param>
        /// <returns>
        /// <see cref="Edge"/> converted.
        /// </returns>
        public static explicit operator Edge(bool signal)
        {
            return signal ? Positive : Negative;
        }

        /// <summary>
        /// Converts explicitly <see cref="Edge"/> to <see cref="bool"/>.
        /// </summary>
        /// <param name="signal">
        /// <see cref="Edge"/> to covert.
        /// </param>
        /// <returns>
        /// <see cref="bool"/> converted.
        /// </returns>
        public static explicit operator bool(Edge signal)
        {
            return signal.value;
        }

        /// <summary>
        /// Checks if <paramref name="left"/> and <paramref name="right"/> are equal.
        /// </summary>
        /// <param name="left">
        /// <see cref="Edge"/> to check.
        /// </param>
        /// <param name="right">
        /// <see cref="Edge"/> to check.
        /// </param>
        /// <returns>
        /// True if <paramref name="left"/> and <paramref name="right"/> are equal.
        /// </returns>
        public static bool operator ==(Edge left, Edge right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Checks if <paramref name="left"/> and <paramref name="right"/> are not equal.
        /// </summary>
        /// <param name="left">
        /// <see cref="Edge"/> to check.
        /// </param>
        /// <param name="right">
        /// <see cref="Edge"/> to check.
        /// </param>
        /// <returns>
        /// True if <paramref name="left"/> and <paramref name="right"/> are not equal.
        /// </returns>
        public static bool operator !=(Edge left, Edge right)
        {
            return !(left == right);
        }
    }
}
