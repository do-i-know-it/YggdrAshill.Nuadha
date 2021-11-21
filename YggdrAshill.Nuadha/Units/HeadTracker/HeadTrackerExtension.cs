using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Signals;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Defines extensions for <see cref="IHeadTrackerHardware"/> and <see cref="IHeadTrackerSoftware"/>.
    /// </summary>
    public static class HeadTrackerExtension
    {
        /// <summary>
        /// Converts <see cref="HeadTracker"/> into <see cref="IIgnition{TModule}"/> for <see cref="IHeadTrackerSoftware"/>.
        /// </summary>
        /// <param name="protocol">
        /// <see cref="IHeadTrackerProtocol"/> to convert.
        /// </param>
        /// <param name="configuration">
        /// <see cref="IHeadTrackerConfiguration"/> to ignite.
        /// </param>
        /// <returns>
        /// <see cref="IIgnition{TModule}"/> to ignite <see cref="IHeadTrackerSoftware"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="protocol"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="configuration"/> is null.
        /// </exception>
        public static IIgnition<IHeadTrackerSoftware> Ignite(this IHeadTrackerProtocol protocol, IHeadTrackerConfiguration configuration)
        {
            if (protocol == null)
            {
                throw new ArgumentNullException(nameof(protocol));
            }
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            return new IgniteHeadTracker(protocol, configuration);
        }
        private sealed class IgniteHeadTracker :
            IIgnition<IHeadTrackerSoftware>
        {
            private readonly IIgnition<IPoseTrackerSoftware> pose;

            private readonly ITransmission<Space3D.Direction> direction;

            internal IgniteHeadTracker(IHeadTrackerProtocol protocol, IHeadTrackerConfiguration configuration)
            {
                pose = protocol.Pose.Ignite(configuration.Pose);

                direction = protocol.Direction.Ignite(configuration.Direction);
            }

            public ICancellation Connect(IHeadTrackerSoftware module)
            {
                if (module == null)
                {
                    throw new ArgumentNullException(nameof(module));
                }

                var composite = new CompositeCancellation();

                pose.Connect(module.Pose).Synthesize(composite);
                direction.Produce(module.Direction).Synthesize(composite);

                return composite;
            }

            public void Emit()
            {
                pose.Emit();

                direction.Emit();
            }

            public void Dispose()
            {
                pose.Dispose();

                direction.Dispose();
            }
        }

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
        public static IConnection<IHeadTrackerHardware> Connect(this IHeadTrackerSoftware software)
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
            private readonly IConnection<IPoseTrackerHardware> pose;

            private readonly IConsumption<Space3D.Direction> direction;

            internal ConnectHeadTrackerHardware(IHeadTrackerSoftware software)
            {
                pose = software.Pose.Connect();

                direction = software.Direction;
            }

            public ICancellation Connect(IHeadTrackerHardware module)
            {
                if (module == null)
                {
                    throw new ArgumentNullException(nameof(module));
                }

                var composite = new CompositeCancellation();

                pose.Connect(module.Pose).Synthesize(composite);
                module.Direction.Produce(direction).Synthesize(composite);

                return composite;
            }
        }

        /// <summary>
        /// Converts <see cref="IHeadTrackerHardware"/> into <see cref="IConnection{TModule}"/> for <see cref="IHeadTrackerSoftware"/>.
        /// </summary>
        /// <param name="hardware">
        /// <see cref="IHeadTrackerHardware"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="IConnection{TModule}"/> for <see cref="IHeadTrackerSoftware"/> converted from <see cref="IHeadTrackerHardware"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="hardware"/> is null.
        /// </exception>
        public static IConnection<IHeadTrackerSoftware> Connect(this IHeadTrackerHardware hardware)
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
            private readonly IConnection<IPoseTrackerSoftware> pose;

            private readonly IProduction<Space3D.Direction> direction;

            internal ConnectHeadTrackerSoftware(IHeadTrackerHardware hardware)
            {
                direction = hardware.Direction;

                pose = hardware.Pose.Connect();
            }

            public ICancellation Connect(IHeadTrackerSoftware module)
            {
                if (module == null)
                {
                    throw new ArgumentNullException(nameof(module));
                }

                var composite = new CompositeCancellation();

                pose.Connect(module.Pose).Synthesize(composite);
                direction.Produce(module.Direction).Synthesize(composite);

                return composite;
            }
        }

        /// <summary>
        /// Converts <see cref="IHeadTrackerHardware"/> into <see cref="IPoseTrackerHardware"/>.
        /// </summary>
        /// <param name="hardware">
        /// <see cref="IHeadTrackerHardware"/> to convert.
        /// </param>
        /// <param name="configuration">
        /// <see cref="IPoseTrackerConfiguration"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="IPoseTrackerHardware"/> converted from <see cref="IHeadTrackerHardware"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="hardware"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="configuration"/> is null.
        /// </exception>
        public static IPoseTrackerHardware ToPoseTracker(this IHeadTrackerHardware hardware, IPoseTrackerConfiguration configuration)
        {
            if (hardware == null)
            {
                throw new ArgumentNullException(nameof(hardware));
            }
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            return hardware.Pose.Calibrate(configuration);
        }
    }
}
