using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Defines extensions for <see cref="IHeadTrackerHardware"/> and <see cref="IHeadTrackerSoftware"/>.
    /// </summary>
    public static class HeadTrackerExtension
    {
        public static IEmission Conduct(this IHeadTrackerSoftware software, IHeadTrackerConfiguration configuration)
        {
            if (software == null)
            {
                throw new ArgumentNullException(nameof(software));
            }
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            return Nuadha.Conduct.HeadTracker(configuration, software);
        }

        public static ITransmission<IHeadTrackerSoftware> Transmit(this IHeadTrackerProtocol protocol, IHeadTrackerConfiguration configuration)
        {
            if (protocol == null)
            {
                throw new ArgumentNullException(nameof(protocol));
            }
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            return Nuadha.Transmit.HeadTracker(configuration, protocol);
        }

        public static IConnection<IHeadTrackerHardware> Connect(this IHeadTrackerSoftware software)
        {
            if (software == null)
            {
                throw new ArgumentNullException(nameof(software));
            }

            return Nuadha.Connect.HeadTracker(software);
        }

        public static IConnection<IHeadTrackerSoftware> Connect(this IHeadTrackerHardware hardware)
        {
            if (hardware == null)
            {
                throw new ArgumentNullException(nameof(hardware));
            }

            return Nuadha.Connect.HeadTracker(hardware);
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
