using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Conversion;
using YggdrAshill.Nuadha.Signals;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class PullTranslationSystem : TranslationSystem<Pull, Push>
    {
        protected override IPropagation<Pull> Propagation { get; } = new Propagation<Pull>();

        protected override ITranslation<Pull, Push> Translation { get; }

        public PullTranslationSystem(HysteresisThreshold threshold)
        {
            if (threshold == null)
            {
                throw new ArgumentNullException(nameof(threshold));
            }

            Translation = new PullToPush(threshold);
        }
    }
}
