using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    public interface ITiltDetectionSoftwareHandler :
        IDevice
    {
        IDetectionSoftwareHandler Left { get; }

        IDetectionSoftwareHandler Right { get; }

        IDetectionSoftwareHandler Forward { get; }

        IDetectionSoftwareHandler Backward { get; }
    }
}
