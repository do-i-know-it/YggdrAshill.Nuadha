using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    public interface IThreePointTrackerHardwareHandler :
        IHardwareHandler
    {
        IPoseTrackerHardwareHandler PoseTracker { get; }

        IHeadsetHardwareHandler Head { get; }

        IHandControllerHardwareHandler LeftHand { get; }

        IHandControllerHardwareHandler RightHand { get; }
    }
}
