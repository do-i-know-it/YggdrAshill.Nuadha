using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    public interface IThreePointTrackerSoftware :
        ISoftware
    {
        IPoseTrackerSoftware Head { get; }

        IPoseTrackerSoftware LeftHand { get; }

        IPoseTrackerSoftware RightHand { get; }
    }
}
