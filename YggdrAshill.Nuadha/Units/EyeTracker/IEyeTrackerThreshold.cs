using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha
{
    public interface IEyeTrackerThreshold
    {
        HysteresisThreshold Pupil { get; }

        HysteresisThreshold Blink { get; }
    }
}
