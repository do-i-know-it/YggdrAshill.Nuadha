using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    public interface IHandControllerSoftwareHandler :
        IDevice
    {
        IPoseTrackerSoftwareHandler PoseTracker { get; }

        IStickSoftwareHandler ThumbStick { get; }

        ITriggerSoftwareHandler FingerTrigger { get; }

        ITriggerSoftwareHandler HandTrigger { get; }
    }
}
