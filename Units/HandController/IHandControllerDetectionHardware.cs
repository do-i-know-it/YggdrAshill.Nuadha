using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    public interface IHandControllerDetectionHardware :
        IHardware
    {
        IStickDetectionHardware ThumbStick { get; }

        ITriggerDetectionHardware FingerTrigger { get; }

        ITriggerDetectionHardware HandTrigger { get; }
    }
}
