using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
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
