using YggdrAshill.Nuadha.Signals;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class EyeTrackerThreshold :
        IEyeTrackerThreshold
    {
        public IHysteresisThreshold Pupil { get; }
        
        public IHysteresisThreshold Blink { get; }
        
        public EyeTrackerThreshold(HysteresisThreshold pupil, HysteresisThreshold blink)
        {
            if (pupil == null)
            {
                throw new ArgumentNullException(nameof(pupil));
            }
            if (blink == null)
            {
                throw new ArgumentNullException(nameof(blink));
            }

            Pupil = pupil;
     
            Blink = blink;
        }
    }
}
