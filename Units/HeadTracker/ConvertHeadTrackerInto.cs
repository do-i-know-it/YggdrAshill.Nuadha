using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Conduction;
using System;

namespace YggdrAshill.Nuadha.Units
{
    /// <summary>
    /// Defines conversion for <see cref="IHeadTrackerProtocol"/>, <see cref="IHeadTrackerHardware"/> and <see cref="IHeadTrackerSoftware"/>.
    /// </summary>
    public static class ConvertHeadTrackerInto
    {
        /// <summary>
        /// Converts <see cref="IHeadTrackerProtocol"/> into <see cref="ITransmission{TModule}"/> for <see cref="IHeadTrackerSoftware"/>.
        /// </summary>
        /// <param name="protocol">
        /// <see cref="IHeadTrackerProtocol"/> to convert.
        /// </param>
        /// <param name="configuration">
        /// <see cref="IHeadTrackerConfiguration"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="ITransmission{TModule}"/> for <see cref="IHeadTrackerSoftware"/> converted from <see cref="IHeadTrackerProtocol"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="protocol"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="configuration"/> is null.
        /// </exception>
        public static ITransmission<IHeadTrackerSoftware> Transmission(IHeadTrackerProtocol protocol, IHeadTrackerConfiguration configuration)
        {
            if (protocol == null)
            {
                throw new ArgumentNullException(nameof(protocol));
            }
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            return new TransmitHeadTracker(configuration, protocol);
        }
        private sealed class TransmitHeadTracker :
            ITransmission<IHeadTrackerSoftware>
        {
            private readonly IEmission emission;

            private readonly IConnection<IHeadTrackerSoftware> connection;

            internal TransmitHeadTracker(IHeadTrackerConfiguration configuration, IHeadTrackerProtocol protocol)
            {
                emission = Conduct(configuration, protocol.Software);

                connection = ConvertHeadTrackerInto.Connection(protocol.Hardware);
            }

            public ICancellation Connect(IHeadTrackerSoftware module)
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
        private static IEmission Conduct(IHeadTrackerConfiguration configuration, IHeadTrackerSoftware software)
            => EmissionSource
            .Default
            .Synthesize(ConductSignalTo.Consume(configuration.Pose.Position, software.Pose.Position))
            .Synthesize(ConductSignalTo.Consume(configuration.Pose.Rotation, software.Pose.Rotation))
            .Synthesize(ConductSignalTo.Consume(configuration.Direction, software.Direction))
            .Build();

        /// <summary>
        /// Converts <see cref="IHeadTrackerSoftware"/> into <see cref="IConnection{TModule}"/> for <see cref="IHeadTrackerHardware"/>.
        /// </summary>
        /// <param name="software">
        /// <see cref="IHeadTrackerSoftware"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="IConnection{TModule}"/> for <see cref="IHeadTrackerHardware"/> converted from <see cref="IHeadTrackerSoftware"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="software"/> is null.
        /// </exception>
        public static IConnection<IHeadTrackerHardware> Connection(IHeadTrackerSoftware software)
        {
            if (software == null)
            {
                throw new ArgumentNullException(nameof(software));
            }

            return new ConnectHeadTrackerHardware(software);
        }
        private sealed class ConnectHeadTrackerHardware :
            IConnection<IHeadTrackerHardware>
        {
            private readonly IHeadTrackerSoftware software;

            internal ConnectHeadTrackerHardware(IHeadTrackerSoftware software)
            {
                this.software = software;
            }

            public ICancellation Connect(IHeadTrackerHardware module)
            {
                if (module == null)
                {
                    throw new ArgumentNullException(nameof(module));
                }

                return ConvertHeadTrackerInto.Connect(module, software);
            }
        }

        /// <summary>
        /// Converts <see cref="IHeadTrackerHardware"/> into <see cref="IConnection{TModule}"/> for <see cref="IHeadTrackerSoftware"/>.
        /// </summary>
        /// <param name="hardware">
        /// <see cref="IHeadTrackerSoftware"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="IConnection{TModule}"/> for <see cref="IHeadTrackerSoftware"/> converted from <see cref="IHeadTrackerHardware"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="hardware"/> is null.
        /// </exception>
        public static IConnection<IHeadTrackerSoftware> Connection(IHeadTrackerHardware hardware)
        {
            if (hardware == null)
            {
                throw new ArgumentNullException(nameof(hardware));
            }

            return new ConnectHeadTrackerSoftware(hardware);
        }
        private sealed class ConnectHeadTrackerSoftware :
            IConnection<IHeadTrackerSoftware>
        {
            private readonly IHeadTrackerHardware hardware;

            internal ConnectHeadTrackerSoftware(IHeadTrackerHardware hardware)
            {
                this.hardware = hardware;
            }

            public ICancellation Connect(IHeadTrackerSoftware module)
            {
                if (module == null)
                {
                    throw new ArgumentNullException(nameof(module));
                }

                return ConvertHeadTrackerInto.Connect(hardware, module);
            }
        }

        private static ICancellation Connect(IHeadTrackerHardware hardware, IHeadTrackerSoftware software)
            => CancellationSource
            .Default
            .Synthesize(hardware.Pose.Position.Produce(software.Pose.Position))
            .Synthesize(hardware.Pose.Rotation.Produce(software.Pose.Rotation))
            .Synthesize(hardware.Direction.Produce(software.Direction))
            .Build();
    }
}
