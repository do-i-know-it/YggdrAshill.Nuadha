using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Units
{
    public interface IHeadTrackerSoftwareHandler :
        IHandler
    {
        IPoseTrackerSoftwareHandler Pose { get; }

        IProduction<Space3D.Direction> Direction { get; }
    }
}
