using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    public interface IHandControllerHardwareHandler :
        IHardwareHandler
    {
        IPoseTrackerHardwareHandler PoseTracker { get; }

        IStickHardwareHandler ThumbStick { get; }

        ITriggerHardwareHandler FingerTrigger { get; }

        ITriggerHardwareHandler HandTrigger { get; }
    }
}
