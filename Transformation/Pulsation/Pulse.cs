using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha.Transformation
{
    /// <summary>
    /// Implementation of <see cref="ISignal"/>.
    /// </summary>
    public sealed class Pulse :
        ISignal,
        IEquatable<Pulse>
    {
        private enum State
        {
            IsDisabled,
            HasDisabled,
            IsEnabled,
            HasEnabled,
        }

        private readonly State state;

        private Pulse(State state)
        {
            this.state = state;
        }

        /// <summary>
        /// <see cref="Pulse"/> that is disabled.
        /// </summary>
        public static Pulse IsDisabled { get; } = new Pulse(State.IsDisabled);
        /// <summary>
        /// <see cref="Pulse"/> that has disabled.
        /// </summary>
        public static Pulse HasDisabled { get; } = new Pulse(State.HasDisabled);
        /// <summary>
        /// <see cref="Pulse"/> that is enabled.
        /// </summary>
        public static Pulse IsEnabled { get; } = new Pulse(State.IsEnabled);
        /// <summary>
        /// <see cref="Pulse"/> that has enabled.
        /// </summary>
        public static Pulse HasEnabled { get; } = new Pulse(State.HasEnabled);

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
            if (ReferenceEquals(obj, null))
            {
                return false;
            }

            if (obj is Pulse pulse)
            {
                return Equals(pulse);
            }

            return false;
        }
        /// <inheritdoc/>
        public bool Equals(Pulse other)
        {
            if (ReferenceEquals(other, null))
            {
                return false;
            }

            return state.Equals(other.state);
        }

        /// <summary>
        /// Checks if <see cref="Pulse"/> and <see cref="Pulse"/> are equal.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(Pulse left, Pulse right)
        {
            if (ReferenceEquals(left, null))
            {
                return ReferenceEquals(right, null);
            }

            if (ReferenceEquals(right, null))
            {
                return false;
            }

            return left.Equals(right);
        }
        /// <summary>
        /// Checks if <see cref="Pulse"/> and <see cref="Pulse"/> are not equal.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(Pulse left, Pulse right)
        {
            return !(left == right);
        }
    }
}