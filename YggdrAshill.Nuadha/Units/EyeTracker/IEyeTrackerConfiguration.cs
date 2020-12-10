using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha
{
    public interface IEyeTrackerConfiguration
    {
        IGenerator<Pupil> Pupil { get; }

        IGenerator<Blink> Blink { get; }
    }
}
