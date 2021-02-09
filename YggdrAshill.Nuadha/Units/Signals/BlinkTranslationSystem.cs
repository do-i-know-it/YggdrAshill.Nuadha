using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Conversion;
using YggdrAshill.Nuadha.Signals;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class BlinkTranslationSystem : TranslationSystem<Blink, Push>
    {
        protected override IPropagation<Blink> Propagation { get; } = new Propagation<Blink>();

        protected override ITranslation<Blink, Push> Translation { get; }

        public BlinkTranslationSystem(HysteresisThreshold threshold)
        {
            if (threshold == null)
            {
                throw new ArgumentNullException(nameof(threshold));
            }

            Translation = new BlinkToPush(threshold);
        }
    }
}
