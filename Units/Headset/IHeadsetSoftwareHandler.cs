using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Units
{
    public interface IHeadsetSoftwareHandler :
        IDevice
    {
        IConnection<Direction> Direction { get; }
        
        IPoseTrackerSoftwareHandler PoseTracker { get; }
    }
}
