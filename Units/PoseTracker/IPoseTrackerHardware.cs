using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Units
{
    public interface IPoseTrackerHardware :
        IHandler
    {
        IProduction<Space3D.Position> Position { get; }

        IProduction<Space3D.Rotation> Rotation { get; }
    }
}
