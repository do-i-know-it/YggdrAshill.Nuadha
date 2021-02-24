using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    public interface IHandControllerHardware :
        IHardware
    {
        IPoseTrackerHardware PoseTracker { get; }

        IStickHardware ThumbStick { get; }

        ITriggerHardware FingerTrigger { get; }

        ITriggerHardware HandTrigger { get; }
    }
}
