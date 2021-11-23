using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Signals;
using System;

namespace YggdrAshill.Nuadha.Units
{
    public static class ConvertButtonInto
    {
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
        public static IPulsatedButtonHardware PulsatedButton(IButtonHardware hardware, IButtonPulsation pulsation)
        {
            if (hardware == null)
            {
                throw new ArgumentNullException(nameof(hardware));
            }
            if (pulsation == null)
            {
                throw new ArgumentNullException(nameof(pulsation));
            }

            return new PulsatedButtonHardware(hardware, pulsation);
        }
        private sealed class PulsatedButtonHardware :
            IPulsatedButtonHardware
        {
            internal PulsatedButtonHardware(IButtonHardware hardware, IButtonPulsation pulsation)
            {
                Touch = ProduceSignalTo.Convert(hardware.Touch, pulsation.Touch);

                Push = ProduceSignalTo.Convert(hardware.Push, pulsation.Push);
            }

            public IProduction<Pulse> Touch { get; }

            public IProduction<Pulse> Push { get; }
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
        public static ITriggerSoftware Trigger(IButtonSoftware software, ITranslation<Pull, Push> translation)
        {
            if (software == null)
            {
                throw new ArgumentNullException(nameof(software));
            }
            if (translation == null)
            {
                throw new ArgumentNullException(nameof(translation));
            }

            return new TriggerSoftware(software, translation);
        }
        private sealed class TriggerSoftware :
            ITriggerSoftware
        {
            internal TriggerSoftware(IButtonSoftware software, ITranslation<Pull, Push> translation)
            {
                Touch = software.Touch;

                Pull = ConsumeSignalTo.Convert(translation, software.Push);
            }

            public IConsumption<Touch> Touch { get; }

            public IConsumption<Pull> Pull { get; }
        }
    }
}
