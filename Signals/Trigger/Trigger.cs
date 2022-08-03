using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha.Signals
{
    /// <summary>
    /// Implementation of <see cref="ISignal"/> for <see cref="Trigger"/>.
    /// </summary>
    public struct Trigger :
        ISignal,
        IEquatable<Trigger>
    {
        /// <summary>
        /// <see cref="Trigger"/> disabled.
        /// </summary>
        public static Trigger None { get; } = new Trigger(Touch.Disabled, Pull.Released);

        /// <summary>
        /// <see cref="Signals.Touch"/> of <see cref="Trigger"/>.
        /// </summary>
        public Touch Touch { get; }

        /// <summary>
        /// <see cref="Signals.Pull"/> of <see cref="Trigger"/>.
        /// </summary>
        public Pull Pull { get; }

        /// <summary>
        /// Constructs instance.
        /// </summary>
        /// <param name="touch">
        /// <see cref="Signals.Touch"/> for <see cref="Trigger"/>.
        /// </param>
        /// <param name="pull">
        /// <see cref="Signals.Pull"/> for <see cref="Trigger"/>.
        /// </param>
        public Trigger(Touch touch, Pull pull)
        {
            Touch = touch;

            Pull = pull;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"{nameof(Touch)}: {Touch}; {nameof(Pull)}: {Pull}";
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            // Visual Studio auto generated.
            var hashCode = 451555030;
            hashCode = hashCode * -1521134295 + Touch.GetHashCode();
            hashCode = hashCode * -1521134295 + Pull.GetHashCode();
            return hashCode;
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj is Trigger signal)
            {
                return Equals(signal);
            }

            return false;
        }

        /// <inheritdoc/>
        public bool Equals(Trigger other)
        {
            return Touch.Equals(other.Touch)
                && Pull.Equals(other.Pull);
        }

        /// <summary>
        /// Converts explicitly <see cref="Signals.Touch"/> to <see cref="Trigger"/>.
        /// </summary>
        /// <param name="signal">
        /// <see cref="Signals.Touch"/> to covert.
        /// </param>
        /// <returns>
        /// <see cref="Trigger"/> converted.
        /// </returns>
        public static explicit operator Trigger(Touch signal)
        {
            return new Trigger(signal, Pull.Released);
        }

        /// <summary>
        /// Checks if <see cref="Trigger"/> and <see cref="Trigger"/> are equal.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(Trigger left, Trigger right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Checks if <see cref="Trigger"/> and <see cref="Trigger"/> are not equal.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(Trigger left, Trigger right)
        {
            return !(left == right);
        }
    }
}
