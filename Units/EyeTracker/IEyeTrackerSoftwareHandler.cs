using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Units
{
    public interface IEyeTrackerSoftwareHandler :
        ISoftwareHandler
    {
        IOutputTerminal<Pupil> Pupil { get; }

        IOutputTerminal<Blink> Blink { get; }
    }
}
