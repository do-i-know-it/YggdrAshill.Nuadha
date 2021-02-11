using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    public interface IThreePointTrackerSoftwareHandler :
        ISoftwareHandler
    {
        IPoseTrackerSoftwareHandler Head { get; }

        IPoseTrackerSoftwareHandler LeftHand { get; }

        IPoseTrackerSoftwareHandler RightHand { get; }
    }
}
