using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    public interface IThreePointTrackerEventOutputHandler :
        ISoftwareHandler
    {
        IHeadsetEventOutputHandler Head { get; }

        IHandControllerEventOutputHandler LeftHand { get; }

        IHandControllerEventOutputHandler RightHand { get; }
    }
}
