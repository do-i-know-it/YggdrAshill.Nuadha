using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Translation;
using YggdrAshill.Nuadha.Signals;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class PullConversionSystem : ConversionSystem<Pull, Push>
    {
        protected override IPropagation<Pull> Propagation { get; } = new Propagation<Pull>();

        protected override IConversion<Pull, Push> Conversion { get; }

        public PullConversionSystem(HysteresisThreshold threshold)
        {
            if (threshold == null)
            {
                throw new ArgumentNullException(nameof(threshold));
            }

            Conversion = new PullToPush(threshold);
        }
    }
}
