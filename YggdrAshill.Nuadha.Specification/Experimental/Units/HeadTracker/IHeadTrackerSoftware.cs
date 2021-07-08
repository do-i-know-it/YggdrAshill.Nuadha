using YggdrAshill.Nuadha.Signalization.Experimental;
using YggdrAshill.Nuadha.Unitization.Experimental;
using YggdrAshill.Nuadha.Signals.Experimental;

namespace YggdrAshill.Nuadha.Units.Experimental
{
    public interface IHeadTrackerSoftware :
        IHandler
    {
        IPoseTrackerSoftware Pose { get; }

        IConsumption<Space3D.Direction> Direction { get; }
    }
}
