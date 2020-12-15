namespace YggdrAshill.Nuadha
{
    public interface IEyeTrackerThreshold
    {
        HysteresisThreshold Pupil { get; }

        HysteresisThreshold Blink { get; }
    }
}
