using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class PulsatedStick :
        IConnection<IPulsatedStickHardwareHandler>
    {
        private readonly IProduction<Pulse> touch;

        private readonly IProduction<Pulse> distance;

        private readonly IProduction<Pulse> left;

        private readonly IProduction<Pulse> right;

        private readonly IProduction<Pulse> forward;

        private readonly IProduction<Pulse> backward;

        public PulsatedStick(IStickSoftwareHandler handler, ITiltThreshold threshold)
        {
            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }
            if (threshold == null)
            {
                throw new ArgumentNullException(nameof(threshold));
            }

            touch = handler.Touch.Convert(new TouchToPulse());

            distance = handler.Tilt.Convert(TiltToPulse.Distance(threshold.Distance));

            left = handler.Tilt.Convert(TiltToPulse.Left(threshold.Left));
            right = handler.Tilt.Convert(TiltToPulse.Right(threshold.Right));
            forward = handler.Tilt.Convert(TiltToPulse.Forward(threshold.Forward));
            backward = handler.Tilt.Convert(TiltToPulse.Backward(threshold.Backward));
        }

        public ICancellation Connect(IPulsatedStickHardwareHandler handler)
        {
            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }

            var synthesized = new SynthesizedCancellation();

            touch.Produce(handler.Touch).Synthesize(synthesized);
            distance.Produce(handler.Distance).Synthesize(synthesized);
            left.Produce(handler.Left).Synthesize(synthesized);
            right.Produce(handler.Right).Synthesize(synthesized);
            forward.Produce(handler.Forward).Synthesize(synthesized);
            backward.Produce(handler.Backward).Synthesize(synthesized);

            return synthesized;
        }
    }
}
