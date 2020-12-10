using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Units
{
    public interface IEyeTrackerEventHandler :
        ISoftwareHandler
    {
        IPupilEventHandler Pupil { get; }

        IBlinkEventHandler Blink { get; }
    }
}
