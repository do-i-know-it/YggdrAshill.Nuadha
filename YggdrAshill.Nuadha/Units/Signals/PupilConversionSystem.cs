using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Translation;
using YggdrAshill.Nuadha.Signals;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class PupilConversionSystem : ConversionSystem<Pupil, Push>
    {
        protected override IPropagation<Pupil> Propagation { get; } = new Propagation<Pupil>();

        protected override IConversion<Pupil, Push> Conversion { get; }

        public PupilConversionSystem(HysteresisThreshold threshold)
        {
            if (threshold == null)
            {
                throw new ArgumentNullException(nameof(threshold));
            }

            Conversion = new PupilToPush(threshold);
        }
    }
}
