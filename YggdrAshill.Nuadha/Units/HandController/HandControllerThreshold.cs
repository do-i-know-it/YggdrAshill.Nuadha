using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha
{
    public sealed class HandControllerThreshold :
        IHandControllerThreshold
    {
        public ITiltThreshold ThumbStick { get; }

        public HysteresisThreshold FingerTrigger { get; }

        public HysteresisThreshold HandTrigger { get; }

        public HandControllerThreshold(HysteresisThreshold thumbStick, HysteresisThreshold fingerTrigger, HysteresisThreshold handTrigger)
        {
            ThumbStick = new TiltThreshold(thumbStick);

            FingerTrigger = fingerTrigger;

            HandTrigger = handTrigger;
        }
    }
}
