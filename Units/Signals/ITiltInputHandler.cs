using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    public interface ITiltInputHandler :
        IHardwareHandler
    {
        IPulseInputHandler Left { get; }

        IPulseInputHandler Right { get; }

        IPulseInputHandler Forward { get; }

        IPulseInputHandler Backward { get; }
    }
}
