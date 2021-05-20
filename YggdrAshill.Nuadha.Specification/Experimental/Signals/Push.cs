using YggdrAshill.Nuadha.Signalization.Experimental;
using System;

namespace YggdrAshill.Nuadha.Signals.Experimental
{
    /// <summary>
    /// Implementation of <see cref="ISignal"/> to describe push.
    /// </summary>
    public struct Push :
        ISignal,
        IEquatable<Push>
    {
        /// <summary>
        /// <see cref="Push"/> that is disabled.
        /// </summary>
        public static Push Disabled { get; } = new Push(State.Disabled);

        /// <summary>
        /// <see cref="Push"/> that is enabled.
        /// </summary>
        public static Push Enabled { get; } = new Push(State.Enabled);

        private enum State
        {
            Disabled = 0,
            Enabled = 1,
        }

        private readonly State state;

        private Push(State state)
        {
            this.state = state;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"{state}";
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return (int)state;
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj is Push signal)
            {
                return Equals(signal);
            }

            return false;
        }

        /// <inheritdoc/>
        public bool Equals(Push other)
        {
            return state.Equals(other.state);
        }

        /// <summary>
        /// Converts explicitly <see cref="bool"/> to <see cref="Push"/>.
        /// </summary>
        /// <param name="signal">
        /// <see cref="bool"/> to covert.
        /// </param>
        /// <returns>
        /// <see cref="Push"/> converted.
        /// </returns>
        public static explicit operator Push(bool signal)
        {
            return signal ? Enabled : Disabled;
        }

        /// <summary>
        /// Converts explicitly <see cref="Push"/> to <see cref="bool"/>.
        /// </summary>
        /// <param name="signal">
        /// <see cref="Push"/> to covert.
        /// </param>
        /// <returns>
        /// <see cref="bool"/> converted.
        /// </returns>
        public static explicit operator bool(Push signal)
        {
            return signal == Enabled;
        }

        /// <summary>
        /// Converts <see cref="Push"/> to <see cref="bool"/> in an expression.
        /// </summary>
        /// <param name="signal"></param>
        /// <returns></returns>
        public static bool operator true(Push signal)
        {
            return (bool)signal;
        }

        /// <summary>
        /// Converts <see cref="Push"/> to <see cref="bool"/> in an expression.
        /// </summary>
        /// <param name="signal"></param>
        /// <returns></returns>
        public static bool operator false(Push signal)
        {
            return !(bool)signal;
        }

        /// <summary>
        /// Checks if <see cref="Push"/> and <see cref="Push"/> are equal.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(Push left, Push right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Checks if <see cref="Push"/> and <see cref="Push"/> are not equal.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(Push left, Push right)
        {
            return !(left == right);
        }
    }
}
