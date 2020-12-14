using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Units
{
    public interface IEyeTrackerEventOutputHandler :
        ISoftwareHandler
    {
        IPupilEventOutputHandler Pupil { get; }

        IBlinkEventOutputHandler Blink { get; }
    }
}
