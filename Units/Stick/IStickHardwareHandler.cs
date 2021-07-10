using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Units
{
    public interface IStickHardwareHandler :
        IHandler
    {
        IConsumption<Touch> Touch { get; }

        IConsumption<Tilt> Tilt { get; }
    }
}
