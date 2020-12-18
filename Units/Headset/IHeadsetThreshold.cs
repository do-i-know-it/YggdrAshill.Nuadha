namespace YggdrAshill.Nuadha.Units
{
    public interface IHeadsetThreshold
    {
        IEyeTrackerThreshold LeftEye { get; }

        IEyeTrackerThreshold RightEye { get; }
    }
}
