using YggdrAshill.Nuadha.Signalization;

namespace YggdrAshill.Nuadha.Signals
{
    /// <summary>
    /// Implementation of <see cref="ISignal"/> for button.
    /// </summary>
    public struct Button :
        ISignal
    {
        /// <summary>
        /// Default <see cref="Button"/>.
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
        /// Constructor.
        /// </summary>
        /// <param name="touch">
        /// <see cref="Signals.Touch"/> for <see cref="Touch"/>.
        /// </param>
        /// <param name="push">
        /// <see cref="Signals.Push"/> for <see cref="Push."/>
        /// </param>
        public Button(Touch touch, Push push)
        {
            Touch = touch;

            Push = push;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"({Touch}), ({Push})";
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
        /// Converts explicitly <see cref="Button"/> to <see cref="Trigger"/>.
        /// </summary>
        /// <param name="signal">
        /// <see cref="Button"/> to covert.
        /// </param>
        /// <returns>
        /// <see cref="Trigger"/> converted.
        /// </returns>
        public static explicit operator Trigger(Button signal)
        {
            return new Trigger(signal.Touch, (Pull)signal.Push);
        }
    }
}
