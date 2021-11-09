using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Defines extensions for <see cref="PulsatedTilt"/>.
    /// </summary>
    public static class PulsatedTiltExtension
    {
        [Obsolete("Please use PulsatedTiltExtension.Pulsate instead.")]
        public static IConnection<IPulsatedTiltSoftware> Convert(this IProduction<Tilt> production, TiltThreshold threshold)
        {
            return production.Pulsate(threshold);
        }

        /// <summary>
        /// Converts <see cref="IProduction{TSignal}"/> for <see cref="Tilt"/> into <see cref="IConnection{TModule}"/> for <see cref="IPulsatedTiltSoftware"/>.
        /// </summary>
        /// <param name="production">
        /// <see cref="IProduction{TSignal}"/> for <see cref="Tilt"/> to convert.
        /// </param>
        /// <param name="threshold">
        /// <see cref="TiltThreshold"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="IConnection{TModule}"/> to connect <see cref="IPulsatedTiltSoftware"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="production"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="threshold"/> is null.
        /// </exception>
        public static IConnection<IPulsatedTiltSoftware> Pulsate(this IProduction<Tilt> production, TiltThreshold threshold)
        {
            if (production == null)
            {
                throw new ArgumentNullException(nameof(production));
            }
            if (threshold == null)
            {
                throw new ArgumentNullException(nameof(threshold));
            }

            return new ConnectPulsatedTilt(production, threshold);
        }
        private sealed class ConnectPulsatedTilt :
            IConnection<IPulsatedTiltSoftware>
        {
            private readonly IProduction<Pulse> distance;

            private readonly IProduction<Pulse> left;

            private readonly IProduction<Pulse> right;

            private readonly IProduction<Pulse> forward;

            private readonly IProduction<Pulse> backward;

            internal ConnectPulsatedTilt(IProduction<Tilt> production, TiltThreshold threshold)
            {
                if (production == null)
                {
                    throw new ArgumentNullException(nameof(production));
                }
                if (threshold == null)
                {
                    throw new ArgumentNullException(nameof(threshold));
                }

                distance = production.Convert(TiltInto.PulseBy.Distance(threshold.Distance));
                left = production.Convert(TiltInto.PulseBy.Left(threshold.Left));
                right = production.Convert(TiltInto.PulseBy.Right(threshold.Right));
                forward = production.Convert(TiltInto.PulseBy.Forward(threshold.Forward));
                backward = production.Convert(TiltInto.PulseBy.Backward(threshold.Backward));
            }

            public ICancellation Connect(IPulsatedTiltSoftware module)
            {
                if (module == null)
                {
                    throw new ArgumentNullException(nameof(module));
                }

                var composite = new CompositeCancellation();

                distance.Produce(module.Distance).Synthesize(composite);
                left.Produce(module.Left).Synthesize(composite);
                right.Produce(module.Right).Synthesize(composite);
                forward.Produce(module.Forward).Synthesize(composite);
                backward.Produce(module.Backward).Synthesize(composite);

                return composite;
            }
        }
    }
}
