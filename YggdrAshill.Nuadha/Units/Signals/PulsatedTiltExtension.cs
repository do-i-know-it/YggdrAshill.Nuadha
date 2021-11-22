using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Signals;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Defines extensions for <see cref="IPulsatedStickHardware"/> and <see cref="IPulsatedStickSoftware"/>.
    /// </summary>
    public static class PulsatedTiltExtension
    {
        /// <summary>
        /// Converts <see cref="IProduction{TSignal}"/> for <see cref="Tilt"/> into <see cref="IPulsatedTiltHardware"/>.
        /// </summary>
        /// <param name="production">
        /// <see cref="IProduction{TSignal}"/> for <see cref="Tilt"/>.
        /// </param>
        /// <param name="pulsation">
        /// <see cref="ITiltPulsation"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="IPulsatedTiltHardware"/> converted from <see cref="IProduction{TSignal}"/> for <see cref="Tilt"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="production"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="pulsation"/> is null.
        /// </exception>
        public static IPulsatedTiltHardware Pulsate(this IProduction<Tilt> production, ITiltPulsation pulsation)
        {
            if (production == null)
            {
                throw new ArgumentNullException(nameof(production));
            }
            if (pulsation == null)
            {
                throw new ArgumentNullException(nameof(pulsation));
            }

            return ConvertTiltInto.PulsatedTilt(production, pulsation);
        }

        /// <summary>
        /// Converts <see cref="IProduction{TSignal}"/> for <see cref="Tilt"/> into <see cref="IPulsatedTiltHardware"/>.
        /// </summary>
        /// <param name="production">
        /// <see cref="IProduction{TSignal}"/> for <see cref="Tilt"/>.
        /// </param>
        /// <param name="threshold">
        /// <see cref="TiltThreshold"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="IPulsatedTiltHardware"/> converted from <see cref="IProduction{TSignal}"/> for <see cref="Tilt"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="production"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="threshold"/> is null.
        /// </exception>
        public static IPulsatedTiltHardware Pulsate(this IProduction<Tilt> production, TiltThreshold threshold)
        {
            if (production == null)
            {
                throw new ArgumentNullException(nameof(production));
            }
            if (threshold == null)
            {
                throw new ArgumentNullException(nameof(threshold));
            }

            return production.Pulsate(Nuadha.Pulsate.Tilt(threshold));
        }

        /// <summary>
        /// Converts <see cref="IPulsatedTiltHardware"/> into <see cref="IProduction{TSignal}"/> for <see cref="Tilt"/>.
        /// </summary>
        /// <param name="software">
        /// <see cref="IPulsatedTiltSoftware"/> to convert.
        /// </param>
        /// <param name="pulsation">
        /// <see cref="ITiltPulsation"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="IConsumption{TSignal}"/> for <see cref="Tilt"/> converted from <see cref="IPulsatedTiltHardware"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="software"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="pulsation"/> is null.
        /// </exception>
        public static IConsumption<Tilt> ToTilt(this IPulsatedTiltSoftware software, ITiltPulsation pulsation)
        {
            if (software == null)
            {
                throw new ArgumentNullException(nameof(software));
            }
            if (pulsation == null)
            {
                throw new ArgumentNullException(nameof(pulsation));
            }

            return ConvertPulsatedTiltInto.Tilt(software, pulsation);
        }

        /// <summary>
        /// Converts <see cref="IPulsatedTiltHardware"/> into <see cref="IProduction{TSignal}"/> for <see cref="Tilt"/>.
        /// </summary>
        /// <param name="software">
        /// <see cref="IPulsatedTiltSoftware"/> to convert.
        /// </param>
        /// <param name="threshold">
        /// <see cref="TiltThreshold"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="IConsumption{TSignal}"/> for <see cref="Tilt"/> converted from <see cref="IPulsatedTiltHardware"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="software"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="threshold"/> is null.
        /// </exception>
        public static IConsumption<Tilt> ToTilt(this IPulsatedTiltSoftware software, TiltThreshold threshold)
        {
            if (software == null)
            {
                throw new ArgumentNullException(nameof(software));
            }
            if (threshold == null)
            {
                throw new ArgumentNullException(nameof(threshold));
            }

            return software.ToTilt(Nuadha.Pulsate.Tilt(threshold));
        }
    }
}
