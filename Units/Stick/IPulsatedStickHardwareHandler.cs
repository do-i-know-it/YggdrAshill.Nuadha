using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    public interface IPulsatedStickHardwareHandler :
        IHandler
    {
        IConsumption<Pulse> Touch { get; }

        IPulsatedTiltHardwareHandler Tilt { get; }
    }
}
