using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Conversion;
using YggdrAshill.Nuadha.Signals;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class PupilTranslationSystem : TranslationSystem<Pupil, Push>
    {
        protected override IPropagation<Pupil> Propagation { get; } = new Propagation<Pupil>();

        protected override ITranslation<Pupil, Push> Translation { get; }

        public PupilTranslationSystem(HysteresisThreshold threshold)
        {
            if (threshold == null)
            {
                throw new ArgumentNullException(nameof(threshold));
            }

            Translation = new PupilToPush(threshold);
        }
    }
}
