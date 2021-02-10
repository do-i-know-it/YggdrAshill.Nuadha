using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    public interface IThreePointTrackerHardwareHandler :
        IHardwareHandler
    {
        IPoseTrackerHardwareHandler Origin { get; }

        IPoseTrackerHardwareHandler Head { get; }

        IPoseTrackerHardwareHandler LeftHand { get; }

        IPoseTrackerHardwareHandler RightHand { get; }
    }
}
