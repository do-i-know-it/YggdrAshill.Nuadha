using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    public interface ITiltDetectionHardwareHandler :
        IHardwareHandler
    {
        IDetectionHardwareHandler Left { get; }

        IDetectionHardwareHandler Right { get; }

        IDetectionHardwareHandler Forward { get; }

        IDetectionHardwareHandler Backward { get; }
    }
}
