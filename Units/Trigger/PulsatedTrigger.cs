using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;
using System;

namespace YggdrAshill.Nuadha.Units
{
    public sealed class PulsatedTrigger :
        IConnection<IPulsatedTriggerHardwareHandler>
    {
        private readonly IProduction<Pulse> touch;

        private readonly IProduction<Pulse> pull;

        public PulsatedTrigger(ITriggerSoftwareHandler handler, HysteresisThreshold threshold)
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

            pull = handler.Pull.Convert(new PullToPulse(threshold));
        }

        public ICancellation Connect(IPulsatedTriggerHardwareHandler handler)
        {
            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }

            return touch.Produce(handler.Touch)
                .Synthesize(pull.Produce(handler.Pull));
        }
    }
}
