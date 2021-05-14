using System;

namespace YggdrAshill.Nuadha.Transformation.Experimental
{
    /// <summary>
    /// Implementation of <see cref="IDetection{TSignal}"/> for <see cref="Pulse"/>.
    /// </summary>
    public sealed class WhenPulse :
        IDetection<Pulse>
    {
        /// <summary>
        /// Detects when <see cref="Pulse"/> is <see cref="Pulse.IsDisabled"/>.
        /// </summary>
        public static WhenPulse IsDisabled { get; } = new WhenPulse(Pulse.IsDisabled);
        /// <summary>
        /// Detects when <see cref="Pulse"/> is <see cref="Pulse.HasDisabled"/>.
        /// </summary>
        public static WhenPulse HasDisabled { get; } = new WhenPulse(Pulse.HasDisabled);
        /// <summary>
        /// Detects when <see cref="Pulse"/> is <see cref="Pulse.IsEnabled"/>.
        /// </summary>
        public static WhenPulse IsEnabled { get; } = new WhenPulse(Pulse.IsEnabled);
        /// <summary>
        /// Detects when <see cref="Pulse"/> is <see cref="Pulse.HasEnabled"/>.
        /// </summary>
        public static WhenPulse HasEnabled { get; } = new WhenPulse(Pulse.HasEnabled);

        private readonly Pulse expected;

        private WhenPulse(Pulse expected)
        {
            this.expected = expected;
        }

        /// <inheritdoc/>
        public bool Detect(Pulse signal)
        {
            if (signal == null)
            {
                throw new ArgumentNullException(nameof(signal));
            }

            return expected == signal;
        }
    }
}
