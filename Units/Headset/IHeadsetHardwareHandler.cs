using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Units
{
    public interface IHeadsetHardwareHandler :
        ISystem
    {
        IConsumption<Direction> Direction { get; }

        IPoseTrackerHardwareHandler PoseTracker { get; }
    }
}
