using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    public interface IHandControllerDetectionSoftware :
        ISoftware
    {
        IStickDetectionSoftware ThumbStick { get; }

        ITriggerDetectionSoftware FingerTrigger { get; }

        ITriggerDetectionSoftware HandTrigger { get; }
    }
}
