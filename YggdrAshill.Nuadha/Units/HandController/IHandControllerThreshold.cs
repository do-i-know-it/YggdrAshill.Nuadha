namespace YggdrAshill.Nuadha
{
    public interface IHandControllerThreshold
    {
        ITiltThreshold ThumbStick { get; }

        HysteresisThreshold FingerTrigger { get; }

        HysteresisThreshold HandTrigger { get; }
    }
}
