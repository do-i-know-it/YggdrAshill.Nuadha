using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Units
{
    public interface IHeadTrackerHardwareHandler :
        IHandler
    {
        IPoseTrackerHardwareHandler Pose { get; }

        IConsumption<Space3D.Direction> Direction { get; }
    }
}
