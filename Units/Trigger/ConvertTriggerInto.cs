using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Signals;
using System;

namespace YggdrAshill.Nuadha.Units
{
    public static class ConvertTriggerInto
    {
        /// <summary>
        /// Converts <see cref="ITriggerHardware"/> into <see cref="IPulsatedTriggerHardware"/>.
        /// </summary>
        /// <param name="hardware">
        /// <see cref="ITriggerHardware"/> to convert.
        /// </param>
        /// <param name="pulsation">
        /// <see cref="ITriggerPulsation"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="IPulsatedTriggerHardware"/> converted from <see cref="ITriggerHardware"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="hardware"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="pulsation"/> is null.
        /// </exception>
        public static IPulsatedTriggerHardware PulsatedTrigger(ITriggerHardware hardware, ITriggerPulsation pulsation)
        {
            if (hardware == null)
            {
                throw new ArgumentNullException(nameof(hardware));
            }
            if (pulsation == null)
            {
                throw new ArgumentNullException(nameof(pulsation));
            }

            return new PulsatedTriggerHardware(hardware, pulsation);
        }
        private sealed class PulsatedTriggerHardware :
            IPulsatedTriggerHardware
        {
            internal PulsatedTriggerHardware(ITriggerHardware hardware, ITriggerPulsation pulsation)
            {
                Touch = ProduceSignalTo.Convert(hardware.Touch, pulsation.Touch);

                Pull = ProduceSignalTo.Convert(hardware.Pull, pulsation.Pull);
            }

            public IProduction<Pulse> Touch { get; }

            public IProduction<Pulse> Pull { get; }
        }

        /// <summary>
        /// Converts <see cref="ITriggerHardware"/> into <see cref="IButtonHardware"/>.
        /// </summary>
        /// <param name="hardware">
        /// <see cref="ITriggerHardware"/> to convert.
        /// </param>
        /// <param name="translation">
        /// <see cref="ITranslation{TInput, TOutput}"/> to convert <see cref="Pull"/> into <see cref="Push"/>.
        /// </param>
        /// <returns>
        /// <see cref="IButtonHardware"/> converted from <see cref="ITriggerHardware"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="hardware"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="translation"/> is null.
        /// </exception>
        public static IButtonHardware Button(ITriggerHardware hardware, ITranslation<Pull, Push> translation)
        {
            if (hardware == null)
            {
                throw new ArgumentNullException(nameof(hardware));
            }
            if (translation == null)
            {
                throw new ArgumentNullException(nameof(translation));
            }

            return new ButtonHardware(hardware, translation);
        }
        private sealed class ButtonHardware :
            IButtonHardware
        {
            internal ButtonHardware(ITriggerHardware hardware, ITranslation<Pull, Push> translation)
            {
                Touch = hardware.Touch;

                Push = ProduceSignalTo.Convert(hardware.Pull, translation);
            }

            public IProduction<Touch> Touch { get; }

            public IProduction<Push> Push { get; }
        }

        /// <summary>
        /// Converts <see cref="ITriggerSoftware"/> into <see cref="IStickSoftware"/>.
        /// </summary>
        /// <param name="software">
        /// <see cref="ITriggerSoftware"/> to convert.
        /// </param>
        /// <param name="translation">
        /// <see cref="ITranslation{TInput, TOutput}"/> to convert <see cref="Tilt"/> into <see cref="Pull"/>.
        /// </param>
        /// <returns>
        /// <see cref="IStickSoftware"/> converted from <see cref="ITriggerSoftware"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="software"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="translation"/> is null.
        /// </exception>
        public static IStickSoftware Stick(ITriggerSoftware software, ITranslation<Tilt, Pull> translation)
        {
            if (software == null)
            {
                throw new ArgumentNullException(nameof(software));
            }
            if (translation == null)
            {
                throw new ArgumentNullException(nameof(translation));
            }

            return new StickSoftware(software, translation);
        }
        private sealed class StickSoftware :
            IStickSoftware
        {
            internal StickSoftware(ITriggerSoftware software, ITranslation<Tilt, Pull> translation)
            {
                Touch = software.Touch;

                Tilt = ConsumeSignalTo.Convert(translation, software.Pull);
            }

            public IConsumption<Touch> Touch { get; }

            public IConsumption<Tilt> Tilt { get; }
        }
    }
}
