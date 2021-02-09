using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Units
{
    public interface IHeadsetSoftwareHandler :
        ISoftwareHandler
    {
        IConnection<Direction> Direction { get; }
        
        IPoseTrackerSoftwareHandler PoseTracker { get; }

        IEyeTrackerSoftwareHandler LeftEye { get; }

        IEyeTrackerSoftwareHandler RightEye { get; }
    }
}
