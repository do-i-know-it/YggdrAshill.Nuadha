using YggdrAshill.Nuadha.Manipulation;
using YggdrAshill.Nuadha.Signalization;

namespace YggdrAshill.Nuadha.Evaluation
{
    public sealed class DetectConverted<TInput, TOutput> : IDetection<TInput>
        where TInput : ISignal
        where TOutput : ISignal
    {
        private readonly IConversion<TInput, TOutput> conversion;
        private readonly IDetection<TOutput> detection;

        public DetectConverted(IConversion<TInput, TOutput> conversion, IDetection<TOutput> detection)
        {
            this.conversion = conversion;
            this.detection = detection;
        }

        public bool Detect(TInput signal)
        {
            var converted = conversion.Convert(signal);
            return detection.Detect(converted);
        }
    }
}
