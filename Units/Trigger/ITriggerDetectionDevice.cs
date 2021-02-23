using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    public interface ITriggerDetectionDevice :
        IDevice
    {
        IDetectionDevice Touch { get; }

        IDetectionDevice Pull { get; }
    }
}
