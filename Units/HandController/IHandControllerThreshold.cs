using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Units
{
    public interface IHandControllerThreshold
    {
        ITiltThreshold ThumbStick { get; }

        IHysteresisThreshold FingerTrigger { get; }

        IHysteresisThreshold HandTrigger { get; }
    }
}
