using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Signals;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Defines extensions for <see cref="Stick"/>.
    /// </summary>
    public static class StickExtension
    {
        /// <summary>
        /// Converts <see cref="Stick"/> into <see cref="IIgnition{TModule}"/> for <see cref="IStickSoftware"/>.
        /// </summary>
        /// <param name="protocol">
        /// <see cref="Stick"/> to convert.
        /// </param>
        /// <param name="configuration">
        /// <see cref="IStickConfiguration"/> to ignite.
        /// </param>
        /// <returns>
        /// <see cref="IIgnition{TModule}"/> to ignite <see cref="IStickSoftware"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="protocol"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="configuration"/> is null.
        /// </exception>
        public static IIgnition<IStickSoftware> Ignite(this Stick protocol, IStickConfiguration configuration)
        {
            if (protocol == null)
            {
                throw new ArgumentNullException(nameof(protocol));
            }
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            return new IgniteStick(protocol, configuration);
        }
        private sealed class IgniteStick :
            IIgnition<IStickSoftware>
        {
            private readonly ITransmission<Touch> touch;

            private readonly ITransmission<Tilt> tilt;

            internal IgniteStick(Stick protocol, IStickConfiguration configuration)
            {
                touch = protocol.Touch.Transmit(configuration.Touch);

                tilt = protocol.Tilt.Transmit(configuration.Tilt);
            }

            public ICancellation Connect(IStickSoftware module)
            {
                if (module == null)
                {
                    throw new ArgumentNullException(nameof(module));
                }

                var composite = new CompositeCancellation();

                touch.Produce(module.Touch).Synthesize(composite);
                tilt.Produce(module.Tilt).Synthesize(composite);

                return composite;
            }

            public void Emit()
            {
                touch.Emit();

                tilt.Emit();
            }

            public void Dispose()
            {
                touch.Dispose();

                tilt.Dispose();
            }
        }

        [Obsolete("Please use StickExtension.Pulsate instead.")]
        public static IConnection<IPulsatedStickSoftware> Convert(this IStickHardware module, TiltThreshold threshold)
        {
            return module.Pulsate(threshold);
        }

        /// <summary>
        /// Converts <see cref="IStickHardware"/> into <see cref="IConnection{TModule}"/> for <see cref="IPulsatedStickSoftware"/>.
        /// </summary>
        /// <param name="module">
        /// <see cref="IStickHardware"/> to convert.
        /// </param>
        /// <param name="threshold">
        /// <see cref="TiltThreshold"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="IConnection{TModule}"/> to connect <see cref="IPulsatedStickSoftware"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="module"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="threshold"/> is null.
        /// </exception>
        public static IConnection<IPulsatedStickSoftware> Pulsate(this IStickHardware module, TiltThreshold threshold)
        {
            if (module == null)
            {
                throw new ArgumentNullException(nameof(module));
            }
            if (threshold == null)
            {
                throw new ArgumentNullException(nameof(threshold));
            }

            return new ConnectPulsatedStick(module, threshold);
        }
        private sealed class ConnectPulsatedStick :
            IConnection<IPulsatedStickSoftware>
        {
            private readonly IProduction<Pulse> touch;

            private readonly IConnection<IPulsatedTiltSoftware> tilt;

            internal ConnectPulsatedStick(IStickHardware module, TiltThreshold threshold)
            {
                touch = module.Touch.Convert(TouchInto.Pulse);

                tilt = module.Tilt.Pulsate(threshold);
            }

            public ICancellation Connect(IPulsatedStickSoftware module)
            {
                if (module == null)
                {
                    throw new ArgumentNullException(nameof(module));
                }

                var composite = new CompositeCancellation();

                touch.Produce(module.Touch).Synthesize(composite);
                tilt.Connect(module.Tilt).Synthesize(composite);

                return composite;
            }
        }
    }
}
