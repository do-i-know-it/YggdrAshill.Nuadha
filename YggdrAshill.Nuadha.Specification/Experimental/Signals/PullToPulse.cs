using YggdrAshill.Nuadha.Transformation.Experimental;
using System;

namespace YggdrAshill.Nuadha.Signals.Experimental
{
    public sealed class PullToPulse :
        IPulsation<Pull>
    {
        private readonly PullToPush conversion;

        private readonly PushToPulse pulsation;

        public PullToPulse(HysteresisThreshold threshold)
        {
            if (threshold == null)
            {
                throw new ArgumentNullException(nameof(threshold));
            }

            conversion = new PullToPush(threshold);

            pulsation = new PushToPulse();
        }

        public Pulse Pulsate(Pull signal)
        {
            var push = conversion.Convert(signal);

            return pulsation.Pulsate(push);
        }
    }
}
