using YggdrAshill.Nuadha.Transformation.Experimental;

namespace YggdrAshill.Nuadha.Signals.Experimental
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

        public bool Detect(Touch signal)
        {
            return (bool)signal;
        }

        public Pulse Pulsate(Touch signal)
        {
            return pulsation.Pulsate(signal);
        }
    }
}
