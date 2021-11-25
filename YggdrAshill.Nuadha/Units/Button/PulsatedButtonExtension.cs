using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Defines extensions for <see cref="IPulsatedButtonHardware"/> and <see cref="IPulsatedButtonSoftware"/>.
    /// </summary>
    public static class PulsatedButtonExtension
    {
        /// <summary>
        /// Converts <see cref="IPulsatedButtonSoftware"/> into <see cref="IConnection{TModule}"/> for <see cref="IPulsatedButtonHardware"/>.
        /// </summary>
        /// <param name="software">
        /// <see cref="IPulsatedButtonSoftware"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="IConnection{TModule}"/> for <see cref="IPulsatedButtonHardware"/> converted from <see cref="IPulsatedButtonSoftware"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="software"/> is null.
        /// </exception>
        public static IConnection<IPulsatedButtonHardware> Connect(this IPulsatedButtonSoftware software)
        {
            if (software == null)
            {
                throw new ArgumentNullException(nameof(software));
            }

            return ConvertPulsatedButtonInto.Connection(software);
        }

        /// <summary>
        /// Converts <see cref="IPulsatedButtonHardware"/> into <see cref="IConnection{TModule}"/> for <see cref="IPulsatedButtonSoftware"/>.
        /// </summary>
        /// <param name="hardware">
        /// <see cref="IPulsatedButtonHardware"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="IConnection{TModule}"/> for <see cref="IPulsatedButtonSoftware"/> converted from <see cref="IPulsatedButtonHardware"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="hardware"/> is null.
        /// </exception>
        public static IConnection<IPulsatedButtonSoftware> Connect(this IPulsatedButtonHardware hardware)
        {
            if (hardware == null)
            {
                throw new ArgumentNullException(nameof(hardware));
            }

            return ConvertPulsatedButtonInto.Connection(hardware);
        }

        /// <summary>
        /// Converts <see cref="IPulsatedButtonSoftware"/> into <see cref="IButtonSoftware"/>.
        /// </summary>
        /// <param name="software">
        /// <see cref="IPulsatedButtonSoftware"/> to convert.
        /// </param>
        /// <param name="pulsation">
        /// <see cref="IButtonPulsation"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="IButtonSoftware"/> converted from <see cref="IPulsatedButtonSoftware"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="software"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="pulsation"/> is null.
        /// </exception>
        public static IButtonSoftware ToButton(this IPulsatedButtonSoftware software, IButtonPulsation pulsation)
        {
            if (software == null)
            {
                throw new ArgumentNullException(nameof(software));
            }
            if (pulsation == null)
            {
                throw new ArgumentNullException(nameof(pulsation));
            }

            return ConvertPulsatedButtonInto.Button(software, pulsation);
        }

        /// <summary>
        /// Converts <see cref="IPulsatedButtonSoftware"/> into <see cref="IButtonSoftware"/>.
        /// </summary>
        /// <param name="software">
        /// <see cref="IPulsatedButtonSoftware"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="IButtonSoftware"/> converted from <see cref="IPulsatedButtonSoftware"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="software"/> is null.
        /// </exception>
        public static IButtonSoftware ToButton(this IPulsatedButtonSoftware software)
        {
            if (software == null)
            {
                throw new ArgumentNullException(nameof(software));
            }

            return software.ToButton(Pulsate.Button);
        }
    }
}
