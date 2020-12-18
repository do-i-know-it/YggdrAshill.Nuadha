using YggdrAshill.Nuadha.Translation;
using System;

namespace YggdrAshill.Nuadha.Signals
{
    public sealed class PullToPush :
        IConversion<Pull, Push>
    {
        private readonly IHysteresisThreshold threshold;

        private bool isPushed;

        public PullToPush(IHysteresisThreshold threshold, bool isPushed = false)
        {
            if (threshold == null)
            {
                throw new ArgumentNullException(nameof(threshold));
            }

            this.threshold = threshold;

            this.isPushed = isPushed;
        }

        public Push Convert(Pull signal)
        {
            if (isPushed)
            {
                isPushed = threshold.LowerLimit <= signal.Strength;
            }
            else
            {
                isPushed = threshold.UpperLimit <= signal.Strength;
            }

            return isPushed ? Push.Enabled : Push.Disabled;
        }
    }
}
