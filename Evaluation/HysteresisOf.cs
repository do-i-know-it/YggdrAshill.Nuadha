using YggdrAshill.Nuadha.Manipulation;
using YggdrAshill.Nuadha.Signalization;

namespace YggdrAshill.Nuadha.Evaluation
{
    public sealed class HysteresisOf<TSignal> : IDetection<TSignal>
        where TSignal : ISignal
    {
        private readonly ICache<Edge> previous;
        private readonly IHysteresisThreshold<TSignal> threshold;

        public HysteresisOf(ICache<Edge> previous, IHysteresisThreshold<TSignal> threshold)
        {
            this.previous = previous;
            this.threshold = threshold;
        }

        public bool Detect(TSignal signal)
        {
            var result = (bool)previous.Value ? threshold.LowLevel.Detect(signal) : threshold.HighLevel.Detect(signal);

            try
            {
                return result;
            }
            finally
            {
                previous.Value = (Edge)result;
            }
        }
    }
}
