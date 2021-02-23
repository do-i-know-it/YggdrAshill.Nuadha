using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    public interface IThreePointTrackerSystem :
        ISystem
    {
        IPoseTrackerSystem Head { get; }

        IPoseTrackerSystem LeftHand { get; }

        IPoseTrackerSystem RightHand { get; }
    }
}
