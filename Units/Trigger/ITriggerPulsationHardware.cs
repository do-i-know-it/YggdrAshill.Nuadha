using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    public interface ITriggerPulsationHardware :
        IHandler
    {
        IProduction<Pulse> Touch { get; }

        IProduction<Pulse> Pull { get; }
    }
}
