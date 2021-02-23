using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    public interface IThreePointTrackerDevice :
        IDevice
    {
        IPoseTrackerDevice Head { get; }

        IPoseTrackerDevice LeftHand { get; }

        IPoseTrackerDevice RightHand { get; }
    }
}
