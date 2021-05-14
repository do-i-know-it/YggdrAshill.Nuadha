using YggdrAshill.Nuadha.Signalization.Experimental;

namespace YggdrAshill.Nuadha.Transformation.Experimental
{
    internal sealed class Detect<TSignal> :
        IConsumption<TSignal>
        where TSignal : ISignal
    {
        private readonly IDetection<TSignal> detection;

        private readonly IConsumption<Notice> consumption;

        internal Detect(IDetection<TSignal> detection, IConsumption<Notice> consumption)
        {
            this.detection = detection;

            this.consumption = consumption;
        }

        public void Consume(TSignal signal)
        {
            if (detection.Detect(signal))
            {
                consumption.Consume(null);
            }
        }
    }
}
