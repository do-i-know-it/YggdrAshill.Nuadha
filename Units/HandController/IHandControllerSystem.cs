using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    public interface IHandControllerSystem :
        ISystem
    {
        IPoseTrackerSystem PoseTracker { get; }

        IStickSystem ThumbStick { get; }

        ITriggerSystem FingerTrigger { get; }

        ITriggerSystem HandTrigger { get; }
    }
}
