using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Signals;
using System;

namespace YggdrAshill.Nuadha.Units
{
    public static class ConvertPulsatedButtonInto
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
        public static IButtonSoftware Button(IPulsatedButtonSoftware software, IButtonPulsation pulsation)
        {
            if (software == null)
            {
                throw new ArgumentNullException(nameof(software));
            }
            if (pulsation == null)
            {
                throw new ArgumentNullException(nameof(pulsation));
            }

            return new ButtonSoftware(software, pulsation);
        }
        private sealed class ButtonSoftware :
            IButtonSoftware
        {
            internal ButtonSoftware(IPulsatedButtonSoftware software, IButtonPulsation pulsation)
            {
                Touch = ConvertTo.Consume(pulsation.Touch, software.Touch);

                Push = ConvertTo.Consume(pulsation.Push, software.Push);
            }

            public IConsumption<Touch> Touch { get; }

            public IConsumption<Push> Push { get; }
        }
    }
}
