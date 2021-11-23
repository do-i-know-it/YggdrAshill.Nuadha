using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Signals;
using System;

namespace YggdrAshill.Nuadha.Units
{
    public static class ConvertPulsatedTriggerInto
    {
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
        public static ITriggerSoftware Trigger(IPulsatedTriggerSoftware software, ITriggerPulsation pulsation)
        {
            if (software == null)
            {
                throw new ArgumentNullException(nameof(software));
            }
            if (pulsation == null)
            {
                throw new ArgumentNullException(nameof(pulsation));
            }

            return new TriggerSoftware(software, pulsation);
        }
        private sealed class TriggerSoftware :
            ITriggerSoftware
        {
            internal TriggerSoftware(IPulsatedTriggerSoftware software, ITriggerPulsation pulsation)
            {
                Touch = ConsumeSignalTo.Convert(pulsation.Touch, software.Touch);

                Pull = ConsumeSignalTo.Convert(pulsation.Pull, software.Pull);
            }

            public IConsumption<Touch> Touch { get; }

            public IConsumption<Pull> Pull { get; }
        }
    }
}
