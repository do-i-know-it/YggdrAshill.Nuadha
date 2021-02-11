using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    public interface IStickDetectionSoftwareHandler :
        ISoftwareHandler,
        IButtonDetectionSoftwareHandler
    {
        ITiltDetectionSoftwareHandler Tilt { get; }
    }
}
