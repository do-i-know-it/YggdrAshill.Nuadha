using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    public interface ITriggerDetectionSoftwareHandler :
        IDevice
    {
        IDetectionSoftwareHandler Touch { get; }

        IDetectionSoftwareHandler Pull { get; }
    }
}
