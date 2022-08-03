using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha.Signals
{
    /// <summary>
    /// Implementation of <see cref="ISignal"/> for <see cref="Button"/>.
    /// </summary>
    public struct Button :
        ISignal,
        IEquatable<Button>
    {
        /// <summary>
        /// <see cref="Button"/> disabled.
        /// </summary>
        public static Button None { get; } = new Button(Touch.Disabled, Push.Disabled);

        /// <summary>
        /// <see cref="Signals.Touch"/> of <see cref="Button"/>.
        /// </summary>
        public Touch Touch { get; }

        /// <summary>
        /// <see cref="Signals.Push"/> of <see cref="Button"/>.
        /// </summary>
        public Push Push { get; }

        /// <summary>
        /// Constructs instance.
        /// </summary>
        /// <param name="touch">
        /// <see cref="Signals.Touch"/> for <see cref="Button"/>.
        /// </param>
        /// <param name="push">
        /// <see cref="Signals.Push"/> for <see cref="Button."/>
        /// </param>
        public Button(Touch touch, Push push)
        {
            Touch = touch;

            Push = push;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"{nameof(Touch)}: {Touch}; {nameof(Push)}: {Push}";
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            // Visual Studio auto generated.
            var hashCode = 556604981;
            hashCode = hashCode * -1521134295 + Touch.GetHashCode();
            hashCode = hashCode * -1521134295 + Push.GetHashCode();
            return hashCode;
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj is Button signal)
            {
                return Equals(signal);
            }

            return false;
        }

        /// <inheritdoc/>
        public bool Equals(Button other)
        {
            return Touch.Equals(other.Touch)
                && Push.Equals(other.Push);
        }

        /// <summary>
        /// Converts explicitly <see cref="Signals.Touch"/> to <see cref="Button"/>.
        /// </summary>
        /// <param name="signal">
        /// <see cref="Signals.Touch"/> to covert.
        /// </param>
        /// <returns>
        /// <see cref="Button"/> converted.
        /// </returns>
        public static explicit operator Button(Touch signal)
        {
            return new Button(signal, Push.Disabled);
        }

        /// <summary>
        /// Converts explicitly <see cref="Signals.Push"/> to <see cref="Button"/>.
        /// </summary>
        /// <param name="signal">
        /// <see cref="Signals.Push"/> to covert.
        /// </param>
        /// <returns>
        /// <see cref="Button"/> converted.
        /// </returns>
        public static explicit operator Button(Push signal)
        {
            return new Button((Touch)signal, signal);
        }

        /// <summary>
        /// Checks if <see cref="Button"/> and <see cref="Button"/> are equal.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(Button left, Button right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Checks if <see cref="Button"/> and <see cref="Button"/> are not equal.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(Button left, Button right)
        {
            return !(left == right);
        }
    }
}
