using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    public interface IThreePointTrackerHardwareHandler :
        IHardwareHandler
    {
        IHeadsetHardwareHandler Head { get; }

        IHandControllerHardwareHandler LeftHand { get; }

        IHandControllerHardwareHandler RightHand { get; }
    }
}
