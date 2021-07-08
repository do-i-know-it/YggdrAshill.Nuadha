using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Units
{
    public interface IButtonHardware :
        IHandler
    {
        IProduction<Touch> Touch { get; }

        IProduction<Push> Push { get; }
    }
}
