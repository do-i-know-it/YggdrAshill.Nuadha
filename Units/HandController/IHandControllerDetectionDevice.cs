using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    public interface IHandControllerDetectionDevice :
        IDevice
    {
        IStickDetectionDevice ThumbStick { get; }

        ITriggerDetectionDevice FingerTrigger { get; }

        ITriggerDetectionDevice HandTrigger { get; }
    }
}
