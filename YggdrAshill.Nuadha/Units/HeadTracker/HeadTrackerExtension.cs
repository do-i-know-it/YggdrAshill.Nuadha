using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Defines extensions for <see cref="IHeadTrackerProtocol"/>, <see cref="IHeadTrackerHardware"/> and <see cref="IHeadTrackerSoftware"/>.
    /// </summary>
    public static class HeadTrackerExtension
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

            return ConvertHeadTrackerInto.Transmission(protocol, configuration);
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

            return ConvertHeadTrackerInto.Connection(software);
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
        public static IConnection<IHeadTrackerSoftware> Connect(this IHeadTrackerHardware hardware)
        {
            if (hardware == null)
            {
                throw new ArgumentNullException(nameof(hardware));
            }

            return ConvertHeadTrackerInto.Connection(hardware);
        }
    }
}
