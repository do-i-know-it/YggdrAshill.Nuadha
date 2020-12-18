using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Translation;

namespace YggdrAshill.Nuadha.Units
{
    public interface IEyeTrackerEventOutputHandler :
        ISoftwareHandler
    {
        IPulseEventOutputHandler Pupil { get; }

        IPulseEventOutputHandler Blink { get; }
    }
}
