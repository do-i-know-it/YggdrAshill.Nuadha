using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Signals;
using System;

namespace YggdrAshill.Nuadha.Units
{
    public static class ConvertPulsatedTiltInto
    {
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
        /// <see cref="IConsumption{TSignal}"/> for <see cref="Signals.Tilt"/> converted from <see cref="IPulsatedTiltHardware"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="software"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="pulsation"/> is null.
        /// </exception>
        public static IConsumption<Tilt> Tilt(IPulsatedTiltSoftware software, ITiltPulsation pulsation)
        {
            if (software == null)
            {
                throw new ArgumentNullException(nameof(software));
            }
            if (pulsation == null)
            {
                throw new ArgumentNullException(nameof(pulsation));
            }

            return new ConsumeTilt(software, pulsation);
        }
        private sealed class ConsumeTilt :
            IConsumption<Tilt>
        {
            private readonly IConsumption<Tilt> distance;

            private readonly IConsumption<Tilt> left;

            private readonly IConsumption<Tilt> right;

            private readonly IConsumption<Tilt> forward;

            private readonly IConsumption<Tilt> backward;

            internal ConsumeTilt(IPulsatedTiltSoftware software, ITiltPulsation pulsation)
            {
                distance = ConvertTo.Consume(pulsation.Distance, software.Distance);
                left = ConvertTo.Consume(pulsation.Left, software.Left);
                right = ConvertTo.Consume(pulsation.Right, software.Right);
                forward = ConvertTo.Consume(pulsation.Forward, software.Forward);
                backward = ConvertTo.Consume(pulsation.Backward, software.Backward);
            }

            public void Consume(Tilt signal)
            {
                distance.Consume(signal);
                left.Consume(signal);
                right.Consume(signal);
                forward.Consume(signal);
                backward.Consume(signal);
            }
        }
    }
}
