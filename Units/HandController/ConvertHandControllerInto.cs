using System;

namespace YggdrAshill.Nuadha.Units
{
    public static class ConvertHandControllerInto
    {
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
        public static IPulsatedHandControllerHardware PulsatedHandController(IHandControllerHardware hardware, IHandControllerPulsation pulsation)
        {
            if (hardware == null)
            {
                throw new ArgumentNullException(nameof(hardware));
            }
            if (pulsation == null)
            {
                throw new ArgumentNullException(nameof(pulsation));
            }

            return new PulsatedHandControllerHardware(hardware, pulsation);
        }
        private sealed class PulsatedHandControllerHardware :
            IPulsatedHandControllerHardware
        {
            internal PulsatedHandControllerHardware(IHandControllerHardware module, IHandControllerPulsation pulsation)
            {
                Thumb = ConvertStickInto.PulsatedStick(module.Thumb, pulsation.Thumb);

                IndexFinger = ConvertTriggerInto.PulsatedTrigger(module.IndexFinger, pulsation.IndexFinger);

                HandGrip = ConvertTriggerInto.PulsatedTrigger(module.HandGrip, pulsation.HandGrip);
            }

            public IPulsatedStickHardware Thumb { get; }

            public IPulsatedTriggerHardware IndexFinger { get; }

            public IPulsatedTriggerHardware HandGrip { get; }
        }
    }
}
