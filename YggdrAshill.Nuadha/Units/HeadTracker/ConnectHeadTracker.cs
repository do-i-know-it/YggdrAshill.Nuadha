using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    public static class ConnectHeadTracker
    {
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
        public static IConnection<IHeadTrackerHardware> Hardware(IHeadTrackerSoftware software)
        {
            if (software == null)
            {
                throw new ArgumentNullException(nameof(software));
            }

            return new ConnectHardware(software);
        }
        private sealed class ConnectHardware :
            IConnection<IHeadTrackerHardware>
        {
            private readonly IHeadTrackerSoftware software;

            internal ConnectHardware(IHeadTrackerSoftware software)
            {
                this.software = software;
            }

            public ICancellation Connect(IHeadTrackerHardware module)
            {
                if (module == null)
                {
                    throw new ArgumentNullException(nameof(module));
                }

                var composite = new CompositeCancellation();

                module.Pose.Position.Produce(software.Pose.Position).Synthesize(composite);
                module.Pose.Rotation.Produce(software.Pose.Rotation).Synthesize(composite);
                module.Direction.Produce(software.Direction).Synthesize(composite);

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

            return new ConnectSoftware(hardware);
        }
        private sealed class ConnectSoftware :
            IConnection<IHeadTrackerSoftware>
        {
            private readonly IHeadTrackerHardware hardware;

            internal ConnectSoftware(IHeadTrackerHardware hardware)
            {
                this.hardware = hardware;
            }

            public ICancellation Connect(IHeadTrackerSoftware module)
            {
                if (module == null)
                {
                    throw new ArgumentNullException(nameof(module));
                }

                var composite = new CompositeCancellation();

                hardware.Pose.Position.Produce(module.Pose.Position).Synthesize(composite);
                hardware.Pose.Rotation.Produce(module.Pose.Rotation).Synthesize(composite);
                hardware.Direction.Produce(module.Direction).Synthesize(composite);

                return composite;
            }
        }
    }
}
