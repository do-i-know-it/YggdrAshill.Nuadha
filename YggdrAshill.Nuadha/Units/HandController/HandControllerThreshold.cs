using YggdrAshill.Nuadha.Signals;
using YggdrAshill.Nuadha.Units;
using System;

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
            if (thumbStick == null)
            {
                throw new ArgumentNullException(nameof(thumbStick));
            }
            if (fingerTrigger == null)
            {
                throw new ArgumentNullException(nameof(fingerTrigger));
            }
            if (handTrigger == null)
            {
                throw new ArgumentNullException(nameof(handTrigger));
            }

            ThumbStick = new TiltThreshold(thumbStick);

            FingerTrigger = fingerTrigger;

            HandTrigger = handTrigger;
        }
    }
}
