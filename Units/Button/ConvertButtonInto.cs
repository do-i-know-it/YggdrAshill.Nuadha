using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Signals;
using System;

namespace YggdrAshill.Nuadha.Units
{
    /// <summary>
    /// Defines conversion for <see cref="IButtonProtocol"/>, <see cref="IButtonHardware"/> and <see cref="IButtonSoftware"/>.
    /// </summary>
    public static class ConvertButtonInto
    {
        /// <summary>
        /// Converts <see cref="IButtonProtocol"/> into <see cref="ITransmission{TModule}"/> for <see cref="IButtonSoftware"/>.
        /// </summary>
        /// <param name="protocol">
        /// <see cref="IButtonProtocol"/> to convert.
        /// </param>
        /// <param name="configuration">
        /// <see cref="IButtonConfiguration"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="ITransmission{TModule}"/> for <see cref="IButtonSoftware"/> converted from <see cref="IButtonProtocol"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="protocol"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="configuration"/> is null.
        /// </exception>
        public static ITransmission<IButtonSoftware> Transmission(IButtonProtocol protocol, IButtonConfiguration configuration)
        {
            if (protocol == null)
            {
                throw new ArgumentNullException(nameof(protocol));
            }
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            return new TransmitButton(configuration, protocol);
        }
        private sealed class TransmitButton :
            ITransmission<IButtonSoftware>
        {
            private readonly IEmission emission;

            private readonly IConnection<IButtonSoftware> connection;

            internal TransmitButton(IButtonConfiguration configuration, IButtonProtocol protocol)
            {
                emission = Conduct(configuration, protocol.Software);

                connection = Connection(protocol.Hardware);
            }

            public ICancellation Connect(IButtonSoftware module)
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
        private static IEmission Conduct(IButtonConfiguration configuration, IButtonSoftware software)
            => EmissionSource
            .Default
            .Synthesize(ConductSignalTo.Consume(configuration.Touch, software.Touch))
            .Synthesize(ConductSignalTo.Consume(configuration.Push, software.Push))
            .Build();

        /// <summary>
        /// Converts <see cref="IButtonSoftware"/> into <see cref="IConnection{TModule}"/> for <see cref="IButtonHardware"/>.
        /// </summary>
        /// <param name="software">
        /// <see cref="IButtonSoftware"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="IConnection{TModule}"/> for <see cref="IButtonHardware"/> converted from <see cref="IButtonSoftware"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="software"/> is null.
        /// </exception>
        public static IConnection<IButtonHardware> Connection(IButtonSoftware software)
        {
            if (software == null)
            {
                throw new ArgumentNullException(nameof(software));
            }

            return new ConnectButtonHardware(software);
        }
        private sealed class ConnectButtonHardware :
            IConnection<IButtonHardware>
        {
            private readonly IButtonSoftware software;

            internal ConnectButtonHardware(IButtonSoftware software)
            {
                this.software = software;
            }

            public ICancellation Connect(IButtonHardware module)
            {
                if (module == null)
                {
                    throw new ArgumentNullException(nameof(module));
                }

                return ConvertButtonInto.Connect(module, software);
            }
        }

        /// <summary>
        /// Converts <see cref="IButtonHardware"/> into <see cref="IConnection{TModule}"/> for <see cref="IButtonSoftware"/>.
        /// </summary>
        /// <param name="hardware">
        /// <see cref="IButtonSoftware"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="IConnection{TModule}"/> for <see cref="IButtonSoftware"/> converted from <see cref="IButtonHardware"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="hardware"/> is null.
        /// </exception>
        public static IConnection<IButtonSoftware> Connection(IButtonHardware hardware)
        {
            if (hardware == null)
            {
                throw new ArgumentNullException(nameof(hardware));
            }

            return new ConnectButtonSoftware(hardware);
        }
        private sealed class ConnectButtonSoftware :
            IConnection<IButtonSoftware>
        {
            private readonly IButtonHardware hardware;

            internal ConnectButtonSoftware(IButtonHardware hardware)
            {
                this.hardware = hardware;
            }

            public ICancellation Connect(IButtonSoftware module)
            {
                if (module == null)
                {
                    throw new ArgumentNullException(nameof(module));
                }

                return ConvertButtonInto.Connect(hardware, module);
            }
        }

        private static ICancellation Connect(IButtonHardware hardware, IButtonSoftware software)
            => CancellationSource
            .Default
            .Synthesize(hardware.Touch.Produce(software.Touch))
            .Synthesize(hardware.Push.Produce(software.Push))
            .Build();

        /// <summary>
        /// Converts <see cref="IButtonHardware"/> into <see cref="IPulsatedButtonHardware"/>.
        /// </summary>
        /// <param name="hardware">
        /// <see cref="IButtonHardware"/> to convert.
        /// </param>
        /// <param name="pulsation">
        /// <see cref="IButtonPulsation"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="IPulsatedButtonHardware"/> converted from <see cref="IButtonHardware"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="hardware"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="pulsation"/> is null.
        /// </exception>
        public static IPulsatedButtonHardware PulsatedButton(IButtonHardware hardware, IButtonPulsation pulsation)
        {
            if (hardware == null)
            {
                throw new ArgumentNullException(nameof(hardware));
            }
            if (pulsation == null)
            {
                throw new ArgumentNullException(nameof(pulsation));
            }

            return new PulsatedButtonHardware(hardware, pulsation);
        }
        private sealed class PulsatedButtonHardware :
            IPulsatedButtonHardware
        {
            internal PulsatedButtonHardware(IButtonHardware hardware, IButtonPulsation pulsation)
            {
                Touch = ProduceSignalTo.Convert(hardware.Touch, pulsation.Touch);

                Push = ProduceSignalTo.Convert(hardware.Push, pulsation.Push);
            }

            public IProduction<Pulse> Touch { get; }

            public IProduction<Pulse> Push { get; }
        }

        /// <summary>
        /// Converts <see cref="IButtonSoftware"/> into <see cref="ITriggerSoftware"/>.
        /// </summary>
        /// <param name="software">
        /// <see cref="IButtonSoftware"/> to convert.
        /// </param>
        /// <param name="translation">
        /// <see cref="ITranslation{TInput, TOutput}"/> to convert <see cref="Pull"/> into <see cref="Push"/>.
        /// </param>
        /// <returns>
        /// <see cref="ITriggerSoftware"/> converted from <see cref="IButtonSoftware"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="software"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="translation"/> is null.
        /// </exception>
        public static ITriggerSoftware Trigger(IButtonSoftware software, ITranslation<Pull, Push> translation)
        {
            if (software == null)
            {
                throw new ArgumentNullException(nameof(software));
            }
            if (translation == null)
            {
                throw new ArgumentNullException(nameof(translation));
            }

            return new TriggerSoftware(software, translation);
        }
        private sealed class TriggerSoftware :
            ITriggerSoftware
        {
            internal TriggerSoftware(IButtonSoftware software, ITranslation<Pull, Push> translation)
            {
                Touch = software.Touch;

                Pull = ConsumeSignalTo.Convert(translation, software.Push);
            }

            public IConsumption<Touch> Touch { get; }

            public IConsumption<Pull> Pull { get; }
        }
    }
}
