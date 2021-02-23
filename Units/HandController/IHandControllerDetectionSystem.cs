using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    public interface IHandControllerDetectionSystem :
        ISystem
    {
        IStickDetectionSystem ThumbStick { get; }

        ITriggerDetectionSystem FingerTrigger { get; }

        ITriggerDetectionSystem HandTrigger { get; }
    }
}
