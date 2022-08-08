using YggdrAshill.Nuadha.Signalization;

namespace YggdrAshill.Nuadha.Signals
{
    /// <summary>
    /// Implementation of <see cref="ISignal"/> for trigger.
    /// </summary>
    public struct Trigger :
        ISignal
    {
        /// <summary>
        /// Defaualt <see cref="Trigger"/>.
        /// </summary>
        public static Trigger None { get; } = new Trigger(Touch.Disabled, Pull.Empty);

        /// <summary>
        /// <see cref="Signals.Touch"/> of <see cref="Trigger"/>.
        /// </summary>
        public Touch Touch { get; }

        /// <summary>
        /// <see cref="Signals.Pull"/> of <see cref="Trigger"/>.
        /// </summary>
        public Pull Pull { get; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="touch">
        /// <see cref="Signals.Touch"/> for <see cref="Touch"/>.
        /// </param>
        /// <param name="pull">
        /// <see cref="Signals.Pull"/> for <see cref="Pull"/>.
        /// </param>
        public Trigger(Touch touch, Pull pull)
        {
            Touch = touch;

            Pull = pull;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"({Touch}), ({Pull})";
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
            return new Trigger(signal, Pull.Empty);
        }
    }
}
