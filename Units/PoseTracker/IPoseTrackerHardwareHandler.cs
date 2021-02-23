using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Units
{
    public interface IPoseTrackerHardwareHandler :
        ISystem
    {
        IConsumption<Position> Position { get; }

        IConsumption<Rotation> Rotation { get; }
    }
}
