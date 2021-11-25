using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Defines extensions for <see cref="IPulsatedHandControllerHardware"/> and <see cref="IPulsatedHandControllerSoftware"/>.
    /// </summary>
    public static class PulsatedHandControllerExtension
    {
        /// <summary>
        /// Converts <see cref="IPulsatedHandControllerSoftware"/> into <see cref="IConnection{TModule}"/> for <see cref="IPulsatedHandControllerHardware"/>.
        /// </summary>
        /// <param name="software">
        /// <see cref="IPulsatedHandControllerSoftware"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="IConnection{TModule}"/> for <see cref="IPulsatedHandControllerHardware"/> converted from <see cref="IPulsatedHandControllerSoftware"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="software"/> is null.
        /// </exception>
        public static IConnection<IPulsatedHandControllerHardware> Connect(this IPulsatedHandControllerSoftware software)
        {
            if (software == null)
            {
                throw new ArgumentNullException(nameof(software));
            }

            return ConvertPulsatedHandControllerInto.Connection(software);
        }

        /// <summary>
        /// Converts <see cref="IPulsatedHandControllerHardware"/> into <see cref="IConnection{TModule}"/> for <see cref="IPulsatedHandControllerSoftware"/>.
        /// </summary>
        /// <param name="hardware">
        /// <see cref="IPulsatedHandControllerHardware"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="IConnection{TModule}"/> for <see cref="IPulsatedHandControllerSoftware"/> converted from <see cref="IPulsatedHandControllerHardware"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="hardware"/> is null.
        /// </exception>
        public static IConnection<IPulsatedHandControllerSoftware> Connect(this IPulsatedHandControllerHardware hardware)
        {
            if (hardware == null)
            {
                throw new ArgumentNullException(nameof(hardware));
            }

            return ConvertPulsatedHandControllerInto.Connection(hardware);
        }
    }
}
