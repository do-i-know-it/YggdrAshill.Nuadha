using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    public interface IHandControllerEventOutputHandler :
        ISoftwareHandler
    {
        IStickEventOutputHandler ThumbStick { get; }

        ITriggerEventOutputHandler FingerTrigger { get; }

        ITriggerEventOutputHandler HandTrigger { get; }
    }
}
