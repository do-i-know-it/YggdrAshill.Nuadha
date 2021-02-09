using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    public interface IHandControllerDetectionOutputHandler :
        ISoftwareHandler
    {
        IStickDetectionOutputHandler ThumbStick { get; }

        ITriggerDetectionOutputHandler FingerTrigger { get; }

        ITriggerDetectionOutputHandler HandTrigger { get; }
    }
}
