using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    public interface IThreePointTrackerDetectionOutputHandler :
        ISoftwareHandler
    {
        IHandControllerDetectionOutputHandler LeftHand { get; }

        IHandControllerDetectionOutputHandler RightHand { get; }
    }
}
