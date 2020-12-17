using YggdrAshill.Nuadha.Translation;

namespace YggdrAshill.Nuadha.Signals
{
    public sealed class PupilToPush :
        IConversion<Pupil, Push>
    {
        private readonly HysteresisThreshold threshold;

        private bool isPushed;

        public PupilToPush(HysteresisThreshold threshold, bool isPushed = false)
        {
            this.threshold = threshold;

            this.isPushed = isPushed;
        }

        public Push Convert(Pupil signal)
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
