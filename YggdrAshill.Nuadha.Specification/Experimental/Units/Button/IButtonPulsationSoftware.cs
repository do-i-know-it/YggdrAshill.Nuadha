using YggdrAshill.Nuadha.Signalization.Experimental;
using YggdrAshill.Nuadha.Transformation.Experimental;
using YggdrAshill.Nuadha.Unitization.Experimental;

namespace YggdrAshill.Nuadha.Units.Experimental
{
    public interface IButtonPulsationSoftware :
        IHandler
    {
        IConsumption<Pulse> Touch { get; }

        IConsumption<Pulse> Push { get; }
    }
}
