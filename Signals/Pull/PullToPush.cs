using YggdrAshill.Nuadha.Conversion;
using System;

namespace YggdrAshill.Nuadha.Signals
{
    public sealed class PullToPush :
        ITranslation<Pull, Push>
    {
        private readonly HysteresisThreshold threshold;

        private bool isPushed;

        public PullToPush(HysteresisThreshold threshold, bool isPushed = false)
        {
            if (threshold == null)
            {
                throw new ArgumentNullException(nameof(threshold));
            }

            this.threshold = threshold;

            this.isPushed = isPushed;
        }

        public Push Translate(Pull signal)
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
