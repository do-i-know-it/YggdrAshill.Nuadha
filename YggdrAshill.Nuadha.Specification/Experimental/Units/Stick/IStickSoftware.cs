using YggdrAshill.Nuadha.Signalization.Experimental;
using YggdrAshill.Nuadha.Unitization.Experimental;
using YggdrAshill.Nuadha.Signals.Experimental;

namespace YggdrAshill.Nuadha.Units.Experimental
{
    public interface IStickSoftware :
        IHandler
    {
        IConsumption<Touch> Touch { get; }

        IConsumption<Tilt> Tilt { get; }
    }
}
