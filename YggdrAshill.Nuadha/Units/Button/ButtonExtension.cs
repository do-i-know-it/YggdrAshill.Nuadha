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
    /// Defines extensions for <see cref="Button"/>.
    /// </summary>
    public static class ButtonExtension
    {
        /// <summary>
        /// Converts <see cref="IButtonProtocol"/> into <see cref="IIgnition{TModule}"/> for <see cref="IButtonSoftware"/>.
        /// </summary>
        /// <param name="protocol">
        /// <see cref="IButtonProtocol"/> to convert.
        /// </param>
        /// <param name="configuration">
        /// <see cref="IButtonConfiguration"/> to ignite.
        /// </param>
        /// <returns>
        /// <see cref="IIgnition{TModule}"/> to ignite <see cref="IButtonSoftware"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="protocol"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="configuration"/> is null.
        /// </exception>
        public static IIgnition<IButtonSoftware> Ignite(this IButtonProtocol protocol, IButtonConfiguration configuration)
        {
            if (protocol == null)
            {
                throw new ArgumentNullException(nameof(protocol));
            }
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            return new IgniteButton(protocol, configuration);
        }
        private sealed class IgniteButton :
            IIgnition<IButtonSoftware>
        {
            private readonly ITransmission<Touch> touch;

            private readonly ITransmission<Push> push;

            internal IgniteButton(IButtonProtocol protocol, IButtonConfiguration configuration)
            {
                touch = protocol.Touch.Ignite(configuration.Touch);

                push = protocol.Push.Ignite(configuration.Push);
            }

            public ICancellation Connect(IButtonSoftware module)
            {
                if (module == null)
                {
                    throw new ArgumentNullException(nameof(module));
                }

                var composite = new CompositeCancellation();

                touch.Produce(module.Touch).Synthesize(composite);
                push.Produce(module.Push).Synthesize(composite);

                return composite;
            }

            public void Emit()
            {
                touch.Emit();

                push.Emit();
            }

            public void Dispose()
            {
                touch.Dispose();

                push.Dispose();
            }
        }

        /// <summary>
        /// Converts <see cref="IButtonSoftware"/> into <see cref="IConnection{TModule}"/> for <see cref="IButtonHardware"/>.
        /// </summary>
        /// <param name="module">
        /// <see cref="IButtonSoftware"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="IConnection{TModule}"/> to connect <see cref="IButtonHardware"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="module"/> is null.
        /// </exception>
        public static IConnection<IButtonHardware> Connect(this IButtonSoftware module)
        {
            if (module == null)
            {
                throw new ArgumentNullException(nameof(module));
            }

            return new ConnectButton(module);
        }
        private sealed class ConnectButton :
            IConnection<IButtonHardware>
        {
            private readonly IConsumption<Touch> touch;

            private readonly IConsumption<Push> push;

            internal ConnectButton(IButtonSoftware module)
            {
                touch = module.Touch;

                push = module.Push;
            }

            public ICancellation Connect(IButtonHardware module)
            {
                if (module == null)
                {
                    throw new ArgumentNullException(nameof(module));
                }

                var composite = new CompositeCancellation();

                module.Touch.Produce(touch).Synthesize(composite);
                module.Push.Produce(push).Synthesize(composite);

                return composite;
            }
        }

        [Obsolete("Please use ButtonExtension.Pulsate instead.")]
        public static IConnection<IPulsatedButtonSoftware> Convert(this IButtonHardware module)
        {
            return module.Pulsate();
        }

        /// <summary>
        /// Converts <see cref="IButtonHardware"/> into <see cref="IConnection{TModule}"/> for <see cref="IPulsatedButtonSoftware"/>.
        /// </summary>
        /// <param name="module">
        /// <see cref="IButtonHardware"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="IConnection{TModule}"/> to connect <see cref="IPulsatedButtonSoftware"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="module"/> is null.
        /// </exception>
        public static IConnection<IPulsatedButtonSoftware> Pulsate(this IButtonHardware module)
        {
            if (module == null)
            {
                throw new ArgumentNullException(nameof(module));
            }

            return new ConnectPulsatedButtonSoftware(module);
        }
        private sealed class ConnectPulsatedButtonSoftware :
            IConnection<IPulsatedButtonSoftware>
        {
            private readonly IProduction<Pulse> touch;

            private readonly IProduction<Pulse> push;

            internal ConnectPulsatedButtonSoftware(IButtonHardware module)
            {
                touch = module.Touch.Convert(TouchInto.Pulse);

                push = module.Push.Convert(PushInto.Pulse);
            }

            public ICancellation Connect(IPulsatedButtonSoftware module)
            {
                if (module == null)
                {
                    throw new ArgumentNullException(nameof(module));
                }

                var composite = new CompositeCancellation();

                touch.Produce(module.Touch).Synthesize(composite);
                push.Produce(module.Push).Synthesize(composite);

                return composite;
            }
        }

        /// <summary>
        /// Converts <see cref="IPulsatedButtonSoftware"/> into <see cref="IConnection{TModule}"/> for <see cref="IPulsatedButtonHardware"/>.
        /// </summary>
        /// <param name="module">
        /// <see cref="IPulsatedButtonSoftware"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="IConnection{TModule}"/> to connect <see cref="IPulsatedButtonHardware"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="module"/> is null.
        /// </exception>
        public static IConnection<IPulsatedButtonHardware> Connect(this IPulsatedButtonSoftware module)
        {
            if (module == null)
            {
                throw new ArgumentNullException(nameof(module));
            }

            return new ConnectPulsatedButtonHardware(module);
        }
        private sealed class ConnectPulsatedButtonHardware :
            IConnection<IPulsatedButtonHardware>
        {
            private readonly IConsumption<Pulse> touch;

            private readonly IConsumption<Pulse> push;

            internal ConnectPulsatedButtonHardware(IPulsatedButtonSoftware module)
            {
                touch = module.Touch;

                push = module.Push;
            }

            public ICancellation Connect(IPulsatedButtonHardware module)
            {
                if (module == null)
                {
                    throw new ArgumentNullException(nameof(module));
                }

                var composite = new CompositeCancellation();

                module.Touch.Produce(touch).Synthesize(composite);
                module.Push.Produce(push).Synthesize(composite);

                return composite;
            }
        }
    }
}
