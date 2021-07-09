using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;
using System;

namespace YggdrAshill.Nuadha.Units
{
    public sealed class PulsatedStick :
        IConnection<IStickPulsationSoftware>
    {
        private readonly IProduction<Pulse> touch;

        private readonly IProduction<Pulse> distance;

        private readonly IProduction<Pulse> left;

        private readonly IProduction<Pulse> right;

        private readonly IProduction<Pulse> forward;

        private readonly IProduction<Pulse> backward;

        public PulsatedStick(IStickHardware handler, ITiltThreshold threshold)
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

        public ICancellation Connect(IStickPulsationSoftware handler)
        {
            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }

            return touch.Produce(handler.Touch)
                .Synthesize(distance.Produce(handler.Distance))
                .Synthesize(left.Produce(handler.Left))
                .Synthesize(right.Produce(handler.Right))
                .Synthesize(forward.Produce(handler.Forward))
                .Synthesize(backward.Produce(handler.Backward));
        }
    }
}
