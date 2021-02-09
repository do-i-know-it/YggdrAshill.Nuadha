using YggdrAshill.Nuadha.Conversion;
using System;

namespace YggdrAshill.Nuadha.Signals
{
    public sealed class PupilToPush :
        ITranslation<Pupil, Push>
    {
        private readonly HysteresisThreshold threshold;

        private bool isPushed;

        public PupilToPush(HysteresisThreshold threshold, bool isPushed = false)
        {
            if (threshold == null)
            {
                throw new ArgumentNullException(nameof(threshold));
            }

            this.threshold = threshold;

            this.isPushed = isPushed;
        }

        public Push Translate(Pupil signal)
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
