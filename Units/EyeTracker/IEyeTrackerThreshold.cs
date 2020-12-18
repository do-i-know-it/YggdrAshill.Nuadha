using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Units
{
    public interface IEyeTrackerThreshold
    {
        IHysteresisThreshold Pupil { get; }

        IHysteresisThreshold Blink { get; }
    }
}
