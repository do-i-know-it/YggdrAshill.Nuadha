using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Units
{
    public interface ITriggerSoftware :
        ISoftware
    {
        IConsumption<Touch> Touch { get; }

        IConsumption<Pull> Pull { get; }
    }
}
