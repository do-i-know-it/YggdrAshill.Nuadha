using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    public interface IPulsatedTriggerHardwareHandler :
        IHandler
    {
        IConsumption<Pulse> Touch { get; }

        IConsumption<Pulse> Pull { get; }
    }
}
