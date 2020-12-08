using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha
{
    public interface IEyeTrackerConfiguration
    {
        ISource<Pupil> Pupil { get; }

        ISource<Blink> Blink { get; }
    }
}
