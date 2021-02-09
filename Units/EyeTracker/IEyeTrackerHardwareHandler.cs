using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Units
{
    public interface IEyeTrackerHardwareHandler :
        IHardwareHandler
    {
        IConsumption<Pupil> Pupil { get; }

        IConsumption<Blink> Blink { get; }
    }
}
