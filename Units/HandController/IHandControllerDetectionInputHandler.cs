using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    public interface IHandControllerDetectionInputHandler :
        IHardwareHandler
    {
        IStickDetectionInputHandler ThumbStick { get; }

        ITriggerDetectionInputHandler FingerTrigger { get; }

        ITriggerDetectionInputHandler HandTrigger { get; }
    }
}
