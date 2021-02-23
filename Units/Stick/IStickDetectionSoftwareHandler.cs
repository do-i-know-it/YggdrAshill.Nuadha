using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    public interface IStickDetectionSoftwareHandler :
        IDevice,
        IButtonDetectionSoftwareHandler
    {
        ITiltDetectionSoftwareHandler Tilt { get; }
    }
}
