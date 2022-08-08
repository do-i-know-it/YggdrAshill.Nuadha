using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using System;

namespace YggdrAshill.Nuadha.Conduction
{
    public sealed class ConvertToDetect<TSignal, TMedium> :
        IDetection<TSignal>
        where TSignal : ISignal
        where TMedium : ISignal
    {
        private readonly IConversion<TSignal, TMedium> conversion;

        private readonly IDetection<TMedium> detection;

        public ConvertToDetect(IConversion<TSignal, TMedium> conversion, IDetection<TMedium> detection)
        {
            if (conversion == null)
            {
                throw new ArgumentNullException(nameof(conversion));
            }
            if (detection == null)
            {
                throw new ArgumentNullException(nameof(detection));
            }

            this.conversion = conversion;

            this.detection = detection;
        }

        public bool Detect(TSignal signal)
        {
            var converted = conversion.Convert(signal);

            return detection.Detect(converted);
        }
    }
}
