using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    public interface IHandControllerSoftwareHandler :
        IHandler
    {
        IPoseTrackerSoftwareHandler Pose { get; }

        IStickSoftwareHandler Thumb { get; }

        ITriggerSoftwareHandler IndexFinger { get; }

        ITriggerSoftwareHandler HandGrip { get; }
    }
}
