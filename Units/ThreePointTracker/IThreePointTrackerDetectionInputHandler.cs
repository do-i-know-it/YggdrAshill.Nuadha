using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    public interface IThreePointTrackerDetectionInputHandler :
        IHardwareHandler
    {
        IHandControllerDetectionInputHandler LeftHand { get; }

        IHandControllerDetectionInputHandler RightHand { get; }
    }
}
