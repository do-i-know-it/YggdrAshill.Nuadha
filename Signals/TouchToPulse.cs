using YggdrAshill.Nuadha.Transformation;

namespace YggdrAshill.Nuadha.Signals
{
    public sealed class TouchToPulse :
        IPulsation<Touch>,
        IDetection<Touch>
    {
        private readonly IntoPulseFrom<Touch> pulsation;

        public TouchToPulse()
        {
            pulsation = new IntoPulseFrom<Touch>(this);
        }

        public Pulse Pulsate(Touch signal)
        {
            return pulsation.Pulsate(signal);
        }

        bool IDetection<Touch>.Detect(Touch signal)
        {
            return (bool)signal;
        }
    }
}
