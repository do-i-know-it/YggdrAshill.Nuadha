using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Defines extensions for <see cref="IHandControllerHardware"/> and <see cref="IHandControllerSoftware"/>.
    /// </summary>
    public static class HandControllerExtension
    {
        public static IEmission Conduct(this IHandControllerSoftware software, IHandControllerConfiguration configuration)
        {
            if (software == null)
            {
                throw new ArgumentNullException(nameof(software));
            }
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            return Nuadha.Conduct.HandController(configuration, software);
        }

        public static ITransmission<IHandControllerSoftware> Transmit(this IHandControllerProtocol protocol, IHandControllerConfiguration configuration)
        {
            if (protocol == null)
            {
                throw new ArgumentNullException(nameof(protocol));
            }
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            return Nuadha.Transmit.HandController(configuration, protocol);
        }

        public static IConnection<IHandControllerHardware> Connect(this IHandControllerSoftware software)
        {
            if (software == null)
            {
                throw new ArgumentNullException(nameof(software));
            }

            return Nuadha.Connect.HandController(software);
        }

        public static IConnection<IHandControllerSoftware> Connect(this IHandControllerHardware hardware)
        {
            if (hardware == null)
            {
                throw new ArgumentNullException(nameof(hardware));
            }

            return Nuadha.Connect.HandController(hardware);
        }

        /// <summary>
        /// Converts <see cref="IHandControllerHardware"/> into <see cref="IPulsatedHandControllerHardware"/>.
        /// </summary>
        /// <param name="hardware">
        /// <see cref="IHandControllerHardware"/> to convert.
        /// </param>
        /// <param name="pulsation">
        /// <see cref="IHandControllerPulsation"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="IPulsatedHandControllerHardware"/> converted from <see cref="IHandControllerHardware"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="hardware"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="pulsation"/> is null.
        /// </exception>
        public static IPulsatedHandControllerHardware Pulsate(this IHandControllerHardware hardware, IHandControllerPulsation pulsation)
        {
            if (hardware == null)
            {
                throw new ArgumentNullException(nameof(hardware));
            }
            if (pulsation == null)
            {
                throw new ArgumentNullException(nameof(pulsation));
            }

            return ConvertHandControllerInto.PulsatedHandController(hardware, pulsation);
        }

        /// <summary>
        /// Converts <see cref="IHandControllerHardware"/> into <see cref="IPulsatedHandControllerHardware"/>.
        /// </summary>
        /// <param name="hardware">
        /// <see cref="IHandControllerHardware"/> to convert.
        /// </param>
        /// <param name="threshold">
        /// <see cref="HandControllerThreshold"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="IPulsatedHandControllerHardware"/> converted from <see cref="IHandControllerHardware"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="hardware"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="threshold"/> is null.
        /// </exception>
        public static IPulsatedHandControllerHardware Pulsate(this IHandControllerHardware hardware, HandControllerThreshold threshold)
        {
            if (hardware == null)
            {
                throw new ArgumentNullException(nameof(hardware));
            }
            if (threshold == null)
            {
                throw new ArgumentNullException(nameof(threshold));
            }

            return hardware.Pulsate(Nuadha.Pulsate.HandController(threshold));
        }

        /// <summary>
        /// Converts <see cref="IHandControllerHardware"/> into <see cref="IPoseTrackerHardware"/>.
        /// </summary>
        /// <param name="hardware">
        /// <see cref="IHandControllerHardware"/> to convert.
        /// </param>
        /// <param name="configuration">
        /// <see cref="IPoseTrackerConfiguration"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="IPoseTrackerHardware"/> converted from <see cref="IHandControllerHardware"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="hardware"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="configuration"/> is null.
        /// </exception>
        public static IPoseTrackerHardware ToPoseTracker(this IHandControllerHardware hardware, IPoseTrackerConfiguration configuration)
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
