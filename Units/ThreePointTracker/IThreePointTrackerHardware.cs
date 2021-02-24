using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    public interface IThreePointTrackerHardware :
        IHardware
    {
        IPoseTrackerHardware Head { get; }

        IPoseTrackerHardware LeftHand { get; }

        IPoseTrackerHardware RightHand { get; }
    }
}
