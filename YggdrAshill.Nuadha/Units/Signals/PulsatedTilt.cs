using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class PulsatedTilt :
        IConnection<IPulsatedTiltHardwareHandler>
    {
        private readonly IProduction<Pulse> distance;

        private readonly IProduction<Pulse> left;

        private readonly IProduction<Pulse> right;

        private readonly IProduction<Pulse> forward;

        private readonly IProduction<Pulse> backward;

        public PulsatedTilt(IProduction<Tilt> production, ITiltThreshold threshold)
        {
            if (production == null)
            {
                throw new ArgumentNullException(nameof(production));
            }
            if (threshold == null)
            {
                throw new ArgumentNullException(nameof(threshold));
            }

            distance = production.Convert(TiltToPulse.Distance(threshold.Distance));

            left = production.Convert(TiltToPulse.Left(threshold.Left));
            right = production.Convert(TiltToPulse.Right(threshold.Right));
            forward = production.Convert(TiltToPulse.Forward(threshold.Forward));
            backward = production.Convert(TiltToPulse.Backward(threshold.Backward));
        }

        public ICancellation Connect(IPulsatedTiltHardwareHandler handler)
        {
            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }

            var synthesized = new SynthesizedCancellation();

            distance.Produce(handler.Distance).Synthesize(synthesized);
            left.Produce(handler.Left).Synthesize(synthesized);
            right.Produce(handler.Right).Synthesize(synthesized);
            forward.Produce(handler.Forward).Synthesize(synthesized);
            backward.Produce(handler.Backward).Synthesize(synthesized);

            return synthesized;
        }
    }
}
