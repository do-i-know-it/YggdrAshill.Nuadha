using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Signals;
using System;

namespace YggdrAshill.Nuadha.Units
{
    public static class ConvertPulsatedStickInto
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
        public static IStickSoftware Stick(IPulsatedStickSoftware software, IStickPulsation pulsation)
        {
            if (software == null)
            {
                throw new ArgumentNullException(nameof(software));
            }
            if (pulsation == null)
            {
                throw new ArgumentNullException(nameof(pulsation));
            }

            return new StickSoftware(software, pulsation);
        }
        private sealed class StickSoftware :
            IStickSoftware
        {
            internal StickSoftware(IPulsatedStickSoftware software, IStickPulsation pulsation)
            {
                Touch = ConsumeSignalTo.Convert(pulsation.Touch, software.Touch);

                Tilt = ConvertPulsatedTiltInto.Tilt(software.Tilt, pulsation.Tilt);
            }

            public IConsumption<Touch> Touch { get; }

            public IConsumption<Tilt> Tilt { get; }
        }
    }
}
