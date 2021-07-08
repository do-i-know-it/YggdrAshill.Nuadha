using YggdrAshill.Nuadha.Signalization.Experimental;
using YggdrAshill.Nuadha.Unitization.Experimental;
using YggdrAshill.Nuadha.Signals.Experimental;

namespace YggdrAshill.Nuadha.Units.Experimental
{
    public interface IStickHardware :
        IHandler
    {
        IProduction<Touch> Touch { get; }

        IProduction<Tilt> Tilt { get; }
    }
}
