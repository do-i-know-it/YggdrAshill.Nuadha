using YggdrAshill.Nuadha.Manipulation;
using YggdrAshill.Nuadha.Signalization;

namespace YggdrAshill.Nuadha.Evaluation
{
    public sealed class DetectInversed<TSignal> : IDetection<TSignal>
        where TSignal : ISignal
    {
        private readonly IDetection<TSignal> detection;

        public DetectInversed(IDetection<TSignal> detection)
        {
            this.detection = detection;
        }

        public bool Detect(TSignal signal)
        {
            return !detection.Detect(signal);
        }
    }
}
