using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    internal sealed class PulsatedTilt :
        IConnection<IPulsatedTiltHardwareHandler>
    {
        private readonly IProduction<Pulse> distance;

        private readonly IProduction<Pulse> left;

        private readonly IProduction<Pulse> right;

        private readonly IProduction<Pulse> forward;

        private readonly IProduction<Pulse> backward;

        internal PulsatedTilt(IProduction<Tilt> production, TiltThreshold threshold)
        {
            if (production == null)
            {
                throw new ArgumentNullException(nameof(production));
            }
            if (threshold == null)
            {
                throw new ArgumentNullException(nameof(threshold));
            }

            distance = production.Convert(TiltInto.PulseBy.Distance(threshold.Distance));
            left = production.Convert(TiltInto.PulseBy.Left(threshold.Left));
            right = production.Convert(TiltInto.PulseBy.Right(threshold.Right));
            forward = production.Convert(TiltInto.PulseBy.Forward(threshold.Forward));
            backward = production.Convert(TiltInto.PulseBy.Backward(threshold.Backward));
        }

        /// <inheritdoc/>
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
