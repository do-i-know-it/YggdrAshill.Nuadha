using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    public interface IThreePointTrackerEventInputHandler :
        IHardwareHandler
    {
        IHeadsetEventInputHandler Head { get; }

        IHandControllerEventInputHandler LeftHand { get; }

        IHandControllerEventInputHandler RightHand { get; }
    }
}
