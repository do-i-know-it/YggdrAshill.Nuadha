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
