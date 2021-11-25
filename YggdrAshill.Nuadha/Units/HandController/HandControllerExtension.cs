using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Defines extensions for <see cref="IHandControllerProtocol"/>, <see cref="IHandControllerHardware"/> and <see cref="IHandControllerSoftware"/>.
    /// </summary>
    public static class HandControllerExtension
    {
        /// <summary>
        /// Converts <see cref="IHandControllerProtocol"/> into <see cref="ITransmission{TModule}"/> for <see cref="IHandControllerSoftware"/>.
        /// </summary>
        /// <param name="protocol">
        /// <see cref="IHandControllerProtocol"/> to convert.
        /// </param>
        /// <param name="configuration">
        /// <see cref="IHandControllerConfiguration"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="ITransmission{TModule}"/> for <see cref="IHandControllerSoftware"/> converted from <see cref="IHandControllerProtocol"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="protocol"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="configuration"/> is null.
        /// </exception>
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

            return ConvertHandControllerInto.Transmission(protocol, configuration);
        }

        /// <summary>
        /// Converts <see cref="IHandControllerSoftware"/> into <see cref="IConnection{TModule}"/> for <see cref="IHandControllerHardware"/>.
        /// </summary>
        /// <param name="software">
        /// <see cref="IHandControllerSoftware"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="IConnection{TModule}"/> for <see cref="IHandControllerHardware"/> converted from <see cref="IHandControllerSoftware"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="software"/> is null.
        /// </exception>
        public static IConnection<IHandControllerHardware> Connect(this IHandControllerSoftware software)
        {
            if (software == null)
            {
                throw new ArgumentNullException(nameof(software));
            }

            return ConvertHandControllerInto.Connection(software);
        }

        /// <summary>
        /// Converts <see cref="IHandControllerHardware"/> into <see cref="IConnection{TModule}"/> for <see cref="IHandControllerSoftware"/>.
        /// </summary>
        /// <param name="hardware">
        /// <see cref="IHandControllerSoftware"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="IConnection{TModule}"/> for <see cref="IHandControllerSoftware"/> converted from <see cref="IHandControllerHardware"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="hardware"/> is null.
        /// </exception>
        public static IConnection<IHandControllerSoftware> Connect(this IHandControllerHardware hardware)
        {
            if (hardware == null)
            {
                throw new ArgumentNullException(nameof(hardware));
            }

            return ConvertHandControllerInto.Connection(hardware);
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
    }
}
