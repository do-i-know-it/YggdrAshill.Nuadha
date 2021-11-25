using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Signals;
using System;

namespace YggdrAshill.Nuadha.Units
{
    public static class ConvertTiltInto
    {
        /// <summary>
        /// Converts <see cref="IProduction{TSignal}"/> for <see cref="Tilt"/> into <see cref="IPulsatedTiltHardware"/>.
        /// </summary>
        /// <param name="production">
        /// <see cref="IProduction{TSignal}"/> for <see cref="Tilt"/>.
        /// </param>
        /// <param name="pulsation">
        /// <see cref="ITiltPulsation"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="IPulsatedTiltHardware"/> converted from <see cref="IProduction{TSignal}"/> for <see cref="Tilt"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="production"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="pulsation"/> is null.
        /// </exception>
        public static IPulsatedTiltHardware PulsatedTilt(IProduction<Tilt> production, ITiltPulsation pulsation)
        {
            if (production == null)
            {
                throw new ArgumentNullException(nameof(production));
            }
            if (pulsation == null)
            {
                throw new ArgumentNullException(nameof(pulsation));
            }

            return new PulsatedTiltHardware(production, pulsation);
        }
        private sealed class PulsatedTiltHardware :
            IPulsatedTiltHardware
        {
            internal PulsatedTiltHardware(IProduction<Tilt> production, ITiltPulsation pulsation)
            {
                Distance = ProduceSignalTo.Convert(production, pulsation.Distance);
                Left = ProduceSignalTo.Convert(production, pulsation.Left);
                Right = ProduceSignalTo.Convert(production, pulsation.Right);
                Forward = ProduceSignalTo.Convert(production, pulsation.Forward);
                Backward = ProduceSignalTo.Convert(production, pulsation.Backward);
            }

            public IProduction<Pulse> Distance { get; }

            public IProduction<Pulse> Left { get; }

            public IProduction<Pulse> Right { get; }

            public IProduction<Pulse> Forward { get; }

            public IProduction<Pulse> Backward { get; }
        }
    }
}
