using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Defines extensions for <see cref="IPulsatedTriggerHardware"/> and <see cref="IPulsatedTriggerSoftware"/>.
    /// </summary>
    public static class PulsatedTriggerExtension
    {
        /// <summary>
        /// Converts <see cref="IPulsatedTriggerSoftware"/> into <see cref="IConnection{TModule}"/> for <see cref="IPulsatedTriggerHardware"/>.
        /// </summary>
        /// <param name="software">
        /// <see cref="IPulsatedTriggerSoftware"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="IConnection{TModule}"/> for <see cref="IPulsatedTriggerHardware"/> converted from <see cref="IPulsatedTriggerSoftware"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="software"/> is null.
        /// </exception>
        public static IConnection<IPulsatedTriggerHardware> Connect(this IPulsatedTriggerSoftware software)
        {
            if (software == null)
            {
                throw new ArgumentNullException(nameof(software));
            }

            return ConvertPulsatedTriggerInto.Connection(software);
        }

        /// <summary>
        /// Converts <see cref="IPulsatedTriggerHardware"/> into <see cref="IConnection{TModule}"/> for <see cref="IPulsatedTriggerSoftware"/>.
        /// </summary>
        /// <param name="hardware">
        /// <see cref="IPulsatedTriggerHardware"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="IConnection{TModule}"/> for <see cref="IPulsatedTriggerSoftware"/> converted from <see cref="IPulsatedTriggerHardware"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="hardware"/> is null.
        /// </exception>
        public static IConnection<IPulsatedTriggerSoftware> Connect(this IPulsatedTriggerHardware hardware)
        {
            if (hardware == null)
            {
                throw new ArgumentNullException(nameof(hardware));
            }

            return ConvertPulsatedTriggerInto.Connection(hardware);
        }

        /// <summary>
        /// Converts <see cref="IPulsatedTriggerSoftware"/> into <see cref="ITriggerSoftware"/>.
        /// </summary>
        /// <param name="software">
        /// <see cref="IPulsatedTriggerSoftware"/> to convert.
        /// </param>
        /// <param name="pulsation">
        /// <see cref="ITriggerPulsation"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="ITriggerSoftware"/> converted from <see cref="IPulsatedTriggerSoftware"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="software"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="pulsation"/> is null.
        /// </exception>
        public static ITriggerSoftware ToTrigger(this IPulsatedTriggerSoftware software, ITriggerPulsation pulsation)
        {
            if (software == null)
            {
                throw new ArgumentNullException(nameof(software));
            }
            if (pulsation == null)
            {
                throw new ArgumentNullException(nameof(pulsation));
            }

            return ConvertPulsatedTriggerInto.Trigger(software, pulsation);
        }

        /// <summary>
        /// Converts <see cref="IPulsatedTriggerSoftware"/> into <see cref="ITriggerSoftware"/>.
        /// </summary>
        /// <param name="software">
        /// <see cref="IPulsatedTriggerSoftware"/> to convert.
        /// </param>
        /// <param name="threshold">
        /// <see cref="HysteresisThreshold"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="ITriggerSoftware"/> converted from <see cref="IPulsatedTriggerSoftware"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="software"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="threshold"/> is null.
        /// </exception>
        public static ITriggerSoftware ToTrigger(this IPulsatedTriggerSoftware software, HysteresisThreshold threshold)
        {
            if (software == null)
            {
                throw new ArgumentNullException(nameof(software));
            }
            if (threshold == null)
            {
                throw new ArgumentNullException(nameof(threshold));
            }

            return software.ToTrigger(Pulsate.Trigger(threshold));
        }
    }
}
