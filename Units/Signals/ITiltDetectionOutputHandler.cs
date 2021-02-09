using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    public interface ITiltDetectionOutputHandler :
        ISoftwareHandler
    {
        IPulseDetectionOutputHandler Left { get; }

        IPulseDetectionOutputHandler Right { get; }

        IPulseDetectionOutputHandler Forward { get; }

        IPulseDetectionOutputHandler Backward { get; }
    }
}
