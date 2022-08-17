using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using System;

namespace YggdrAshill.Nuadha.Conduction
{
    public sealed class ConsumeToSwitch<TSignal> :
        IConsumption<TSignal>
        where TSignal : ISignal
    {
        private readonly IDetection<TSignal> detection;

        private readonly IConsumption<TSignal> then;

        private readonly IConsumption<TSignal> otherwise;

        public ConsumeToSwitch(IDetection<TSignal> detection, IConsumption<TSignal> then, IConsumption<TSignal> otherwise)
        {
            if (detection == null)
            {
                throw new ArgumentNullException(nameof(detection));
            }
            if (then == null)
            {
                throw new ArgumentNullException(nameof(then));
            }
            if (otherwise == null)
            {
                throw new ArgumentNullException(nameof(otherwise));
            }

            this.detection = detection;

            this.then = then;

            this.otherwise = otherwise;
        }

        public void Consume(TSignal signal)
        {
            if (detection.Detect(signal))
            {
                then.Consume(signal);
            }
            else
            {
                otherwise.Consume(signal);
            }
        }
    }
}
