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

            return new ConnectPulsatedTiltSoftware(production, threshold);
        }
        private sealed class ConnectPulsatedTiltSoftware :
            IConnection<IPulsatedTiltSoftware>
        {
            private readonly IProduction<Pulse> distance;

            private readonly IProduction<Pulse> left;

            private readonly IProduction<Pulse> right;

            private readonly IProduction<Pulse> forward;

            private readonly IProduction<Pulse> backward;

            internal ConnectPulsatedTiltSoftware(IProduction<Tilt> production, TiltThreshold threshold)
            {
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

        /// <summary>
        /// Converts <see cref="IPulsatedTiltSoftware"/> into <see cref="IConnection{TModule}"/> for <see cref="IPulsatedTiltHardware"/>.
        /// </summary>
        /// <param name="module">
        /// <see cref="IPulsatedTiltSoftware"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="IConnection{TModule}"/> to connect <see cref="IPulsatedTiltHardware"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="module"/> is null.
        /// </exception>
        public static IConnection<IPulsatedTiltHardware> Connect(this IPulsatedTiltSoftware module)
        {
            if (module == null)
            {
                throw new ArgumentNullException(nameof(module));
            }

            return new ConnectPulsatedTiltHardware(module);
        }
        private sealed class ConnectPulsatedTiltHardware :
            IConnection<IPulsatedTiltHardware>
        {
            private readonly IConsumption<Pulse> distance;

            private readonly IConsumption<Pulse> left;

            private readonly IConsumption<Pulse> right;

            private readonly IConsumption<Pulse> forward;

            private readonly IConsumption<Pulse> backward;

            internal ConnectPulsatedTiltHardware(IPulsatedTiltSoftware module)
            {
                distance = module.Distance;
                left = module.Left;
                right = module.Right;
                forward = module.Forward;
                backward = module.Backward;
            }

            public ICancellation Connect(IPulsatedTiltHardware module)
            {
                if (module == null)
                {
                    throw new ArgumentNullException(nameof(module));
                }

                var composite = new CompositeCancellation();

                module.Distance.Produce(distance).Synthesize(composite);
                module.Left.Produce(left).Synthesize(composite);
                module.Right.Produce(right).Synthesize(composite);
                module.Forward.Produce(forward).Synthesize(composite);
                module.Backward.Produce(backward).Synthesize(composite);

                return composite;
            }
        }
    }
}
