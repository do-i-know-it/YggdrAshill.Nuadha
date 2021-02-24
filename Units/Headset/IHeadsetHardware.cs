using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Units
{
    public interface IHeadsetHardware :
        IHardware
    {
        IConnection<Direction> Direction { get; }
        
        IPoseTrackerHardware PoseTracker { get; }
    }
}
