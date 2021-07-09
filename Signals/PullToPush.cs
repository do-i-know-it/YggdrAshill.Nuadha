using YggdrAshill.Nuadha.Transformation;
using System;

namespace YggdrAshill.Nuadha.Signals
{
    public sealed class PullToPush :
        IConversion<Pull, Push>
    {
        public static PullToPush With(HysteresisThreshold threshold)
        {
            if (threshold == null)
            {
                throw new ArgumentNullException(nameof(threshold));
            }

            return new PullToPush(threshold);
        }

        private readonly HysteresisThreshold threshold;

        private bool previous = false;

        private PullToPush(HysteresisThreshold threshold)
        {
            if (threshold == null)
            {
                throw new ArgumentNullException(nameof(threshold));
            }

            this.threshold = threshold;
        }

        public Push Convert(Pull signal)
        {
            if (previous)
            {
                previous = threshold.Lower <= (float)signal;
            }
            else
            {
                previous = threshold.Upper <= (float)signal;
            }

            return (Push)previous;
        }
    }
}
