using YggdrAshill.Nuadha.Signalization.Experimental;
using YggdrAshill.Nuadha.Unitization.Experimental;
using YggdrAshill.Nuadha.Signals.Experimental;

namespace YggdrAshill.Nuadha.Units.Experimental
{
    public interface IPoseTrackerHardware :
        IHandler
    {
        IProduction<Space3D.Position> Position { get; }

        IProduction<Space3D.Rotation> Rotation { get; }
    }
}
