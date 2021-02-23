using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Units
{
    public interface ITriggerSystem :
        ISystem
    {
        IConsumption<Touch> Touch { get; }

        IConsumption<Pull> Pull { get; }
    }
}
