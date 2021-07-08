using YggdrAshill.Nuadha.Transformation;

namespace YggdrAshill.Nuadha.Signals
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

        public Pulse Pulsate(Push signal)
        {
            return pulsation.Pulsate(signal);
        }

        bool IDetection<Push>.Detect(Push signal)
        {
            return (bool)signal;
        }
    }
}
