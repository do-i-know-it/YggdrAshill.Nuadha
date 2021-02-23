using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    public interface IButtonDetectionSoftwareHandler :
        IDevice
    {
        IDetectionSoftwareHandler Touch { get; }

        IDetectionSoftwareHandler Push { get; }
    }
}
