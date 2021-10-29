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
        /// <see cref="Trigger"/> to convert.
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
        public static IIgnition<ITriggerSoftware> Ignite(this Trigger protocol, ITriggerConfiguration configuration)
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

            internal IgniteTrigger(Trigger protocol, ITriggerConfiguration configuration)
            {
                touch = protocol.Touch.Transmit(configuration.Touch);

                pull = protocol.Pull.Transmit(configuration.Pull);
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
        public static IConnection<IPulsatedTriggerSoftware> Convert(this ITriggerHardware module, HysteresisThreshold threshold)
        {
            if (module == null)
            {
                throw new ArgumentNullException(nameof(module));
            }
            if (threshold == null)
            {
                throw new ArgumentNullException(nameof(threshold));
            }

            return new ConnectPulsatedTrigger(module, threshold);
        }
        private sealed class ConnectPulsatedTrigger :
            IConnection<IPulsatedTriggerSoftware>
        {
            private readonly IProduction<Pulse> touch;

            private readonly IProduction<Pulse> pull;

            internal ConnectPulsatedTrigger(ITriggerHardware module, HysteresisThreshold threshold)
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
    }
}
