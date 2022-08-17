using YggdrAshill.Nuadha.Signalization;

namespace YggdrAshill.Nuadha.Signals
{
    /// <summary>
    /// Implementation of <see cref="ISignal"/> for stick.
    /// </summary>
    public struct Stick :
        ISignal
    {
        /// <summary>
        /// Default <see cref="Stick"/>.
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
        /// Constructor.
        /// </summary>
        /// <param name="touch">
        /// <see cref="Signals.Touch"/> for <see cref="Touch"/>.
        /// </param>
        /// <param name="push">
        /// <see cref="Signals.Push"/> for <see cref="Push"/>.
        /// </param>
        /// <param name="tilt">
        /// <see cref="Signals.Tilt"/> for <see cref="Tilt"/>.
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
            return $"({Touch}), ({Push}), ({Tilt})";
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
    }
}
