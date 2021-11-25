using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Signals;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Defines extensions for <see cref="IStickProtocol"/>, <see cref="IStickHardware"/> and <see cref="IStickSoftware"/>.
    /// </summary>
    public static class StickExtension
    {
        /// <summary>
        /// Converts <see cref="IStickProtocol"/> into <see cref="ITransmission{TModule}"/> for <see cref="IStickSoftware"/>.
        /// </summary>
        /// <param name="protocol">
        /// <see cref="IStickProtocol"/> to convert.
        /// </param>
        /// <param name="configuration">
        /// <see cref="IStickConfiguration"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="ITransmission{TModule}"/> for <see cref="IStickSoftware"/> converted from <see cref="IStickProtocol"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="protocol"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="configuration"/> is null.
        /// </exception>
        public static ITransmission<IStickSoftware> Transmit(this IStickProtocol protocol, IStickConfiguration configuration)
        {
            if (protocol == null)
            {
                throw new ArgumentNullException(nameof(protocol));
            }
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            return ConvertStickInto.Transmission(protocol, configuration);
        }

        /// <summary>
        /// Converts <see cref="IStickSoftware"/> into <see cref="IConnection{TModule}"/> for <see cref="IStickHardware"/>.
        /// </summary>
        /// <param name="software">
        /// <see cref="IStickSoftware"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="IConnection{TModule}"/> for <see cref="IStickHardware"/> converted from <see cref="IStickSoftware"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="software"/> is null.
        /// </exception>
        public static IConnection<IStickHardware> Connect(this IStickSoftware software)
        {
            if (software == null)
            {
                throw new ArgumentNullException(nameof(software));
            }

            return ConvertStickInto.Connection(software);
        }

        /// <summary>
        /// Converts <see cref="IStickHardware"/> into <see cref="IConnection{TModule}"/> for <see cref="IStickSoftware"/>.
        /// </summary>
        /// <param name="hardware">
        /// <see cref="IStickHardware"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="IConnection{TModule}"/> for <see cref="IStickSoftware"/> converted from <see cref="IStickHardware"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="hardware"/> is null.
        /// </exception>
        public static IConnection<IStickSoftware> Connect(this IStickHardware hardware)
        {
            if (hardware == null)
            {
                throw new ArgumentNullException(nameof(hardware));
            }

            return ConvertStickInto.Connection(hardware);
        }

        /// <summary>
        /// Converts <see cref="IStickHardware"/> into <see cref="IPulsatedStickHardware"/>.
        /// </summary>
        /// <param name="hardware">
        /// <see cref="IStickHardware"/> to convert.
        /// </param>
        /// <param name="pulsation">
        /// <see cref="IStickPulsation"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="IPulsatedStickHardware"/> converted from <see cref="IStickHardware"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="hardware"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="pulsation"/> is null.
        /// </exception>
        public static IPulsatedStickHardware Pulsate(this IStickHardware hardware, IStickPulsation pulsation)
        {
            if (hardware == null)
            {
                throw new ArgumentNullException(nameof(hardware));
            }
            if (pulsation == null)
            {
                throw new ArgumentNullException(nameof(pulsation));
            }

            return ConvertStickInto.PulsatedStick(hardware, pulsation);
        }

        /// <summary>
        /// Converts <see cref="IStickHardware"/> into <see cref="IPulsatedStickHardware"/>.
        /// </summary>
        /// <param name="hardware">
        /// <see cref="IStickHardware"/> to convert.
        /// </param>
        /// <param name="threshold">
        /// <see cref="HysteresisThreshold"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="IPulsatedStickHardware"/> converted from <see cref="IStickHardware"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="hardware"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="threshold"/> is null.
        /// </exception>
        public static IPulsatedStickHardware Pulsate(this IStickHardware hardware, TiltThreshold threshold)
        {
            if (hardware == null)
            {
                throw new ArgumentNullException(nameof(hardware));
            }
            if (threshold == null)
            {
                throw new ArgumentNullException(nameof(threshold));
            }

            return hardware.Pulsate(Nuadha.Pulsate.Stick(threshold));
        }

        /// <summary>
        /// Converts <see cref="IStickHardware"/> into <see cref="ITriggerHardware"/>.
        /// </summary>
        /// <param name="hardware">
        /// <see cref="IStickHardware"/> to convert.
        /// </param>
        /// <param name="translation">
        /// <see cref="ITranslation{TInput, TOutput}"/> to convert <see cref="Tilt"/> into <see cref="Pull"/>.
        /// </param>
        /// <returns>
        /// <see cref="ITriggerHardware"/> converted from <see cref="IStickHardware"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="hardware"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="translation"/> is null.
        /// </exception>
        public static ITriggerHardware ToTrigger(IStickHardware hardware, ITranslation<Tilt, Pull> translation)
        {
            if (hardware == null)
            {
                throw new ArgumentNullException(nameof(hardware));
            }
            if (translation == null)
            {
                throw new ArgumentNullException(nameof(translation));
            }

            return ConvertStickInto.Trigger(hardware, translation);
        }
    }
}
