using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    public interface IHandControllerDetectionHardwareHandler :
        IHardwareHandler
    {
        IStickDetectionHardwareHandler ThumbStick { get; }

        ITriggerDetectionHardwareHandler FingerTrigger { get; }

        ITriggerDetectionHardwareHandler HandTrigger { get; }
    }
}
