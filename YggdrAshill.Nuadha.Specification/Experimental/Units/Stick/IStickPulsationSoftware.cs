using YggdrAshill.Nuadha.Signalization.Experimental;
using YggdrAshill.Nuadha.Transformation.Experimental;
using YggdrAshill.Nuadha.Unitization.Experimental;

namespace YggdrAshill.Nuadha.Units.Experimental
{
    public interface IStickPulsationSoftware :
        IHandler
    {
        IConsumption<Pulse> Touch { get; }

        IConsumption<Pulse> Distance { get; }

        IConsumption<Pulse> Left { get; }

        IConsumption<Pulse> Right { get; }

        IConsumption<Pulse> Upward { get; }

        IConsumption<Pulse> Downward { get; }
    }
}
