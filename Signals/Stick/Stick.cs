using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha.Signals
{
    /// <summary>
    /// Implementation of <see cref="ISignal"/> for <see cref="Stick"/>.
    /// </summary>
    public struct Stick :
        ISignal,
        IEquatable<Stick>
    {
        /// <summary>
        /// <see cref="Stick"/> disabled.
        /// </summary>
        public static Stick None { get; } = new Stick(Touch.Disabled, Push.Disabled, Tilt.Origin);

        /// <summary>
        /// <see cref="Signals.Touch"/> of <see cref="Stick"/>.
        /// </summary>
        public Touch Touch { get; }

        /// <summary>
        /// <see cref="Signals.Push"/> of <see cref="Stick"/>.
        /// </summary>
        public Push Push { get; }

        /// <summary>
        /// <see cref="Signals.Tilt"/> of <see cref="Stick"/>.
        /// </summary>
        public Tilt Tilt { get; }

        /// <summary>
        /// Constructs instance.
        /// </summary>
        /// <param name="touch">
        /// <see cref="Signals.Touch"/> for <see cref="Stick"/>.
        /// </param>
        /// <param name="push">
        /// <see cref="Signals.Push"/> for <see cref="Stick"/>.
        /// </param>
        /// <param name="tilt">
        /// <see cref="Signals.Tilt"/> for <see cref="Stick"/>.
        /// </param>
        public Stick(Touch touch, Push push, Tilt tilt)
        {
            Touch = touch;

            Push = push;

            Tilt = tilt;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"{nameof(Touch)}: {Touch}; {nameof(Push)}: {Push}; {nameof(Tilt)}: {Tilt}";
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            // Visual Studio auto generated.
            var hashCode = 1589348003;
            hashCode = hashCode * -1521134295 + Touch.GetHashCode();
            hashCode = hashCode * -1521134295 + Push.GetHashCode();
            hashCode = hashCode * -1521134295 + Tilt.GetHashCode();
            return hashCode;
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj is Stick signal)
            {
                return Equals(signal);
            }

            return false;
        }

        /// <inheritdoc/>
        public bool Equals(Stick other)
        {
            return Touch.Equals(other.Touch)
                && Push.Equals(other.Push)
                && Tilt.Equals(other.Tilt);
        }

        /// <summary>
        /// Converts explicitly <see cref="Signals.Touch"/> to <see cref="Stick"/>.
        /// </summary>
        /// <param name="signal">
        /// <see cref="Signals.Touch"/> to covert.
        /// </param>
        /// <returns>
        /// <see cref="Stick"/> converted.
        /// </returns>
        public static explicit operator Stick(Touch signal)
        {
            return new Stick(signal, Push.Disabled, Tilt.Origin);
        }

        /// <summary>
        /// Converts explicitly <see cref="Signals.Push"/> to <see cref="Stick"/>.
        /// </summary>
        /// <param name="signal">
        /// <see cref="Signals.Push"/> to covert.
        /// </param>
        /// <returns>
        /// <see cref="Stick"/> converted.
        /// </returns>
        public static explicit operator Stick(Push signal)
        {
            return new Stick((Touch)signal, signal, Tilt.Origin);
        }

        /// <summary>
        /// Checks if <see cref="Stick"/> and <see cref="Stick"/> are equal.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(Stick left, Stick right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Checks if <see cref="Stick"/> and <see cref="Stick"/> are not equal.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(Stick left, Stick right)
        {
            return !(left == right);
        }
    }
}
