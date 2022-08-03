using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Conduction;
using System;

namespace YggdrAshill.Nuadha.Units
{
    /// <summary>
    /// Defines conversion for <see cref="IHandControllerProtocol"/>, <see cref="IHandControllerHardware"/> and <see cref="IHandControllerSoftware"/>.
    /// </summary>
    public static class ConvertHandControllerInto
    {
        /// <summary>
        /// Converts <see cref="IHandControllerProtocol"/> into <see cref="ITransmission{TModule}"/> for <see cref="IHandControllerSoftware"/>.
        /// </summary>
        /// <param name="protocol">
        /// <see cref="IHandControllerProtocol"/> to convert.
        /// </param>
        /// <param name="configuration">
        /// <see cref="IHandControllerConfiguration"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="ITransmission{TModule}"/> for <see cref="IHandControllerSoftware"/> converted from <see cref="IHandControllerProtocol"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="protocol"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="configuration"/> is null.
        /// </exception>
        public static ITransmission<IHandControllerSoftware> Transmission(IHandControllerProtocol protocol, IHandControllerConfiguration configuration)
        {
            if (protocol == null)
            {
                throw new ArgumentNullException(nameof(protocol));
            }
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            return new TransmitHandController(configuration, protocol);
        }
        private sealed class TransmitHandController :
            ITransmission<IHandControllerSoftware>
        {
            private readonly IEmission emission;

            private readonly IConnection<IHandControllerSoftware> connection;

            internal TransmitHandController(IHandControllerConfiguration configuration, IHandControllerProtocol protocol)
            {
                emission = Conduct(configuration, protocol.Software);

                connection = ConvertHandControllerInto.Connection(protocol.Hardware);
            }

            public ICancellation Connect(IHandControllerSoftware module)
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
        private static IEmission Conduct(IHandControllerConfiguration configuration, IHandControllerSoftware software)
            => EmissionSource
            .Default
            .Synthesize(ConductSignalTo.Consume(configuration.HandGrip, software.HandGrip))
            .Synthesize(ConductSignalTo.Consume(configuration.IndexFinger, software.IndexFinger))
            .Synthesize(ConductSignalTo.Consume(configuration.Thumb, software.Thumb))
            .Synthesize(ConductSignalTo.Consume(configuration.Pose, software.Pose))
            .Build();

        /// <summary>
        /// Converts <see cref="IHandControllerSoftware"/> into <see cref="IConnection{TModule}"/> for <see cref="IHandControllerHardware"/>.
        /// </summary>
        /// <param name="software">
        /// <see cref="IHandControllerSoftware"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="IConnection{TModule}"/> for <see cref="IHandControllerHardware"/> converted from <see cref="IHandControllerSoftware"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="software"/> is null.
        /// </exception>
        public static IConnection<IHandControllerHardware> Connection(IHandControllerSoftware software)
        {
            if (software == null)
            {
                throw new ArgumentNullException(nameof(software));
            }

            return new ConnectHandControllerHardware(software);
        }
        private sealed class ConnectHandControllerHardware :
            IConnection<IHandControllerHardware>
        {
            private readonly IHandControllerSoftware software;

            internal ConnectHandControllerHardware(IHandControllerSoftware software)
            {
                this.software = software;
            }

            public ICancellation Connect(IHandControllerHardware module)
            {
                if (module == null)
                {
                    throw new ArgumentNullException(nameof(module));
                }

                return ConvertHandControllerInto.Connect(module, software);
            }
        }

        /// <summary>
        /// Converts <see cref="IHandControllerHardware"/> into <see cref="IConnection{TModule}"/> for <see cref="IHandControllerSoftware"/>.
        /// </summary>
        /// <param name="hardware">
        /// <see cref="IHandControllerSoftware"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="IConnection{TModule}"/> for <see cref="IHandControllerSoftware"/> converted from <see cref="IHandControllerHardware"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="hardware"/> is null.
        /// </exception>
        public static IConnection<IHandControllerSoftware> Connection(IHandControllerHardware hardware)
        {
            if (hardware == null)
            {
                throw new ArgumentNullException(nameof(hardware));
            }

            return new ConnectHandControllerSoftware(hardware);
        }
        private sealed class ConnectHandControllerSoftware :
            IConnection<IHandControllerSoftware>
        {
            private readonly IHandControllerHardware hardware;

            internal ConnectHandControllerSoftware(IHandControllerHardware hardware)
            {
                this.hardware = hardware;
            }

            public ICancellation Connect(IHandControllerSoftware module)
            {
                if (module == null)
                {
                    throw new ArgumentNullException(nameof(module));
                }

                return ConvertHandControllerInto.Connect(hardware, module);
            }
        }

        private static ICancellation Connect(IHandControllerHardware hardware, IHandControllerSoftware software)
            => CancellationSource
            .Default
            .Synthesize(hardware.HandGrip.Produce(software.HandGrip))
            .Synthesize(hardware.IndexFinger.Produce(software.IndexFinger))
            .Synthesize(hardware.Thumb.Produce(software.Thumb))
            .Synthesize(hardware.Pose.Produce(software.Pose))
            .Build();
    }
}
