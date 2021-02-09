using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    public interface ITiltDetectionInputHandler :
        IHardwareHandler
    {
        IPulseDetectionInputHandler Left { get; }

        IPulseDetectionInputHandler Right { get; }

        IPulseDetectionInputHandler Forward { get; }

        IPulseDetectionInputHandler Backward { get; }
    }
}
