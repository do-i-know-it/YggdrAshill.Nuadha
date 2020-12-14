using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Signals
{
    public interface ITiltEventInputHandler :
        IHardwareHandler
    {
        IPullEventInputHandler Center { get; }

        IPullEventInputHandler Left { get; }

        IPullEventInputHandler Right { get; }

        IPullEventInputHandler Up { get; }

        IPullEventInputHandler Down { get; }
    }
}
