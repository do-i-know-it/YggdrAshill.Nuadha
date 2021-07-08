using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Units
{
    public interface ITriggerHardware :
        IHandler
    {
        IProduction<Touch> Touch { get; }

        IProduction<Pull> Pull { get; }
    }
}
