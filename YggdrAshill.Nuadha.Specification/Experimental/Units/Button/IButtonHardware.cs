using YggdrAshill.Nuadha.Signalization.Experimental;
using YggdrAshill.Nuadha.Unitization.Experimental;
using YggdrAshill.Nuadha.Signals.Experimental;

namespace YggdrAshill.Nuadha.Units.Experimental
{
    public interface IButtonHardware :
        IHandler
    {
        IProduction<Touch> Touch { get; }

        IProduction<Push> Push { get; }
    }
}
