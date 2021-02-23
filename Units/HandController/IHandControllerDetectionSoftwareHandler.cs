using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    public interface IHandControllerDetectionSoftwareHandler :
        IDevice
    {
        IStickDetectionSoftwareHandler ThumbStick { get; }

        ITriggerDetectionSoftwareHandler FingerTrigger { get; }

        ITriggerDetectionSoftwareHandler HandTrigger { get; }
    }
}
