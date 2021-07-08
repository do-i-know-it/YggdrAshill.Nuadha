using YggdrAshill.Nuadha.Signalization.Experimental;
using YggdrAshill.Nuadha.Unitization.Experimental;
using YggdrAshill.Nuadha.Signals.Experimental;

namespace YggdrAshill.Nuadha.Units.Experimental
{
    public interface IHeadTrackerHardware :
        IHandler
    {
        IPoseTrackerHardware Pose { get; }

        IProduction<Space3D.Direction> Direction { get; }
    }
}
