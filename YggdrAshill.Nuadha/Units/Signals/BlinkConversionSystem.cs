using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Conversion;
using YggdrAshill.Nuadha.Signals;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class BlinkConversionSystem : ConversionSystem<Blink, Push>
    {
        protected override IPropagation<Blink> Propagation { get; } = new Propagation<Blink>();

        protected override IConversion<Blink, Push> Conversion { get; }

        public BlinkConversionSystem(HysteresisThreshold threshold)
        {
            if (threshold == null)
            {
                throw new ArgumentNullException(nameof(threshold));
            }

            Conversion = new BlinkToPush(threshold);
        }
    }
}
