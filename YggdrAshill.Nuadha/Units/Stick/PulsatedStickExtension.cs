using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Defines extensions for <see cref="IPulsatedStickHardware"/> and <see cref="IPulsatedStickSoftware"/>.
    /// </summary>
    public static class PulsatedStickExtension
    {
        /// <summary>
        /// Converts <see cref="IStickHardware"/> into <see cref="IStickSoftware"/>.
        /// </summary>
        /// <param name="software">
        /// <see cref="IPulsatedStickSoftware"/> to convert.
        /// </param>
        /// <param name="pulsation">
        /// <see cref="IStickPulsation"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="IStickSoftware"/> converted from <see cref="IPulsatedStickSoftware"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="software"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="pulsation"/> is null.
        /// </exception>
        public static IStickSoftware ToStick(this IPulsatedStickSoftware software, IStickPulsation pulsation)
        {
            if (software == null)
            {
                throw new ArgumentNullException(nameof(software));
            }
            if (pulsation == null)
            {
                throw new ArgumentNullException(nameof(pulsation));
            }

            return ConvertPulsatedStickInto.Stick(software, pulsation);
        }

        /// <summary>
        /// Converts <see cref="IStickHardware"/> into <see cref="IStickSoftware"/>.
        /// </summary>
        /// <param name="software">
        /// <see cref="IPulsatedStickSoftware"/> to convert.
        /// </param>
        /// <param name="threshold">
        /// <see cref="TiltThreshold"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="IStickSoftware"/> converted from <see cref="IPulsatedStickSoftware"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="software"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="threshold"/> is null.
        /// </exception>
        public static IStickSoftware ToStick(this IPulsatedStickSoftware software, TiltThreshold threshold)
        {
            if (software == null)
            {
                throw new ArgumentNullException(nameof(software));
            }
            if (threshold == null)
            {
                throw new ArgumentNullException(nameof(threshold));
            }

            return software.ToStick(Pulsate.Stick(threshold));
        }
    }
}
