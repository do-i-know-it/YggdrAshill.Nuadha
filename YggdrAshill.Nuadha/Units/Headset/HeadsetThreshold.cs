using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class HeadsetThreshold :
        IHeadsetThreshold
    {
        public IEyeTrackerThreshold LeftEye { get; }

        public IEyeTrackerThreshold RightEye { get; }

        public HeadsetThreshold(HysteresisThreshold pupil, HysteresisThreshold blink)
        {
            if (pupil == null)
            {
                throw new ArgumentNullException(nameof(pupil));
            }
            if (blink == null)
            {
                throw new ArgumentNullException(nameof(blink));
            }

            LeftEye = new EyeTrackerThreshold(pupil, blink);

            RightEye = new EyeTrackerThreshold(pupil, blink);
        }
    }
}
