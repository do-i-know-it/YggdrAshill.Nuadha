using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Units
{
    public interface IEyeTrackerSoftwareHandler :
        ISoftwareHandler
    {
        IConnection<Pupil> Pupil { get; }

        IConnection<Blink> Blink { get; }
    }
}
