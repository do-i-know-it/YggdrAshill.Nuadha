using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    public interface ITiltEventOutputHandler :
        ISoftwareHandler
    {
        IPulseEventOutputHandler Left { get; }

        IPulseEventOutputHandler Right { get; }

        IPulseEventOutputHandler Forward { get; }

        IPulseEventOutputHandler Backward { get; }
    }
}
