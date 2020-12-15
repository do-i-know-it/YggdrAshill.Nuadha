namespace YggdrAshill.Nuadha
{
    public interface IHeadsetThreshold
    {
        IEyeTrackerThreshold LeftEye { get; }

        IEyeTrackerThreshold RightEye { get; }
    }
}
