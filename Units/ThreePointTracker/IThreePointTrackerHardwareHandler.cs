using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    public interface IThreePointTrackerHardwareHandler :
        ISystem
    {
        IPoseTrackerHardwareHandler Head { get; }

        IPoseTrackerHardwareHandler LeftHand { get; }

        IPoseTrackerHardwareHandler RightHand { get; }
    }
}
