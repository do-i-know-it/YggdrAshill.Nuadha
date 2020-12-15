using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Signals
{
    public interface ITiltEventOutputHandler :
        ISoftwareHandler
    {
        IPullEventOutputHandler Center { get; }

        IPullEventOutputHandler Left { get; }

        IPullEventOutputHandler Right { get; }

        IPullEventOutputHandler Forward { get; }

        IPullEventOutputHandler Backward { get; }
    }
}
