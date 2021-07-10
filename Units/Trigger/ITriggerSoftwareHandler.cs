using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Units
{
    public interface ITriggerSoftwareHandler :
        IHandler
    {
        IProduction<Touch> Touch { get; }

        IProduction<Pull> Pull { get; }
    }
}
