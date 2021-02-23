using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    public interface IHandControllerHardwareHandler :
        ISystem
    {
        IPoseTrackerHardwareHandler PoseTracker { get; }

        IStickHardwareHandler ThumbStick { get; }

        ITriggerHardwareHandler FingerTrigger { get; }

        ITriggerHardwareHandler HandTrigger { get; }
    }
}
