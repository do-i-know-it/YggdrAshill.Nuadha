using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    public static class ConnectPoseTracker
    {
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
        public static IConnection<IPoseTrackerHardware> Hardware(IPoseTrackerSoftware software)
        {
            if (software == null)
            {
                throw new ArgumentNullException(nameof(software));
            }

            return new ConnectHardware(software);
        }
        private sealed class ConnectHardware :
            IConnection<IPoseTrackerHardware>
        {
            private readonly IPoseTrackerSoftware software;

            internal ConnectHardware(IPoseTrackerSoftware software)
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
        public static IConnection<IPoseTrackerSoftware> Software(IPoseTrackerHardware hardware)
        {
            if (hardware == null)
            {
                throw new ArgumentNullException(nameof(hardware));
            }

            return new ConnectSoftware(hardware);
        }
        private sealed class ConnectSoftware :
            IConnection<IPoseTrackerSoftware>
        {
            private readonly IPoseTrackerHardware hardware;

            internal ConnectSoftware(IPoseTrackerHardware hardware)
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
    }
}
