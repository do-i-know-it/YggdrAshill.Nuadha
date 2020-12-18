using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Translation;

namespace YggdrAshill.Nuadha.Signals
{
    public interface ITiltEventInputHandler :
        IHardwareHandler
    {
        IPulseEventInputHandler Left { get; }

        IPulseEventInputHandler Right { get; }

        IPulseEventInputHandler Forward { get; }

        IPulseEventInputHandler Backward { get; }
    }
}
