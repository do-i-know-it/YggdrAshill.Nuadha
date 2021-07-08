using YggdrAshill.Nuadha.Signalization.Experimental;
using YggdrAshill.Nuadha.Unitization.Experimental;
using YggdrAshill.Nuadha.Signals.Experimental;

namespace YggdrAshill.Nuadha.Units.Experimental
{
    public interface IButtonSoftware :
        IHandler
    {
        IConsumption<Touch> Touch { get; }

        IConsumption<Push> Push { get; }
    }
}
