using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Units
{
    public interface IHandControllerThreshold
    {
        ITiltThreshold ThumbStick { get; }

        HysteresisThreshold FingerTrigger { get; }

        HysteresisThreshold HandTrigger { get; }
    }
}
