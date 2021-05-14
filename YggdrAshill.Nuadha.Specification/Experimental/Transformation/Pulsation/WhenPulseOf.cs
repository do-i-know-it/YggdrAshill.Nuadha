using YggdrAshill.Nuadha.Signalization.Experimental;
using System;

namespace YggdrAshill.Nuadha.Transformation.Experimental
{
    /// <summary>
    /// Implementaion of <see cref="IDetection{TSignal}"/> with <see cref="IPulsation{TSignal}"/>.
    /// </summary>
    /// <typeparam name="TSignal">
    /// Type of <see cref="ISignal"/> to detect.
    /// </typeparam>
    public sealed class WhenPulseOf<TSignal> :
        IDetection<TSignal>
        where TSignal : ISignal
    {
        /// <summary>
        /// Detects when <see cref="Pulse"/> converted from <typeparamref name="TSignal"/> is <see cref="Pulse.IsDisabled"/>.
        /// </summary>
        /// <param name="pulsation">
        /// <see cref="IPulsation{TSignal}"/> to convert <typeparamref name="TSignal"/> to <see cref="Pulse"/>.
        /// </param>
        /// <returns>
        /// <see cref="WhenPulseOf{TSignal}"/> to detect <typeparamref name="TSignal"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="pulsation"/> is null.
        /// </exception>
        public static WhenPulseOf<TSignal> IsDisabled(IPulsation<TSignal> pulsation)
        {
            if (pulsation == null)
            {
                throw new ArgumentNullException(nameof(pulsation));
            }

            return new WhenPulseOf<TSignal>(pulsation, WhenPulse.IsDisabled);
        }
        /// <summary>
        /// Detects when <see cref="Pulse"/> converted from <typeparamref name="TSignal"/> is <see cref="Pulse.HasDisabled"/>.
        /// </summary>
        /// <param name="pulsation">
        /// <see cref="IPulsation{TSignal}"/> to convert <typeparamref name="TSignal"/> to <see cref="Pulse"/>.
        /// </param>
        /// <returns>
        /// <see cref="WhenPulseOf{TSignal}"/> to detect <typeparamref name="TSignal"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="pulsation"/> is null.
        /// </exception>
        public static WhenPulseOf<TSignal> HasDisabled(IPulsation<TSignal> pulsation)
        {
            if (pulsation == null)
            {
                throw new ArgumentNullException(nameof(pulsation));
            }

            return new WhenPulseOf<TSignal>(pulsation, WhenPulse.HasDisabled);
        }
        /// <summary>
        /// Detects when <see cref="Pulse"/> converted from <typeparamref name="TSignal"/> is <see cref="Pulse.IsDisabled"/>.
        /// </summary>
        /// <param name="pulsation">
        /// <see cref="IPulsation{TSignal}"/> to convert <typeparamref name="TSignal"/> to <see cref="Pulse"/>.
        /// </param>
        /// <returns>
        /// <see cref="WhenPulseOf{TSignal}"/> to detect <typeparamref name="TSignal"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="pulsation"/> is null.
        /// </exception>
        public static WhenPulseOf<TSignal> IsEnabled(IPulsation<TSignal> pulsation)
        {
            if (pulsation == null)
            {
                throw new ArgumentNullException(nameof(pulsation));
            }

            return new WhenPulseOf<TSignal>(pulsation, WhenPulse.IsEnabled);
        }
        /// <summary>
        /// Detects when <see cref="Pulse"/> converted from <typeparamref name="TSignal"/> is <see cref="Pulse.IsDisabled"/>.
        /// </summary>
        /// <param name="pulsation">
        /// <see cref="IPulsation{TSignal}"/> to convert <typeparamref name="TSignal"/> to <see cref="Pulse"/>.
        /// </param>
        /// <returns>
        /// <see cref="WhenPulseOf{TSignal}"/> to detect <typeparamref name="TSignal"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="pulsation"/> is null.
        /// </exception>
        public static WhenPulseOf<TSignal> HasEnabled(IPulsation<TSignal> pulsation)
        {
            if (pulsation == null)
            {
                throw new ArgumentNullException(nameof(pulsation));
            }

            return new WhenPulseOf<TSignal>(pulsation, WhenPulse.HasEnabled);
        }

        private readonly IPulsation<TSignal> pulsation;

        private readonly IDetection<Pulse> detection;

        private WhenPulseOf(IPulsation<TSignal> pulsation, IDetection<Pulse> detection)
        {
            this.pulsation = pulsation;

            this.detection = detection;
        }

        /// <inheritdoc/>
        public bool Detect(TSignal signal)
        {
            var pulse = pulsation.Pulsate(signal);

            return detection.Detect(pulse);
        }
    }
}
