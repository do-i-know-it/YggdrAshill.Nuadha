using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Signals;
using YggdrAshill.Nuadha.Units;
using System;
using YggdrAshill.Nuadha.Transformation;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Defines extensions for <see cref="IPoseTrackerHardware"/> and <see cref="IPoseTrackerSoftware"/>.
    /// </summary>
    public static class PoseTrackerExtension
    {
        /// <summary>
        /// Converts <see cref="IPoseTrackerProtocol"/> into <see cref="IIgnition{TModule}"/> for <see cref="IPoseTrackerSoftware"/>.
        /// </summary>
        /// <param name="protocol">
        /// <see cref="IPoseTrackerProtocol"/> to convert.
        /// </param>
        /// <param name="configuration">
        /// <see cref="IPoseTrackerConfiguration"/> to ignite.
        /// </param>
        /// <returns>
        /// <see cref="IIgnition{TModule}"/> to ignite <see cref="IPoseTrackerSoftware"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="protocol"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="configuration"/> is null.
        /// </exception>
        public static IIgnition<IPoseTrackerSoftware> Ignite(this IPoseTrackerProtocol protocol, IPoseTrackerConfiguration configuration)
        {
            if (protocol == null)
            {
                throw new ArgumentNullException(nameof(protocol));
            }
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            return new IgnitePoseTracker(protocol, configuration);
        }
        private sealed class IgnitePoseTracker :
            IIgnition<IPoseTrackerSoftware>
        {
            private readonly ITransmission<Space3D.Position> position;

            private readonly ITransmission<Space3D.Rotation> rotation;

            internal IgnitePoseTracker(IPoseTrackerProtocol protocol, IPoseTrackerConfiguration configuration)
            {
                position = protocol.Position.Ignite(configuration.Position);

                rotation = protocol.Rotation.Ignite(configuration.Rotation);
            }

            public ICancellation Connect(IPoseTrackerSoftware module)
            {
                if (module == null)
                {
                    throw new ArgumentNullException(nameof(module));
                }

                var composite = new CompositeCancellation();

                position.Produce(module.Position).Synthesize(composite);
                rotation.Produce(module.Rotation).Synthesize(composite);

                return composite;
            }

            public void Emit()
            {
                position.Emit();

                rotation.Emit();
            }

            public void Dispose()
            {
                position.Dispose();

                rotation.Dispose();
            }
        }

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
        public static IConnection<IPoseTrackerHardware> Connect(this IPoseTrackerSoftware software)
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

                var composite = new CompositeCancellation();

                module.Position.Produce(software.Position).Synthesize(composite);
                module.Rotation.Produce(software.Rotation).Synthesize(composite);

                return composite;
            }
        }

        /// <summary>
        /// Converts <see cref="IPoseTrackerHardware"/> into <see cref="IConnection{TModule}"/> for <see cref="IPoseTrackerSoftware"/>.
        /// </summary>
        /// <param name="hardware">
        /// <see cref="IPoseTrackerHardware"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="IConnection{TModule}"/> for <see cref="IPoseTrackerSoftware"/> converted from <see cref="IPoseTrackerHardware"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="hardware"/> is null.
        /// </exception>
        public static IConnection<IPoseTrackerSoftware> Connect(this IPoseTrackerHardware hardware)
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

                var composite = new CompositeCancellation();

                hardware.Position.Produce(module.Position).Synthesize(composite);
                hardware.Rotation.Produce(module.Rotation).Synthesize(composite);

                return composite;
            }
        }

        /// <summary>
        /// Calibrates <see cref="IPoseTrackerHardware"/>.
        /// </summary>
        /// <param name="module">
        /// <see cref="IPoseTrackerHardware"/> to calibrate.
        /// </param>
        /// <param name="configuration">
        /// <see cref="IPoseTrackerConfiguration"/> to calibrate.
        /// </param>
        /// <returns>
        /// <see cref="IPoseTrackerSoftware"/> calibrated.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="module"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="configuration"/> is null.
        /// </exception>
        public static IPoseTrackerHardware Calibrate(this IPoseTrackerHardware module, IPoseTrackerConfiguration configuration)
        {
            if (module == null)
            {
                throw new ArgumentNullException(nameof(module));
            }

            return new CalibratedPoseTrackerHardware(module, configuration);
        }
        private sealed class CalibratedPoseTrackerHardware :
            IPoseTrackerHardware
        {
            internal CalibratedPoseTrackerHardware(IPoseTrackerHardware module, IPoseTrackerConfiguration configuration)
            {
                Position = ConvertTo.Produce(module.Position, Space3DPositionTo.Calibrate(configuration.Position));

                Rotation = ConvertTo.Produce(module.Rotation, Space3DRotationTo.Calibrate(configuration.Rotation));
            }

            public IProduction<Space3D.Position> Position { get; }

            public IProduction<Space3D.Rotation> Rotation { get; }
        }
    }
}
