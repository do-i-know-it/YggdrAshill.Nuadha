using YggdrAshill.Nuadha.Signalization;

namespace YggdrAshill.Nuadha.Translation
{
    internal sealed class Detect<TSignal> :
        IConsumption<TSignal>
        where TSignal : ISignal
    {
        private readonly IConsumption<Pulse> consumption;

        private readonly IDetection<TSignal> detection;

        internal Detect(IConsumption<Pulse> consumption, IDetection<TSignal> detection)
        {
            this.consumption = consumption;

            this.detection = detection;
        }

        public void Consume(TSignal signal)
        {
            if (!detection.Detect(signal))
            {
                return;
            }

            consumption.Consume(Pulse.Instance);
        }
    }
}
