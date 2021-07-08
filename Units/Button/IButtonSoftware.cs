using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Units
{
    public interface IButtonSoftware :
        IHandler
    {
        IConsumption<Touch> Touch { get; }

        IConsumption<Push> Push { get; }
    }
}
