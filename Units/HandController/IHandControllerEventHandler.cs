using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    public interface IHandControllerEventHandler :
        ISoftwareHandler
    {
        IStickEventHandler ThumbStick { get; }

        ITriggerEventHandler FingerTrigger { get; }

        ITriggerEventHandler HandTrigger { get; }
    }
}
