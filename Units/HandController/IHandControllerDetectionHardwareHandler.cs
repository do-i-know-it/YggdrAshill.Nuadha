using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    public interface IHandControllerDetectionHardwareHandler :
        ISystem
    {
        IStickDetectionHardwareHandler ThumbStick { get; }

        ITriggerDetectionHardwareHandler FingerTrigger { get; }

        ITriggerDetectionHardwareHandler HandTrigger { get; }
    }
}
