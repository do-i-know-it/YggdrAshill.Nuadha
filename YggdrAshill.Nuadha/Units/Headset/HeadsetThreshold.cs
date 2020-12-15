namespace YggdrAshill.Nuadha
{
    public sealed class HeadsetThreshold :
        IHeadsetThreshold
    {
        public IEyeTrackerThreshold LeftEye { get; }

        public IEyeTrackerThreshold RightEye { get; }

        public HeadsetThreshold(HysteresisThreshold pupil, HysteresisThreshold blink)
        {
            LeftEye = new EyeTrackerThreshold(pupil, blink);

            RightEye = new EyeTrackerThreshold(pupil, blink);
        }
    }
}
