using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Units
{
    public interface IButtonSystem :
        ISystem
    {
        IConsumption<Touch> Touch { get; }

        IConsumption<Push> Push { get; }
    }
}
