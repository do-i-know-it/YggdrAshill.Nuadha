using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha.Signals
{
    /// <summary>
    /// Implementation of <see cref="ISignal"/> for <see cref="Touch"/>.
    /// </summary>
    public struct Touch :
        ISignal,
        IEquatable<Touch>
    {
        /// <summary>
        /// <see cref="Touch"/> that is disabled.
        /// </summary>
        public static Touch Disabled { get; } = new Touch(false);

        /// <summary>
        /// <see cref="Touch"/> that is enabled.
        /// </summary>
        public static Touch Enabled { get; } = new Touch(true);

        private readonly bool value;

        private Touch(bool value)
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

            if (obj is Touch signal)
            {
                return Equals(signal);
            }

            return false;
        }

        /// <inheritdoc/>
        public bool Equals(Touch other)
        {
            return value.Equals(other.value);
        }

        /// <summary>
        /// Converts explicitly <see cref="bool"/> to <see cref="Touch"/>.
        /// </summary>
        /// <param name="signal">
        /// <see cref="bool"/> to covert.
        /// </param>
        /// <returns>
        /// <see cref="Touch"/> converted.
        /// </returns>
        public static explicit operator Touch(bool signal)
        {
            return signal ? Enabled : Disabled;
        }

        /// <summary>
        /// Converts explicitly <see cref="Touch"/> to <see cref="bool"/>.
        /// </summary>
        /// <param name="signal">
        /// <see cref="Touch"/> to covert.
        /// </param>
        /// <returns>
        /// <see cref="bool"/> converted.
        /// </returns>
        public static explicit operator bool(Touch signal)
        {
            return signal.value;
        }

        /// <summary>
        /// Converts <see cref="Touch"/> to <see cref="bool"/> in an expression.
        /// </summary>
        /// <param name="signal">
        /// <see cref="Touch"/> to covert.
        /// </param>
        /// <returns>
        /// <see cref="bool"/> converted.
        /// </returns>
        public static bool operator true(Touch signal)
        {
            return (bool)signal;
        }

        /// <summary>
        /// Converts <see cref="Touch"/> to <see cref="bool"/> in an expression.
        /// </summary>
        /// <param name="signal">
        /// <see cref="Touch"/> to covert.
        /// </param>
        /// <returns>
        /// <see cref="bool"/> converted.
        /// </returns>
        public static bool operator false(Touch signal)
        {
            return !(bool)signal;
        }

        /// <summary>
        /// Inverses <see cref="Touch"/>.
        /// </summary>
        /// <param name="signal">
        /// <see cref="Touch"/> to inverse.
        /// </param>
        /// <returns>
        /// <see cref="Touch"/> inversed.
        /// </returns>
        public static Touch operator -(Touch signal)
        {
            return signal.value? Disabled : Enabled;
        }

        /// <summary>
        /// Checks if <see cref="Touch"/> and <see cref="Touch"/> are equal.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(Touch left, Touch right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Checks if <see cref="Touch"/> and <see cref="Touch"/> are not equal.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(Touch left, Touch right)
        {
            return !(left == right);
        }
    }
}
