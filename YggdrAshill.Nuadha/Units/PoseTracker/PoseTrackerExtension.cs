using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Defines extensions for <see cref="IPoseTrackerProtocol"/>, <see cref="IPoseTrackerHardware"/> and <see cref="IPoseTrackerSoftware"/>.
    /// </summary>
    public static class PoseTrackerExtension
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
        public static ITransmission<IPoseTrackerSoftware> Transmit(this IPoseTrackerProtocol protocol, IPoseTrackerConfiguration configuration)
        {
            if (protocol == null)
            {
                throw new ArgumentNullException(nameof(protocol));
            }
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            return ConvertPoseTrackerInto.Transmission(protocol, configuration);
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

            return ConvertPoseTrackerInto.Connection(software);
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
        public static IConnection<IPoseTrackerSoftware> Connect(this IPoseTrackerHardware hardware)
        {
            if (hardware == null)
            {
                throw new ArgumentNullException(nameof(hardware));
            }

            return ConvertPoseTrackerInto.Connection(hardware);
        }

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
        public static IPoseTrackerHardware Correct(this IPoseTrackerHardware hardware, IPoseTrackerCorrection correction)
        {
            if (hardware == null)
            {
                throw new ArgumentNullException(nameof(hardware));
            }
            if (correction == null)
            {
                throw new ArgumentNullException(nameof(correction));
            }

            return ConvertPoseTrackerInto.CorrectedPoseTracker(hardware, correction);
        }

        /// <summary>
        /// Calibrates <see cref="IPoseTrackerHardware"/>.
        /// </summary>
        /// <param name="hardware">
        /// <see cref="IPoseTrackerHardware"/> to calibrate.
        /// </param>
        /// <param name="configuration">
        /// <see cref="IPoseTrackerConfiguration"/> to calibrate.
        /// </param>
        /// <returns>
        /// <see cref="IPoseTrackerHardware"/> calibrated.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="hardware"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="configuration"/> is null.
        /// </exception>
        public static IPoseTrackerHardware Calibrate(this IPoseTrackerHardware hardware, IPoseTrackerConfiguration configuration)
        {
            if (hardware == null)
            {
                throw new ArgumentNullException(nameof(hardware));
            }
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            return hardware.Correct(PoseTrackerTo.Calibrate(configuration));
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
        public static IPoseTrackerSoftware Correct(this IPoseTrackerSoftware software, IPoseTrackerCorrection correction)
        {
            if (software == null)
            {
                throw new ArgumentNullException(nameof(software));
            }
            if (correction == null)
            {
                throw new ArgumentNullException(nameof(correction));
            }

            return ConvertPoseTrackerInto.CorrectedPoseTracker(software, correction);
        }

        /// <summary>
        /// Calibrates <see cref="IPoseTrackerSoftware"/>.
        /// </summary>
        /// <param name="software">
        /// <see cref="IPoseTrackerSoftware"/> to calibrate.
        /// </param>
        /// <param name="configuration">
        /// <see cref="IPoseTrackerConfiguration"/> to calibrate.
        /// </param>
        /// <returns>
        /// <see cref="IPoseTrackerSoftware"/> calibrated.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="software"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="configuration"/> is null.
        /// </exception>
        public static IPoseTrackerSoftware Calibrate(this IPoseTrackerSoftware software, IPoseTrackerConfiguration configuration)
        {
            if (software == null)
            {
                throw new ArgumentNullException(nameof(software));
            }
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            return software.Correct(PoseTrackerTo.Calibrate(configuration));
        }
    }
}
