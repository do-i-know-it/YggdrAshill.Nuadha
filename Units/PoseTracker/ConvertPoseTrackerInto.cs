using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Signals;
using System;

namespace YggdrAshill.Nuadha.Units
{
    /// <summary>
    /// Defines conversion for <see cref="IPoseTrackerProtocol"/>, <see cref="IPoseTrackerHardware"/> and <see cref="IPoseTrackerSoftware"/>.
    /// </summary>
    public static class ConvertPoseTrackerInto
    {
        /// <summary>
        /// Converts <see cref="IPoseTrackerProtocol"/> into <see cref="ITransmission{TModule}"/> for <see cref="IPoseTrackerSoftware"/>.
        /// </summary>
        /// <param name="protocol">
        /// <see cref="IPoseTrackerProtocol"/> to convert.
        /// </param>
        /// <param name="configuration">
        /// <see cref="IPoseTrackerConfiguration"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="ITransmission{TModule}"/> for <see cref="IPoseTrackerSoftware"/> converted from <see cref="IPoseTrackerProtocol"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="protocol"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="configuration"/> is null.
        /// </exception>
        public static ITransmission<IPoseTrackerSoftware> Transmission(IPoseTrackerProtocol protocol, IPoseTrackerConfiguration configuration)
        {
            if (protocol == null)
            {
                throw new ArgumentNullException(nameof(protocol));
            }
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            return new TransmitPoseTracker(configuration, protocol);
        }
        private sealed class TransmitPoseTracker :
            ITransmission<IPoseTrackerSoftware>
        {
            private readonly IEmission emission;

            private readonly IConnection<IPoseTrackerSoftware> connection;

            internal TransmitPoseTracker(IPoseTrackerConfiguration configuration, IPoseTrackerProtocol protocol)
            {
                emission = Conduct(configuration, protocol.Software);

                connection = ConvertPoseTrackerInto.Connection(protocol.Hardware);
            }

            public ICancellation Connect(IPoseTrackerSoftware module)
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
        private static IEmission Conduct(IPoseTrackerConfiguration configuration, IPoseTrackerSoftware software)
            => EmissionSource
            .Default
            .Synthesize(ConductSignalTo.Consume(configuration.Position, software.Position))
            .Synthesize(ConductSignalTo.Consume(configuration.Rotation, software.Rotation))
            .Build();

        /// <summary>
        /// Converts <see cref="IPoseTrackerSoftware"/> into <see cref="IConnection{TModule}"/> for <see cref="IPoseTrackerHardware"/>.
        /// </summary>
        /// <param name="software">
        /// <see cref="IPoseTrackerSoftware"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="IConnection{TModule}"/> for <see cref="IPoseTrackerHardware"/> converted from <see cref="IPoseTrackerSoftware"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="software"/> is null.
        /// </exception>
        public static IConnection<IPoseTrackerHardware> Connection(IPoseTrackerSoftware software)
        {
            if (software == null)
            {
                throw new ArgumentNullException(nameof(software));
            }

            return new ConnectPoseTrackerHardware(software);
        }
        private sealed class ConnectPoseTrackerHardware :
            IConnection<IPoseTrackerHardware>
        {
            private readonly IPoseTrackerSoftware software;

            internal ConnectPoseTrackerHardware(IPoseTrackerSoftware software)
            {
                this.software = software;
            }

            public ICancellation Connect(IPoseTrackerHardware module)
            {
                if (module == null)
                {
                    throw new ArgumentNullException(nameof(module));
                }

                return ConvertPoseTrackerInto.Connect(module, software);
            }
        }

        /// <summary>
        /// Converts <see cref="IPoseTrackerHardware"/> into <see cref="IConnection{TModule}"/> for <see cref="IPoseTrackerSoftware"/>.
        /// </summary>
        /// <param name="hardware">
        /// <see cref="IPoseTrackerSoftware"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="IConnection{TModule}"/> for <see cref="IPoseTrackerSoftware"/> converted from <see cref="IPoseTrackerHardware"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="hardware"/> is null.
        /// </exception>
        public static IConnection<IPoseTrackerSoftware> Connection(IPoseTrackerHardware hardware)
        {
            if (hardware == null)
            {
                throw new ArgumentNullException(nameof(hardware));
            }

            return new ConnectPoseTrackerSoftware(hardware);
        }
        private sealed class ConnectPoseTrackerSoftware :
            IConnection<IPoseTrackerSoftware>
        {
            private readonly IPoseTrackerHardware hardware;

            internal ConnectPoseTrackerSoftware(IPoseTrackerHardware hardware)
            {
                this.hardware = hardware;
            }

            public ICancellation Connect(IPoseTrackerSoftware module)
            {
                if (module == null)
                {
                    throw new ArgumentNullException(nameof(module));
                }

                return ConvertPoseTrackerInto.Connect(hardware, module);
            }
        }

        private static ICancellation Connect(IPoseTrackerHardware hardware, IPoseTrackerSoftware software)
            => CancellationSource
            .Default
            .Synthesize(hardware.Position.Produce(software.Position))
            .Synthesize(hardware.Rotation.Produce(software.Rotation))
            .Build();

        /// <summary>
        /// Converts <see cref="IPoseTrackerHardware"/> into <see cref="IPoseTrackerHardware"/>.
        /// </summary>
        /// <param name="hardware">
        /// <see cref="IPoseTrackerHardware"/> to convert.
        /// </param>
        /// <param name="correction">
        /// <see cref="IPoseTrackerCorrection"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="IPoseTrackerHardware"/> converted from <see cref="IPoseTrackerHardware"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="hardware"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="correction"/> is null.
        /// </exception>
        public static IPoseTrackerHardware CorrectedPoseTracker(IPoseTrackerHardware hardware, IPoseTrackerCorrection correction)
        {
            if (hardware == null)
            {
                throw new ArgumentNullException(nameof(hardware));
            }
            if (correction == null)
            {
                throw new ArgumentNullException(nameof(correction));
            }

            return new PoseTrackerHardware(hardware, correction);
        }
        private sealed class PoseTrackerHardware :
            IPoseTrackerHardware
        {
            internal PoseTrackerHardware(IPoseTrackerHardware hardware, IPoseTrackerCorrection correction)
            {
                Position = ProduceSignalTo.Convert(hardware.Position, correction.Position);

                Rotation = ProduceSignalTo.Convert(hardware.Rotation, correction.Rotation);
            }

            public IProduction<Space3D.Position> Position { get; }

            public IProduction<Space3D.Rotation> Rotation { get; }
        }

        /// <summary>
        /// Converts <see cref="IPoseTrackerSoftware"/> into <see cref="IPoseTrackerSoftware"/>.
        /// </summary>
        /// <param name="software">
        /// <see cref="IPoseTrackerSoftware"/> to convert.
        /// </param>
        /// <param name="correction">
        /// <see cref="IPoseTrackerCorrection"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="IPoseTrackerSoftware"/> converted from <see cref="IPoseTrackerSoftware"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="software"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="correction"/> is null.
        /// </exception>
        public static IPoseTrackerSoftware CorrectedPoseTracker(IPoseTrackerSoftware software, IPoseTrackerCorrection correction)
        {
            if (software == null)
            {
                throw new ArgumentNullException(nameof(software));
            }
            if (correction == null)
            {
                throw new ArgumentNullException(nameof(correction));
            }

            return new PoseTrackerSoftware(software, correction);
        }
        private sealed class PoseTrackerSoftware :
            IPoseTrackerSoftware
        {
            internal PoseTrackerSoftware(IPoseTrackerSoftware software, IPoseTrackerCorrection correction)
            {
                Position = ConsumeSignalTo.Convert(correction.Position, software.Position);

                Rotation = ConsumeSignalTo.Convert(correction.Rotation, software.Rotation);
            }

            public IConsumption<Space3D.Position> Position { get; }

            public IConsumption<Space3D.Rotation> Rotation { get; }
        }
    }
}
