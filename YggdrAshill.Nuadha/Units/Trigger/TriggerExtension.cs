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
    /// Defines extensions for <see cref="Trigger"/>.
    /// </summary>
    public static class TriggerExtension
    {
        /// <summary>
        /// Converts <see cref="Trigger"/> into <see cref="IIgnition{TModule}"/> for <see cref="ITriggerSoftware"/>.
        /// </summary>
        /// <param name="protocol">
        /// <see cref="ITriggerProtocol"/> to convert.
        /// </param>
        /// <param name="configuration">
        /// <see cref="ITriggerConfiguration"/> to ignite.
        /// </param>
        /// <returns>
        /// <see cref="IIgnition{TModule}"/> to ignite <see cref="ITriggerSoftware"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="protocol"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="configuration"/> is null.
        /// </exception>
        public static IIgnition<ITriggerSoftware> Ignite(this ITriggerProtocol protocol, ITriggerConfiguration configuration)
        {
            if (protocol == null)
            {
                throw new ArgumentNullException(nameof(protocol));
            }
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            return new IgniteTrigger(protocol, configuration);
        }
        private sealed class IgniteTrigger :
            IIgnition<ITriggerSoftware>
        {
            private readonly ITransmission<Touch> touch;

            private readonly ITransmission<Pull> pull;

            internal IgniteTrigger(ITriggerProtocol protocol, ITriggerConfiguration configuration)
            {
                touch = protocol.Touch.Ignite(configuration.Touch);

                pull = protocol.Pull.Ignite(configuration.Pull);
            }

            public ICancellation Connect(ITriggerSoftware handler)
            {
                if (handler == null)
                {
                    throw new ArgumentNullException(nameof(handler));
                }

                var composite = new CompositeCancellation();

                touch.Produce(handler.Touch).Synthesize(composite);
                pull.Produce(handler.Pull).Synthesize(composite);

                return composite;
            }

            public void Emit()
            {
                touch.Emit();

                pull.Emit();
            }

            public void Dispose()
            {
                touch.Dispose();

                pull.Dispose();
            }
        }

        /// <summary>
        /// Converts <see cref="ITriggerSoftware"/> into <see cref="IConnection{TModule}"/> for <see cref="ITriggerHardware"/>.
        /// </summary>
        /// <param name="module">
        /// <see cref="ITriggerSoftware"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="IConnection{TModule}"/> to connect <see cref="ITriggerHardware"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="module"/> is null.
        /// </exception>
        public static IConnection<ITriggerHardware> Connect(this ITriggerSoftware module)
        {
            if (module == null)
            {
                throw new ArgumentNullException(nameof(module));
            }

            return new ConnectTrigger(module);
        }
        private sealed class ConnectTrigger :
            IConnection<ITriggerHardware>
        {
            private readonly IConsumption<Touch> touch;

            private readonly IConsumption<Pull> push;

            internal ConnectTrigger(ITriggerSoftware module)
            {
                touch = module.Touch;

                push = module.Pull;
            }

            public ICancellation Connect(ITriggerHardware module)
            {
                if (module == null)
                {
                    throw new ArgumentNullException(nameof(module));
                }

                var composite = new CompositeCancellation();

                module.Touch.Produce(touch).Synthesize(composite);
                module.Pull.Produce(push).Synthesize(composite);

                return composite;
            }
        }

        [Obsolete("Please use TriggerExtension.Pulsate instead.")]
        public static IConnection<IPulsatedTriggerSoftware> Convert(this ITriggerHardware module, HysteresisThreshold threshold)
        {
            return module.Pulsate(threshold);
        }

        /// <summary>
        /// Converts <see cref="ITriggerHardware"/> into <see cref="IConnection{TModule}"/> for <see cref="IPulsatedTriggerSoftware"/>.
        /// </summary>
        /// <param name="module">
        /// <see cref="ITriggerHardware"/> to convert.
        /// </param>
        /// <param name="threshold">
        /// <see cref="HysteresisThreshold"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="IConnection{TModule}"/> to connect <see cref="IPulsatedTriggerSoftware"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="module"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="threshold"/> is null.
        /// </exception>
        public static IConnection<IPulsatedTriggerSoftware> Pulsate(this ITriggerHardware module, HysteresisThreshold threshold)
        {
            if (module == null)
            {
                throw new ArgumentNullException(nameof(module));
            }
            if (threshold == null)
            {
                throw new ArgumentNullException(nameof(threshold));
            }

            return new ConnectPulsatedTriggerSoftware(module, threshold);
        }
        private sealed class ConnectPulsatedTriggerSoftware :
            IConnection<IPulsatedTriggerSoftware>
        {
            private readonly IProduction<Pulse> touch;

            private readonly IProduction<Pulse> pull;

            internal ConnectPulsatedTriggerSoftware(ITriggerHardware module, HysteresisThreshold threshold)
            {
                touch = module.Touch.Convert(TouchInto.Pulse);

                pull = module.Pull.Convert(PullInto.Pulse(threshold));
            }

            public ICancellation Connect(IPulsatedTriggerSoftware module)
            {
                if (module == null)
                {
                    throw new ArgumentNullException(nameof(module));
                }

                var composite = new CompositeCancellation();

                touch.Produce(module.Touch).Synthesize(composite);
                pull.Produce(module.Pull).Synthesize(composite);

                return composite;
            }
        }

        /// <summary>
        /// Converts <see cref="IPulsatedTriggerSoftware"/> into <see cref="IConnection{TModule}"/> for <see cref="IPulsatedTriggerHardware"/>.
        /// </summary>
        /// <param name="module">
        /// <see cref="IPulsatedTriggerSoftware"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="IConnection{TModule}"/> to connect <see cref="IPulsatedTriggerHardware"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="module"/> is null.
        /// </exception>
        public static IConnection<IPulsatedTriggerHardware> Connect(this IPulsatedTriggerSoftware module)
        {
            if (module == null)
            {
                throw new ArgumentNullException(nameof(module));
            }

            return new ConnectPulsatedTriggerHardware(module);
        }
        private sealed class ConnectPulsatedTriggerHardware :
            IConnection<IPulsatedTriggerHardware>
        {
            private readonly IConsumption<Pulse> touch;

            private readonly IConsumption<Pulse> pull;

            internal ConnectPulsatedTriggerHardware(IPulsatedTriggerSoftware module)
            {
                touch = module.Touch;

                pull = module.Pull;
            }

            public ICancellation Connect(IPulsatedTriggerHardware module)
            {
                if (module == null)
                {
                    throw new ArgumentNullException(nameof(module));
                }

                var composite = new CompositeCancellation();

                module.Touch.Produce(touch).Synthesize(composite);
                module.Pull.Produce(pull).Synthesize(composite);

                return composite;
            }
        }
    }
}
