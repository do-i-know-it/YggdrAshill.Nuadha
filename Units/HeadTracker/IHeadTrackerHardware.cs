using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Units
{
    public interface IHeadTrackerHardware :
        IHandler
    {
        IPoseTrackerHardware Pose { get; }

        IProduction<Space3D.Direction> Direction { get; }
    }
}
