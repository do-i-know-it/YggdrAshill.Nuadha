using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Translation;

namespace YggdrAshill.Nuadha.Units
{
    public interface IEyeTrackerEventInputHandler :
        IHardwareHandler
    {
        IPulseEventInputHandler Pupil { get; }

        IPulseEventInputHandler Blink { get; }
    }
}
