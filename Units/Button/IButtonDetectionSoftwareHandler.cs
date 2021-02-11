using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    public interface IButtonDetectionSoftwareHandler :
        ISoftwareHandler
    {
        IDetectionSoftwareHandler Touch { get; }

        IDetectionSoftwareHandler Push { get; }
    }
}
