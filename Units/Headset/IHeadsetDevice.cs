using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Units
{
    public interface IHeadsetDevice :
        IDevice
    {
        IConnection<Direction> Direction { get; }
        
        IPoseTrackerDevice PoseTracker { get; }
    }
}
