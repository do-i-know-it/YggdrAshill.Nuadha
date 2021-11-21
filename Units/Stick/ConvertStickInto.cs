using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Signals;
using System;

namespace YggdrAshill.Nuadha.Units
{
    public static class ConvertStickInto
    {
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
        public static IPulsatedStickHardware PulsatedStick(IStickHardware hardware, IStickPulsation pulsation)
        {
            if (hardware == null)
            {
                throw new ArgumentNullException(nameof(hardware));
            }
            if (pulsation == null)
            {
                throw new ArgumentNullException(nameof(pulsation));
            }

            return new PulsatedStickHardware(hardware, pulsation);
        }
        private sealed class PulsatedStickHardware :
            IPulsatedStickHardware
        {
            internal PulsatedStickHardware(IStickHardware hardware, IStickPulsation pulsation)
            {
                Touch = ConvertTo.Produce(hardware.Touch, pulsation.Touch);

                Tilt = ConvertTiltInto.PulsatedTilt(hardware.Tilt, pulsation.Tilt);
            }

            public IProduction<Pulse> Touch { get; }

            public IPulsatedTiltHardware Tilt { get; }
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
        public static ITriggerHardware Trigger(IStickHardware hardware, ITranslation<Tilt, Pull> translation)
        {
            if (hardware == null)
            {
                throw new ArgumentNullException(nameof(hardware));
            }
            if (translation == null)
            {
                throw new ArgumentNullException(nameof(translation));
            }

            return new TriggerHardware(hardware, translation);
        }
        private sealed class TriggerHardware :
            ITriggerHardware
        {
            internal TriggerHardware(IStickHardware hardware, ITranslation<Tilt, Pull> translation)
            {
                Touch = hardware.Touch;

                Pull = ConvertTo.Produce(hardware.Tilt, translation);
            }

            public IProduction<Touch> Touch { get; }

            public IProduction<Pull> Pull { get; }
        }

    }
}
