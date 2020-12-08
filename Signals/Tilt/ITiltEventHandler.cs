using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Signals
{
    public interface ITiltEventHandler :
        ISoftwareHandler
    {
        IPullEventHandler Center { get; }

        IPullEventHandler Left { get; }

        IPullEventHandler Right { get; }

        IPullEventHandler Up { get; }

        IPullEventHandler Down { get; }
    }
}
