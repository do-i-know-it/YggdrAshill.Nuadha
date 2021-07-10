using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Units
{
    public interface IPoseTrackerHardwareHandler :
        IHandler
    {
        IConsumption<Space3D.Position> Position { get; }

        IConsumption<Space3D.Rotation> Rotation { get; }
    }
}
