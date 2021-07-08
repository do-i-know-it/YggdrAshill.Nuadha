using YggdrAshill.Nuadha.Signalization.Experimental;
using YggdrAshill.Nuadha.Transformation.Experimental;
using YggdrAshill.Nuadha.Unitization.Experimental;

namespace YggdrAshill.Nuadha.Units.Experimental
{
    public interface IStickPulsationHardware :
        IHandler
    {
        IProduction<Pulse> Touch { get; }

        IProduction<Pulse> Distance { get; }

        IProduction<Pulse> Left { get; }

        IProduction<Pulse> Right { get; }

        IProduction<Pulse> Upward { get; }

        IProduction<Pulse> Downward { get; }
    }
}
