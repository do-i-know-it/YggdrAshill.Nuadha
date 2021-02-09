using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Units
{
    public interface IStickHardwareHandler :
        IHardwareHandler,
        IButtonHardwareHandler
    {
        IConsumption<Tilt> Tilt { get; }
    }
}
