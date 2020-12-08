using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    public interface IThreePointTrackerEventHandler :
        ISoftwareHandler
    {
        IHandControllerEventHandler LeftHand { get; }

        IHandControllerEventHandler RightHand { get; }
    }
}
