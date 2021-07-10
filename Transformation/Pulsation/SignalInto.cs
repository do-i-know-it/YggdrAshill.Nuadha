using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha.Transformation
{
    /// <summary>
    /// Defines implementation of <see cref="IPulsation{TSignal}"/>.
    /// </summary>
    public static class SignalInto
    {
        /// <summary>
        /// Constructs <see cref="IPulsation{TSignal}"/>.
        /// </summary>
        /// <typeparam name="TSignal">
        /// Type of <see cref="ISignal"/> to be converted into <see cref="Transformation.Pulse"/>.
        /// </typeparam>
        /// <param name="detection">
        /// <see cref="IDetection{TSignal}"/> to detect.
        /// </param>
        /// <returns>
        /// <see cref="IPulsation{TSignal}"/> to convert.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="detection"/> is null.
        /// </exception>
        public static IPulsation<TSignal> Pulse<TSignal>(IDetection<TSignal> detection)
            where TSignal : ISignal
        {
            if (detection == null)
            {
                throw new ArgumentNullException(nameof(detection));
            }

            return new Pulsation<TSignal>(detection);
        }
        private sealed class Pulsation<TSignal> :
            IPulsation<TSignal>
            where TSignal : ISignal
        {
            private readonly IDetection<TSignal> detection;

            private Pulse previous = Transformation.Pulse.IsDisabled;

            internal Pulsation(IDetection<TSignal> detection)
            {
                this.detection = detection;
            }

            /// <inheritdoc/>
            public Pulse Pulsate(TSignal signal)
            {
                if (previous == Transformation.Pulse.IsDisabled || previous == Transformation.Pulse.HasDisabled)
                {
                    previous = detection.Detect(signal) ? Transformation.Pulse.HasEnabled : Transformation.Pulse.IsDisabled;
                }
                else if (previous == Transformation.Pulse.IsEnabled || previous == Transformation.Pulse.HasEnabled)
                {
                    previous = detection.Detect(signal) ? Transformation.Pulse.IsEnabled : Transformation.Pulse.HasDisabled;
                }

                return previous;
            }
        }
    }
}
