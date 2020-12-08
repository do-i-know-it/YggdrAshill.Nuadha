using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha
{
    public interface ITiltEventHandler :
        ISoftwareHandler
    {
        IPullEventHandler Tilted { get; }

        IPullEventHandler Left { get; }

        IPullEventHandler Right { get; }

        IPullEventHandler Up { get; }

        IPullEventHandler Down { get; }
    }
}
