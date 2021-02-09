using YggdrAshill.Nuadha.Translation;
using System;

namespace YggdrAshill.Nuadha.Signals
{
    public sealed class BlinkToPush :
        IConversion<Blink, Push>
    {
        private readonly HysteresisThreshold threshold;

        private bool isPushed;

        public BlinkToPush(HysteresisThreshold threshold, bool isPushed = false)
        {
            if (threshold == null)
            {
                throw new ArgumentNullException(nameof(threshold));
            }

            this.threshold = threshold;

            this.isPushed = isPushed;
        }

        public Push Convert(Blink signal)
        {
            if (isPushed)
            {
                isPushed = threshold.LowerLimit <= signal.Ratio;
            }
            else
            {
                isPushed = threshold.UpperLimit <= signal.Ratio;
            }

            return isPushed ? Push.Enabled : Push.Disabled;
        }
    }
}
