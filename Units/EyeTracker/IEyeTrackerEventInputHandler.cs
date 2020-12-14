using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Units
{
    public interface IEyeTrackerEventInputHandler :
        IHardwareHandler
    {
        IPupilEventInputHandler Pupil { get; }

        IBlinkEventInputHandler Blink { get; }
    }
}
