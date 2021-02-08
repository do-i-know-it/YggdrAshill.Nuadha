using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    public interface ITiltOutputHandler :
        ISoftwareHandler
    {
        IPulseOutputHandler Left { get; }

        IPulseOutputHandler Right { get; }

        IPulseOutputHandler Forward { get; }

        IPulseOutputHandler Backward { get; }
    }
}
