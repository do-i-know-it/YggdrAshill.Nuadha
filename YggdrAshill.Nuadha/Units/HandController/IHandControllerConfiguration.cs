namespace YggdrAshill.Nuadha
{
    public interface IHandControllerConfiguration
    {
        IPoseTrackerConfiguration PoseTracker { get; }

        IStickConfiguration ThumbStick { get; }

        ITriggerConfiguration FingerTrigger { get; }

        ITriggerConfiguration HandTrigger { get; }
    }
}
