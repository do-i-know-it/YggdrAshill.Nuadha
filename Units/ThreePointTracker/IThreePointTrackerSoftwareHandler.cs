using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    public interface IThreePointTrackerSoftwareHandler :
        ISoftwareHandler
    {
        IPoseTrackerSoftwareHandler Origin { get; }

        IPoseTrackerSoftwareHandler Head { get; }

        IPoseTrackerSoftwareHandler LeftHand { get; }

        IPoseTrackerSoftwareHandler RightHand { get; }
    }
}
