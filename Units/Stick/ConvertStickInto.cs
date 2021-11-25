using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Signals;
using System;

namespace YggdrAshill.Nuadha.Units
{
    /// <summary>
    /// Defines conversion for <see cref="IStickProtocol"/>, <see cref="IStickHardware"/> and <see cref="IStickSoftware"/>.
    /// </summary>
    public static class ConvertStickInto
    {
        /// <summary>
        /// Converts <see cref="IStickProtocol"/> into <see cref="ITransmission{TModule}"/> for <see cref="IStickSoftware"/>.
        /// </summary>
        /// <param name="protocol">
        /// <see cref="IStickProtocol"/> to convert.
        /// </param>
        /// <param name="configuration">
        /// <see cref="IStickConfiguration"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="ITransmission{TModule}"/> for <see cref="IStickSoftware"/> converted from <see cref="IStickProtocol"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="protocol"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="configuration"/> is null.
        /// </exception>
        public static ITransmission<IStickSoftware> Transmission(IStickProtocol protocol, IStickConfiguration configuration)
        {
            if (protocol == null)
            {
                throw new ArgumentNullException(nameof(protocol));
            }
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }
            
            return new TransmitStick(configuration, protocol);
        }
        private sealed class TransmitStick :
            ITransmission<IStickSoftware>
        {
            private readonly IEmission emission;

            private readonly IConnection<IStickSoftware> connection;

            internal TransmitStick(IStickConfiguration configuration, IStickProtocol protocol)
            {
                emission = Conduct(configuration, protocol.Software);

                connection = ConvertStickInto.Connection(protocol.Hardware);
            }

            public ICancellation Connect(IStickSoftware module)
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
        private static IEmission Conduct(IStickConfiguration configuration, IStickSoftware software)
            => EmissionSource
            .Default
            .Synthesize(ConductSignalTo.Consume(configuration.Touch, software.Touch))
            .Synthesize(ConductSignalTo.Consume(configuration.Tilt, software.Tilt))
            .Build();

        /// <summary>
        /// Converts <see cref="IStickSoftware"/> into <see cref="IConnection{TModule}"/> for <see cref="IStickHardware"/>.
        /// </summary>
        /// <param name="software">
        /// <see cref="IStickSoftware"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="IConnection{TModule}"/> for <see cref="IStickHardware"/> converted from <see cref="IStickSoftware"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="software"/> is null.
        /// </exception>
        public static IConnection<IStickHardware> Connection(IStickSoftware software)
        {
            if (software == null)
            {
                throw new ArgumentNullException(nameof(software));
            }

            return new ConnectStickHardware(software);
        }
        private sealed class ConnectStickHardware :
            IConnection<IStickHardware>
        {
            private readonly IStickSoftware software;

            internal ConnectStickHardware(IStickSoftware software)
            {
                this.software = software;
            }

            public ICancellation Connect(IStickHardware module)
            {
                if (module == null)
                {
                    throw new ArgumentNullException(nameof(module));
                }

                return ConvertStickInto.Connect(module, software);
            }
        }

        /// <summary>
        /// Converts <see cref="IStickHardware"/> into <see cref="IConnection{TModule}"/> for <see cref="IStickSoftware"/>.
        /// </summary>
        /// <param name="hardware">
        /// <see cref="IStickHardware"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="IConnection{TModule}"/> for <see cref="IStickSoftware"/> converted from <see cref="IStickHardware"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="hardware"/> is null.
        /// </exception>
        public static IConnection<IStickSoftware> Connection(IStickHardware hardware)
        {
            if (hardware == null)
            {
                throw new ArgumentNullException(nameof(hardware));
            }

            return new ConnectStickSoftware(hardware);
        }
        private sealed class ConnectStickSoftware :
            IConnection<IStickSoftware>
        {
            private readonly IStickHardware hardware;

            internal ConnectStickSoftware(IStickHardware hardware)
            {
                this.hardware = hardware;
            }

            public ICancellation Connect(IStickSoftware module)
            {
                if (module == null)
                {
                    throw new ArgumentNullException(nameof(module));
                }

                return ConvertStickInto.Connect(hardware, module);
            }
        }

        private static ICancellation Connect(IStickHardware hardware, IStickSoftware software)
            => CancellationSource
            .Default
            .Synthesize(hardware.Touch.Produce(software.Touch))
            .Synthesize(hardware.Tilt.Produce(software.Tilt))
            .Build();

        /// <summary>
        /// Converts <see cref="IStickHardware"/> into <see cref="IPulsatedStickHardware"/>.
        /// </summary>
        /// <param name="hardware">
        /// <see cref="IStickHardware"/> to convert.
        /// </param>
        /// <param name="pulsation">
        /// <see cref="IStickPulsation"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="IPulsatedStickHardware"/> converted from <see cref="IStickHardware"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="hardware"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="pulsation"/> is null.
        /// </exception>
        public static IPulsatedStickHardware PulsatedStick(IStickHardware hardware, IStickPulsation pulsation)
        {
            if (hardware == null)
            {
                throw new ArgumentNullException(nameof(hardware));
            }
            if (pulsation == null)
            {
                throw new ArgumentNullException(nameof(pulsation));
            }

            return new PulsatedStickHardware(hardware, pulsation);
        }
        private sealed class PulsatedStickHardware :
            IPulsatedStickHardware
        {
            internal PulsatedStickHardware(IStickHardware hardware, IStickPulsation pulsation)
            {
                Touch = ProduceSignalTo.Convert(hardware.Touch, pulsation.Touch);

                Tilt = ConvertTiltInto.PulsatedTilt(hardware.Tilt, pulsation.Tilt);
            }

            public IProduction<Pulse> Touch { get; }

            public IPulsatedTiltHardware Tilt { get; }
        }

        /// <summary>
        /// Converts <see cref="IStickHardware"/> into <see cref="ITriggerHardware"/>.
        /// </summary>
        /// <param name="hardware">
        /// <see cref="IStickHardware"/> to convert.
        /// </param>
        /// <param name="translation">
        /// <see cref="ITranslation{TInput, TOutput}"/> to convert <see cref="Tilt"/> into <see cref="Pull"/>.
        /// </param>
        /// <returns>
        /// <see cref="ITriggerHardware"/> converted from <see cref="IStickHardware"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="hardware"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="translation"/> is null.
        /// </exception>
        public static ITriggerHardware Trigger(IStickHardware hardware, ITranslation<Tilt, Pull> translation)
        {
            if (hardware == null)
            {
                throw new ArgumentNullException(nameof(hardware));
            }
            if (translation == null)
            {
                throw new ArgumentNullException(nameof(translation));
            }

            return new TriggerHardware(hardware, translation);
        }
        private sealed class TriggerHardware :
            ITriggerHardware
        {
            internal TriggerHardware(IStickHardware hardware, ITranslation<Tilt, Pull> translation)
            {
                Touch = hardware.Touch;

                Pull = ProduceSignalTo.Convert(hardware.Tilt, translation);
            }

            public IProduction<Touch> Touch { get; }

            public IProduction<Pull> Pull { get; }
        }
    }
}
