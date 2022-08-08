using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha.Signals
{
    /// <summary>
    /// Implementation of <see cref="ISignal"/> for push.
    /// </summary>
    public struct Push :
        ISignal,
        IEquatable<Push>
    {
        /// <summary>
        /// <see cref="Push"/> that is disabled.
        /// </summary>
        public static Push Disabled { get; } = new Push(false);

        /// <summary>
        /// <see cref="Push"/> that is enabled.
        /// </summary>
        public static Push Enabled { get; } = new Push(true);

        private readonly bool value;

        private Push(bool value)
        {
            this.value = value;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return value ? nameof(Enabled) : nameof(Disabled);
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

            if (obj is Push signal)
            {
                return Equals(signal);
            }

            return false;
        }

        /// <inheritdoc/>
        public bool Equals(Push other)
        {
            return value.Equals(other.value);
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
            return signal.value;
        }

        /// <summary>
        /// Converts explicitly <see cref="Push"/> to <see cref="Touch"/>.
        /// </summary>
        /// <param name="signal">
        /// <see cref="Push"/> to covert.
        /// </param>
        /// <returns>
        /// <see cref="Touch"/> converted.
        /// </returns>
        public static explicit operator Touch(Push signal)
        {
            return (Touch)signal.value;
        }

        /// <summary>
        /// Converts explicitly <see cref="Push"/> to <see cref="Pull"/>.
        /// </summary>
        /// <param name="signal">
        /// <see cref="Push"/> to covert.
        /// </param>
        /// <returns>
        /// <see cref="Pull"/> converted.
        /// </returns>
        public static explicit operator Pull(Push signal)
        {
            return signal ? Pull.Full : Pull.Empty;
        }

        /// <summary>
        /// Converts <see cref="Push"/> to <see cref="bool"/> in an expression.
        /// </summary>
        /// <param name="signal">
        /// <see cref="Push"/> to covert.
        /// </param>
        /// <returns>
        /// <see cref="bool"/> converted.
        /// </returns>
        public static bool operator true(Push signal)
        {
            return (bool)signal;
        }

        /// <summary>
        /// Converts <see cref="Push"/> to <see cref="bool"/> in an expression.
        /// </summary>
        /// <param name="signal">
        /// <see cref="Push"/> to covert.
        /// </param>
        /// <returns>
        /// <see cref="bool"/> converted.
        /// </returns>
        public static bool operator false(Push signal)
        {
            return !(bool)signal;
        }

        /// <summary>
        /// Inverses <see cref="Push"/>.
        /// </summary>
        /// <param name="signal">
        /// <see cref="Push"/> to inverse.
        /// </param>
        /// <returns>
        /// <see cref="Push"/> inversed.
        /// </returns>
        public static Push operator -(Push signal)
        {
            return signal.value ? Disabled : Enabled;
        }

        /// <summary>
        /// Checks if <paramref name="left"/> and <paramref name="right"/> are equal.
        /// </summary>
        /// <param name="left">
        /// <see cref="Push"/> to check.
        /// </param>
        /// <param name="right">
        /// <see cref="Push"/> to check.
        /// </param>
        /// <returns>
        /// True if <paramref name="left"/> and <paramref name="right"/> are equal.
        /// </returns>
        public static bool operator ==(Push left, Push right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Checks if <paramref name="left"/> and <paramref name="right"/> are not equal.
        /// </summary>
        /// <param name="left">
        /// <see cref="Push"/> to check.
        /// </param>
        /// <param name="right">
        /// <see cref="Push"/> to check.
        /// </param>
        /// <returns>
        /// True if <paramref name="left"/> and <paramref name="right"/> are not equal.
        /// </returns>
        public static bool operator !=(Push left, Push right)
        {
            return !(left == right);
        }
    }
}
