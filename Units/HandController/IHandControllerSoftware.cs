using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    public interface IHandControllerSoftware :
        ISoftware
    {
        IPoseTrackerSoftware PoseTracker { get; }

        IStickSoftware ThumbStick { get; }

        ITriggerSoftware FingerTrigger { get; }

        ITriggerSoftware HandTrigger { get; }
    }
}
