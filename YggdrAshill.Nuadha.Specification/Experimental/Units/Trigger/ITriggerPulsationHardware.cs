using YggdrAshill.Nuadha.Signalization.Experimental;
using YggdrAshill.Nuadha.Transformation.Experimental;
using YggdrAshill.Nuadha.Unitization.Experimental;

namespace YggdrAshill.Nuadha.Units.Experimental
{
    public interface ITriggerPulsationHardware :
        IHandler
    {
        IProduction<Pulse> Touch { get; }

        IProduction<Pulse> Pull { get; }
    }
}
