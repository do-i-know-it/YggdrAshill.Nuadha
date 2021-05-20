using YggdrAshill.Nuadha.Transformation.Experimental;

namespace YggdrAshill.Nuadha.Signals.Experimental
{
    public sealed class PushToPulse :
        IPulsation<Push>,
        IDetection<Push>
    {
        private readonly IntoPulseFrom<Push> pulsation;

        public PushToPulse()
        {
            pulsation = new IntoPulseFrom<Push>(this);
        }

        public bool Detect(Push signal)
        {
            return (bool)signal;
        }

        public Pulse Pulsate(Push signal)
        {
            return pulsation.Pulsate(signal);
        }
    }
}
