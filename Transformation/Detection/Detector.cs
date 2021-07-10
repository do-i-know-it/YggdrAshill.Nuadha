using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha.Transformation
{
    internal sealed class Detector<TSignal> :
        IProduction<Notice>
        where TSignal : ISignal
    {
        private readonly IProduction<TSignal> production;

        private readonly IDetection<TSignal> detection;

        internal Detector(IProduction<TSignal> production, IDetection<TSignal> detection)
        {
            this.production = production;

            this.detection = detection;
        }

        public ICancellation Produce(IConsumption<Notice> consumption)
        {
            if (consumption == null)
            {
                throw new ArgumentNullException(nameof(consumption));
            }

            return production.Produce(new Detect<TSignal>(detection, consumption));
        }
    }
}
