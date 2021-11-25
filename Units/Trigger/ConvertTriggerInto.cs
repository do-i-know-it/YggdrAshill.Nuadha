using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Signals;
using System;

namespace YggdrAshill.Nuadha.Units
{
    /// <summary>
    /// Defines conversion for <see cref="ITriggerProtocol"/>, <see cref="ITriggerHardware"/> and <see cref="ITriggerSoftware"/>.
    /// </summary>
    public static class ConvertTriggerInto
    {
        /// <summary>
        /// Converts <see cref="ITriggerProtocol"/> into <see cref="ITransmission{TModule}"/> for <see cref="ITriggerSoftware"/>.
        /// </summary>
        /// <param name="protocol">
        /// <see cref="ITriggerProtocol"/> to convert.
        /// </param>
        /// <param name="configuration">
        /// <see cref="ITriggerConfiguration"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="ITransmission{TModule}"/> for <see cref="ITriggerSoftware"/> converted from <see cref="ITriggerProtocol"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="protocol"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="configuration"/> is null.
        /// </exception>
        public static ITransmission<ITriggerSoftware> Transmission(ITriggerProtocol protocol, ITriggerConfiguration configuration)
        {
            if (protocol == null)
            {
                throw new ArgumentNullException(nameof(protocol));
            }
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }
            
            return new TransmitTrigger(configuration, protocol);
        }
        private sealed class TransmitTrigger :
            ITransmission<ITriggerSoftware>
        {
            private readonly IEmission emission;

            private readonly IConnection<ITriggerSoftware> connection;

            internal TransmitTrigger(ITriggerConfiguration configuration, ITriggerProtocol protocol)
            {
                emission = Conduct(configuration, protocol.Software);

                connection = ConvertTriggerInto.Connection(protocol.Hardware);
            }

            public ICancellation Connect(ITriggerSoftware module)
            {
                if (module == null)
                {
                    throw new ArgumentNullException(nameof(module));
                }

                return connection.Connect(module);
            }

            public void Emit()
            {
                emission.Emit();
            }
        }
        private static IEmission Conduct(ITriggerConfiguration configuration, ITriggerSoftware software)
            => EmissionSource
            .Default
            .Synthesize(ConductSignalTo.Consume(configuration.Touch, software.Touch))
            .Synthesize(ConductSignalTo.Consume(configuration.Pull, software.Pull))
            .Build();

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
        public static IConnection<ITriggerHardware> Connection(ITriggerSoftware software)
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

                return ConvertTriggerInto.Connect(module, software);
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
        public static IConnection<ITriggerSoftware> Connection(ITriggerHardware hardware)
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

                return ConvertTriggerInto.Connect(hardware, module);
            }
        }

        private static ICancellation Connect(ITriggerHardware hardware, ITriggerSoftware software)
            => CancellationSource
            .Default
            .Synthesize(hardware.Touch.Produce(software.Touch))
            .Synthesize(hardware.Pull.Produce(software.Pull))
            .Build();

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
        public static IPulsatedTriggerHardware PulsatedTrigger(ITriggerHardware hardware, ITriggerPulsation pulsation)
        {
            if (hardware == null)
            {
                throw new ArgumentNullException(nameof(hardware));
            }
            if (pulsation == null)
            {
                throw new ArgumentNullException(nameof(pulsation));
            }

            return new PulsatedTriggerHardware(hardware, pulsation);
        }
        private sealed class PulsatedTriggerHardware :
            IPulsatedTriggerHardware
        {
            internal PulsatedTriggerHardware(ITriggerHardware hardware, ITriggerPulsation pulsation)
            {
                Touch = ProduceSignalTo.Convert(hardware.Touch, pulsation.Touch);

                Pull = ProduceSignalTo.Convert(hardware.Pull, pulsation.Pull);
            }

            public IProduction<Pulse> Touch { get; }

            public IProduction<Pulse> Pull { get; }
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
        public static IButtonHardware Button(ITriggerHardware hardware, ITranslation<Pull, Push> translation)
        {
            if (hardware == null)
            {
                throw new ArgumentNullException(nameof(hardware));
            }
            if (translation == null)
            {
                throw new ArgumentNullException(nameof(translation));
            }

            return new ButtonHardware(hardware, translation);
        }
        private sealed class ButtonHardware :
            IButtonHardware
        {
            internal ButtonHardware(ITriggerHardware hardware, ITranslation<Pull, Push> translation)
            {
                Touch = hardware.Touch;

                Push = ProduceSignalTo.Convert(hardware.Pull, translation);
            }

            public IProduction<Touch> Touch { get; }

            public IProduction<Push> Push { get; }
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
        public static IStickSoftware Stick(ITriggerSoftware software, ITranslation<Tilt, Pull> translation)
        {
            if (software == null)
            {
                throw new ArgumentNullException(nameof(software));
            }
            if (translation == null)
            {
                throw new ArgumentNullException(nameof(translation));
            }

            return new StickSoftware(software, translation);
        }
        private sealed class StickSoftware :
            IStickSoftware
        {
            internal StickSoftware(ITriggerSoftware software, ITranslation<Tilt, Pull> translation)
            {
                Touch = software.Touch;

                Tilt = ConsumeSignalTo.Convert(translation, software.Pull);
            }

            public IConsumption<Touch> Touch { get; }

            public IConsumption<Tilt> Tilt { get; }
        }
    }
}
