using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    public interface IPulsatedTiltHardwareHandler :
        IHandler
    {
        IConsumption<Pulse> Distance { get; }

        IConsumption<Pulse> Left { get; }

        IConsumption<Pulse> Right { get; }

        IConsumption<Pulse> Forward { get; }

        IConsumption<Pulse> Backward { get; }
    }
}
