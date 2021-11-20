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
        /// Converts <see cref="IStickProtocol"/> into <see cref="IIgnition{TModule}"/> for <see cref="IStickSoftware"/>.
        /// </summary>
        /// <param name="protocol">
        /// <see cref="IStickProtocol"/> to convert.
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
        public static IIgnition<IStickSoftware> Ignite(this IStickProtocol protocol, IStickConfiguration configuration)
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

            internal IgniteStick(IStickProtocol protocol, IStickConfiguration configuration)
            {
                touch = protocol.Touch.Ignite(configuration.Touch);

                tilt = protocol.Tilt.Ignite(configuration.Tilt);
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

        /// <summary>
        /// Converts <see cref="IStickSoftware"/> into <see cref="IConnection{TModule}"/> for <see cref="IStickHardware"/>.
        /// </summary>
        /// <param name="module">
        /// <see cref="IStickSoftware"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="IConnection{TModule}"/> to connect <see cref="IStickHardware"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="module"/> is null.
        /// </exception>
        public static IConnection<IStickHardware> Connect(this IStickSoftware module)
        {
            if (module == null)
            {
                throw new ArgumentNullException(nameof(module));
            }

            return new ConnectStickHardware(module);
        }
        private sealed class ConnectStickHardware :
            IConnection<IStickHardware>
        {
            private readonly IConsumption<Touch> touch;

            private readonly IConsumption<Tilt> tilt;

            internal ConnectStickHardware(IStickSoftware module)
            {
                touch = module.Touch;

                tilt = module.Tilt;
            }

            public ICancellation Connect(IStickHardware module)
            {
                if (module == null)
                {
                    throw new ArgumentNullException(nameof(module));
                }

                var composite = new CompositeCancellation();

                module.Touch.Produce(touch).Synthesize(composite);
                module.Tilt.Produce(tilt).Synthesize(composite);

                return composite;
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

            return new ConnectPulsatedStickSoftware(module, threshold);
        }
        private sealed class ConnectPulsatedStickSoftware :
            IConnection<IPulsatedStickSoftware>
        {
            private readonly IProduction<Pulse> touch;

            private readonly IConnection<IPulsatedTiltSoftware> tilt;

            internal ConnectPulsatedStickSoftware(IStickHardware module, TiltThreshold threshold)
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

        /// <summary>
        /// Converts <see cref="IPulsatedStickSoftware"/> into <see cref="IConnection{TModule}"/> for <see cref="IPulsatedStickHardware"/>.
        /// </summary>
        /// <param name="module">
        /// <see cref="IPulsatedStickSoftware"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="IConnection{TModule}"/> to connect <see cref="IPulsatedStickHardware"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="module"/> is null.
        /// </exception>
        public static IConnection<IPulsatedStickHardware> Connect(this IPulsatedStickSoftware module)
        {
            if (module == null)
            {
                throw new ArgumentNullException(nameof(module));
            }

            return new ConnectPulsatedStickHardware(module);
        }
        private sealed class ConnectPulsatedStickHardware :
            IConnection<IPulsatedStickHardware>
        {
            private readonly IConsumption<Pulse> touch;

            private readonly IConnection<IPulsatedTiltHardware> tilt;

            internal ConnectPulsatedStickHardware(IPulsatedStickSoftware module)
            {
                touch = module.Touch;

                tilt = module.Tilt.Connect();
            }

            public ICancellation Connect(IPulsatedStickHardware module)
            {
                if (module == null)
                {
                    throw new ArgumentNullException(nameof(module));
                }

                var composite = new CompositeCancellation();

                module.Touch.Produce(touch).Synthesize(composite);
                tilt.Connect(module.Tilt).Synthesize(composite);

                return composite;
            }
        }
    }
}
