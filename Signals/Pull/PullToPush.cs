using YggdrAshill.Nuadha.Translation;

namespace YggdrAshill.Nuadha.Signals
{
    public sealed class PullToPush :
        IConversion<Pull, Push>
    {
        private readonly HysteresisThreshold threshold;

        private bool isPushed;

        public PullToPush(HysteresisThreshold threshold, bool isPushed = false)
        {
            this.threshold = threshold;

            this.isPushed = isPushed;
        }

        public Push Convert(Pull signal)
        {
            isPushed = IsPushed(signal.Strength);

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
