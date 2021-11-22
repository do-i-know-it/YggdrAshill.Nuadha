using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Signals;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Defines extensions for <see cref="IStickHardware"/> and <see cref="IStickSoftware"/>.
    /// </summary>
    public static class StickExtension
    {
        public static IEmission Conduct(this IStickSoftware software, IStickConfiguration configuration)
        {
            if (software == null)
            {
                throw new ArgumentNullException(nameof(software));
            }
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            return Nuadha.Conduct.Stick(configuration, software);
        }

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

            return Nuadha.Transmit.Stick(configuration, protocol);
        }

        public static IConnection<IStickHardware> Connect(this IStickSoftware software)
        {
            if (software == null)
            {
                throw new ArgumentNullException(nameof(software));
            }

            return Nuadha.Connect.Stick(software);
        }

        public static IConnection<IStickSoftware> Connect(this IStickHardware hardware)
        {
            if (hardware == null)
            {
                throw new ArgumentNullException(nameof(hardware));
            }

            return Nuadha.Connect.Stick(hardware);
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
