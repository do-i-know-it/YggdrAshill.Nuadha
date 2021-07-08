using YggdrAshill.Nuadha.Signalization.Experimental;
using YggdrAshill.Nuadha.Unitization.Experimental;
using YggdrAshill.Nuadha.Signals.Experimental;

namespace YggdrAshill.Nuadha.Units.Experimental
{
    public interface ITriggerHardware :
        IHandler
    {
        IProduction<Touch> Touch { get; }

        IProduction<Pull> Pull { get; }
    }
}
