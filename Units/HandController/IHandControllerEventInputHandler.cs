using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    public interface IHandControllerEventInputHandler :
        IHardwareHandler
    {
        IStickEventInputHandler ThumbStick { get; }

        ITriggerEventInputHandler FingerTrigger { get; }

        ITriggerEventInputHandler HandTrigger { get; }
    }
}
