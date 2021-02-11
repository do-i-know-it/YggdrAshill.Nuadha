using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    public interface IHandControllerDetectionSoftwareHandler :
        ISoftwareHandler
    {
        IStickDetectionSoftwareHandler ThumbStick { get; }

        ITriggerDetectionSoftwareHandler FingerTrigger { get; }

        ITriggerDetectionSoftwareHandler HandTrigger { get; }
    }
}
