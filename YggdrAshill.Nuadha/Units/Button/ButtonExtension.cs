using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Signals;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Defines extensions for <see cref="IButtonProtocol"/>, <see cref="IButtonHardware"/> and <see cref="IButtonSoftware"/>.
    /// </summary>
    public static class ButtonExtension
    {
        /// <summary>
        /// Converts <see cref="IButtonProtocol"/> into <see cref="ITransmission{TModule}"/> for <see cref="IButtonSoftware"/>.
        /// </summary>
        /// <param name="protocol">
        /// <see cref="IButtonProtocol"/> to convert.
        /// </param>
        /// <param name="configuration">
        /// <see cref="IButtonConfiguration"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="ITransmission{TModule}"/> for <see cref="IButtonSoftware"/> converted from <see cref="IButtonProtocol"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="protocol"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="configuration"/> is null.
        /// </exception>
        public static ITransmission<IButtonSoftware> Transmit(this IButtonProtocol protocol, IButtonConfiguration configuration)
        {
            if (protocol == null)
            {
                throw new ArgumentNullException(nameof(protocol));
            }
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            return ConvertButtonInto.Transmission(protocol, configuration);
        }

        /// <summary>
        /// Converts <see cref="IButtonSoftware"/> into <see cref="IConnection{TModule}"/> for <see cref="IButtonHardware"/>.
        /// </summary>
        /// <param name="software">
        /// <see cref="IButtonSoftware"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="IConnection{TModule}"/> for <see cref="IButtonHardware"/> converted from <see cref="IButtonSoftware"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="software"/> is null.
        /// </exception>
        public static IConnection<IButtonHardware> Connect(this IButtonSoftware software)
        {
            if (software == null)
            {
                throw new ArgumentNullException(nameof(software));
            }

            return ConvertButtonInto.Connection(software);
        }

        /// <summary>
        /// Converts <see cref="IButtonHardware"/> into <see cref="IConnection{TModule}"/> for <see cref="IButtonSoftware"/>.
        /// </summary>
        /// <param name="hardware">
        /// <see cref="IButtonSoftware"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="IConnection{TModule}"/> for <see cref="IButtonSoftware"/> converted from <see cref="IButtonHardware"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="hardware"/> is null.
        /// </exception>
        public static IConnection<IButtonSoftware> Connect(this IButtonHardware hardware)
        {
            if (hardware == null)
            {
                throw new ArgumentNullException(nameof(hardware));
            }

            return ConvertButtonInto.Connection(hardware);
        }

        /// <summary>
        /// Converts <see cref="IButtonHardware"/> into <see cref="IPulsatedButtonHardware"/>.
        /// </summary>
        /// <param name="hardware">
        /// <see cref="IButtonHardware"/> to convert.
        /// </param>
        /// <param name="pulsation">
        /// <see cref="IButtonPulsation"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="IPulsatedButtonHardware"/> converted from <see cref="IButtonHardware"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="hardware"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="pulsation"/> is null.
        /// </exception>
        public static IPulsatedButtonHardware Pulsate(this IButtonHardware hardware, IButtonPulsation pulsation)
        {
            if (hardware == null)
            {
                throw new ArgumentNullException(nameof(hardware));
            }
            if (pulsation == null)
            {
                throw new ArgumentNullException(nameof(pulsation));
            }

            return ConvertButtonInto.PulsatedButton(hardware, pulsation);
        }

        /// <summary>
        /// Converts <see cref="IButtonHardware"/> into <see cref="IPulsatedButtonHardware"/>.
        /// </summary>
        /// <param name="hardware">
        /// <see cref="IButtonHardware"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="IPulsatedButtonHardware"/> converted from <see cref="IButtonHardware"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="hardware"/> is null.
        /// </exception>
        public static IPulsatedButtonHardware Pulsate(this IButtonHardware hardware)
        {
            if (hardware == null)
            {
                throw new ArgumentNullException(nameof(hardware));
            }

            return hardware.Pulsate(Nuadha.Pulsate.Button);
        }
        
        /// <summary>
        /// Converts <see cref="IButtonSoftware"/> into <see cref="ITriggerSoftware"/>.
        /// </summary>
        /// <param name="software">
        /// <see cref="IButtonSoftware"/> to convert.
        /// </param>
        /// <param name="translation">
        /// <see cref="ITranslation{TInput, TOutput}"/> to convert <see cref="Pull"/> into <see cref="Push"/>.
        /// </param>
        /// <returns>
        /// <see cref="ITriggerSoftware"/> converted from <see cref="IButtonSoftware"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="software"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="translation"/> is null.
        /// </exception>
        public static ITriggerSoftware ToTrigger(this IButtonSoftware software, ITranslation<Pull, Push> translation)
        {
            if (software == null)
            {
                throw new ArgumentNullException(nameof(software));
            }
            if (translation == null)
            {
                throw new ArgumentNullException(nameof(translation));
            }

            return ConvertButtonInto.Trigger(software, translation);
        }
    }
}
