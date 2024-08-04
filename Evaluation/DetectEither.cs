using YggdrAshill.Nuadha.Manipulation;
using YggdrAshill.Nuadha.Signalization;

namespace YggdrAshill.Nuadha.Evaluation
{
    public sealed class DetectEither<TSignal> : IDetection<TSignal>
        where TSignal : ISignal
    {
        private readonly IDetection<TSignal> first;

        private readonly IDetection<TSignal> second;

        public DetectEither(IDetection<TSignal> first, IDetection<TSignal> second)
        {
            this.first = first;

            this.second = second;
        }

        public bool Detect(TSignal signal)
        {
            return first.Detect(signal) || second.Detect(signal);
        }
    }
}
