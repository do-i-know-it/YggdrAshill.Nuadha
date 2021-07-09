using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha.Transformation
{
    /// <summary>
    /// Implementation of <see cref="IPulsation{TSignal}"/>.
    /// </summary>
    /// <typeparam name="TSignal">
    /// Type of <see cref="ISignal"/> to convert.
    /// </typeparam>
    public sealed class IntoPulseFrom<TSignal> :
        IPulsation<TSignal>
        where TSignal : ISignal
    {
        /// <summary>
        /// Constructs <see cref="IntoPulseFrom{TSignal}"/> with <see cref="IDetection{TSignal}"/>.
        /// </summary>
        /// <param name="detection">
        /// <see cref="IDetection{TSignal}"/> to detect.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="detection"/> is null.
        /// </exception>
        public static IntoPulseFrom<TSignal> With(IDetection<TSignal> detection)
        {
            if (detection == null)
            {
                throw new ArgumentNullException(nameof(detection));
            }

            return new IntoPulseFrom<TSignal>(detection);
        }

        private readonly IDetection<TSignal> detection;

        private Pulse previous = Pulse.IsDisabled;

        private IntoPulseFrom(IDetection<TSignal> detection)
        {
            this.detection = detection;
        }

        /// <inheritdoc/>
        public Pulse Pulsate(TSignal signal)
        {
            if (previous == Pulse.IsDisabled || previous == Pulse.HasDisabled)
            {
                previous = detection.Detect(signal) ? Pulse.HasEnabled : Pulse.IsDisabled;
            }
            else if (previous == Pulse.IsEnabled || previous == Pulse.HasEnabled)
            {
                previous = detection.Detect(signal) ? Pulse.IsEnabled : Pulse.HasDisabled;
            }

            return previous;
        }
    }
}
