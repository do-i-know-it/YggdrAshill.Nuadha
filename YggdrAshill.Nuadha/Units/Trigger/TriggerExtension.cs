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
    /// Defines extensions for <see cref="ITriggerHardware"/> and <see cref="ITriggerSoftware"/>.
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
        /// <param name="software">
        /// <see cref="ITriggerSoftware"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="IConnection{TModule}"/> for <see cref="ITriggerHardware"/> converted from <see cref="ITriggerSoftware"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="software"/> is null.
        /// </exception>
        public static IConnection<ITriggerHardware> Connect(this ITriggerSoftware software)
        {
            if (software == null)
            {
                throw new ArgumentNullException(nameof(software));
            }

            return new ConnectTriggerHardware(software);
        }
        private sealed class ConnectTriggerHardware :
            IConnection<ITriggerHardware>
        {
            private readonly ITriggerSoftware software;

            internal ConnectTriggerHardware(ITriggerSoftware software)
            {
                this.software = software;
            }

            public ICancellation Connect(ITriggerHardware module)
            {
                if (module == null)
                {
                    throw new ArgumentNullException(nameof(module));
                }

                var composite = new CompositeCancellation();

                module.Touch.Produce(software.Touch).Synthesize(composite);
                module.Pull.Produce(software.Pull).Synthesize(composite);

                return composite;
            }
        }

        /// <summary>
        /// Converts <see cref="ITriggerHardware"/> into <see cref="IConnection{TModule}"/> for <see cref="ITriggerSoftware"/>.
        /// </summary>
        /// <param name="hardware">
        /// <see cref="ITriggerHardware"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="IConnection{TModule}"/> for <see cref="ITriggerSoftware"/> converted from <see cref="ITriggerHardware"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="hardware"/> is null.
        /// </exception>
        public static IConnection<ITriggerSoftware> Connect(this ITriggerHardware hardware)
        {
            if (hardware == null)
            {
                throw new ArgumentNullException(nameof(hardware));
            }

            return new ConnectTriggerSoftware(hardware);
        }
        private sealed class ConnectTriggerSoftware :
            IConnection<ITriggerSoftware>
        {
            private readonly ITriggerHardware hardware;

            internal ConnectTriggerSoftware(ITriggerHardware hardware)
            {
                this.hardware = hardware;
            }

            public ICancellation Connect(ITriggerSoftware module)
            {
                if (module == null)
                {
                    throw new ArgumentNullException(nameof(module));
                }

                var composite = new CompositeCancellation();

                hardware.Touch.Produce(module.Touch).Synthesize(composite);
                hardware.Pull.Produce(module.Pull).Synthesize(composite);

                return composite;
            }
        }

        /// <summary>
        /// Converts <see cref="ITriggerHardware"/> into <see cref="IPulsatedTriggerHardware"/>.
        /// </summary>
        /// <param name="hardware">
        /// <see cref="ITriggerHardware"/> to convert.
        /// </param>
        /// <param name="pulsation">
        /// <see cref="ITriggerPulsation"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="IPulsatedTriggerHardware"/> converted from <see cref="ITriggerHardware"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="hardware"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="pulsation"/> is null.
        /// </exception>
        public static IPulsatedTriggerHardware Pulsate(this ITriggerHardware hardware, ITriggerPulsation pulsation)
        {
            if (hardware == null)
            {
                throw new ArgumentNullException(nameof(hardware));
            }
            if (pulsation == null)
            {
                throw new ArgumentNullException(nameof(pulsation));
            }

            return ConvertTriggerInto.PulsatedTrigger(hardware, pulsation);
        }

        /// <summary>
        /// Converts <see cref="ITriggerHardware"/> into <see cref="IPulsatedTriggerHardware"/>.
        /// </summary>
        /// <param name="hardware">
        /// <see cref="ITriggerHardware"/> to convert.
        /// </param>
        /// <param name="threshold">
        /// <see cref="HysteresisThreshold"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="IPulsatedTriggerHardware"/> converted from <see cref="ITriggerHardware"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="hardware"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="threshold"/> is null.
        /// </exception>
        public static IPulsatedTriggerHardware Pulsate(this ITriggerHardware hardware, HysteresisThreshold threshold)
        {
            if (hardware == null)
            {
                throw new ArgumentNullException(nameof(hardware));
            }
            if (threshold == null)
            {
                throw new ArgumentNullException(nameof(threshold));
            }

            return hardware.Pulsate(Nuadha.Pulsate.Trigger(threshold));
        }

        /// <summary>
        /// Converts <see cref="ITriggerHardware"/> into <see cref="IButtonHardware"/>.
        /// </summary>
        /// <param name="hardware">
        /// <see cref="ITriggerHardware"/> to convert.
        /// </param>
        /// <param name="translation">
        /// <see cref="ITranslation{TInput, TOutput}"/> to convert <see cref="Pull"/> into <see cref="Push"/>.
        /// </param>
        /// <returns>
        /// <see cref="IButtonHardware"/> converted from <see cref="ITriggerHardware"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="hardware"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="translation"/> is null.
        /// </exception>
        public static IButtonHardware ToButton(this ITriggerHardware hardware, ITranslation<Pull, Push> translation)
        {
            if (hardware == null)
            {
                throw new ArgumentNullException(nameof(hardware));
            }
            if (translation == null)
            {
                throw new ArgumentNullException(nameof(translation));
            }

            return ConvertTriggerInto.Button(hardware, translation);
        }

        /// <summary>
        /// Converts <see cref="ITriggerHardware"/> into <see cref="IButtonHardware"/>.
        /// </summary>
        /// <param name="hardware">
        /// <see cref="ITriggerHardware"/> to convert.
        /// </param>
        /// <param name="threshold">
        /// <see cref="HysteresisThreshold"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="IButtonHardware"/> converted from <see cref="ITriggerHardware"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="hardware"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="threshold"/> is null.
        /// </exception>
        public static IButtonHardware ToButton(this ITriggerHardware hardware, HysteresisThreshold threshold)
        {
            if (hardware == null)
            {
                throw new ArgumentNullException(nameof(hardware));
            }
            if (threshold == null)
            {
                throw new ArgumentNullException(nameof(threshold));
            }

            return hardware.ToButton(PullInto.Push(threshold));
        }

        /// <summary>
        /// Converts <see cref="ITriggerSoftware"/> into <see cref="IStickSoftware"/>.
        /// </summary>
        /// <param name="software">
        /// <see cref="ITriggerSoftware"/> to convert.
        /// </param>
        /// <param name="translation">
        /// <see cref="ITranslation{TInput, TOutput}"/> to convert <see cref="Tilt"/> into <see cref="Pull"/>.
        /// </param>
        /// <returns>
        /// <see cref="IStickSoftware"/> converted from <see cref="ITriggerSoftware"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="software"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="translation"/> is null.
        /// </exception>
        public static IStickSoftware ToStick(this ITriggerSoftware software, ITranslation<Tilt, Pull> translation)
        {
            if (software == null)
            {
                throw new ArgumentNullException(nameof(software));
            }
            if (translation == null)
            {
                throw new ArgumentNullException(nameof(translation));
            }

            return ConvertTriggerInto.Stick(software, translation);
        }
    }
}
