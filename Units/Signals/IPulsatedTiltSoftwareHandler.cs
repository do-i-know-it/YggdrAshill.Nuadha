using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    public interface IPulsatedTiltSoftwareHandler :
        IHandler
    {
        IProduction<Pulse> Distance { get; }

        IProduction<Pulse> Left { get; }

        IProduction<Pulse> Right { get; }

        IProduction<Pulse> Forward { get; }

        IProduction<Pulse> Backward { get; }
    }
}
