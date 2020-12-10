using YggdrAshill.Nuadha.Operation;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha
{
    public sealed class BlinkToPush :
        IConversion<Blink, Push>
    {
        private readonly HysteresisThreshold threshold;

        private bool isPushed;

        public BlinkToPush(HysteresisThreshold threshold, bool isPushed = false)
        {
            this.threshold = threshold;

            this.isPushed = isPushed;
        }

        public Push Convert(Blink signal)
        {
            isPushed = IsPushed(signal.Ratio);

            return isPushed ? Push.Enabled : Push.Disabled;
        }
        private bool IsPushed(float strength)
        {
            if (isPushed)
            {
                return threshold.LowerLimit <= strength;
            }
            else
            {
                return threshold.UpperLimit <= strength;
            }
        }
    }
}
