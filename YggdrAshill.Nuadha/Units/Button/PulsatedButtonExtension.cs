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
