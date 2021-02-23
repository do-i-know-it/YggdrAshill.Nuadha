using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    public interface IHandControllerDevice :
        IDevice
    {
        IPoseTrackerDevice PoseTracker { get; }

        IStickDevice ThumbStick { get; }

        ITriggerDevice FingerTrigger { get; }

        ITriggerDevice HandTrigger { get; }
    }
}
