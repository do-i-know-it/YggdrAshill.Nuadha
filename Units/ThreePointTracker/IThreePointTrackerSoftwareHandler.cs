using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    public interface IThreePointTrackerSoftwareHandler :
        IDevice
    {
        IPoseTrackerSoftwareHandler Head { get; }

        IPoseTrackerSoftwareHandler LeftHand { get; }

        IPoseTrackerSoftwareHandler RightHand { get; }
    }
}
