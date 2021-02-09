using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha
{
    public interface IEyeTrackerConfiguration
    {
        IProduction<Pupil> Pupil { get; }

        IProduction<Blink> Blink { get; }
    }
}
