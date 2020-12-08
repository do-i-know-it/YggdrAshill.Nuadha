using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    public interface IThreePointTrackerSoftwareHandler :
        ISoftwareHandler
    {
        IHeadsetSoftwareHandler Head { get; }

        IHandControllerSoftwareHandler LeftHand { get; }

        IHandControllerSoftwareHandler RightHand { get; }
    }
}