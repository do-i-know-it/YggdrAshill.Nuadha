using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Units
{
    public interface IEyeTrackerHardwareHandler :
        IHardwareHandler
    {
        IInputTerminal<Pupil> Pupil { get; }

        IInputTerminal<Blink> Blink { get; }
    }
}
