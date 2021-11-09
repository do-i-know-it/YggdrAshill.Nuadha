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
        /// Converts <see cref="Button"/> into <see cref="IIgnition{TModule}"/> for <see cref="IButtonSoftware"/>.
        /// </summary>
        /// <param name="protocol">
        /// <see cref="Button"/> to convert.
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
        public static IIgnition<IButtonSoftware> Ignite(this Button protocol, IButtonConfiguration configuration)
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

            internal IgniteButton(Button protocol, IButtonConfiguration configuration)
            {
                touch = protocol.Touch.Transmit(configuration.Touch);

                push = protocol.Push.Transmit(configuration.Push);
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

            return new ConnectPulsatedButton(module);
        }
        private sealed class ConnectPulsatedButton :
            IConnection<IPulsatedButtonSoftware>
        {
            private readonly IProduction<Pulse> touch;

            private readonly IProduction<Pulse> push;

            internal ConnectPulsatedButton(IButtonHardware module)
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
    }
}
