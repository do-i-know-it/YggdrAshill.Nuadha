using YggdrAshill.Nuadha.Signals;
using System;

namespace YggdrAshill.Nuadha.Units
{
    public sealed class HandControllerThreshold
    {
        public TiltThreshold Thumb { get; }

        public HysteresisThreshold IndexFinger { get; }

        public HysteresisThreshold HandGrip { get; }

        public HandControllerThreshold(TiltThreshold thumb, HysteresisThreshold indexFinger, HysteresisThreshold handGrip)
        {
            if (thumb == null)
            {
                throw new ArgumentNullException(nameof(thumb));
            }
            if (indexFinger == null)
            {
                throw new ArgumentNullException(nameof(indexFinger));
            }
            if (handGrip == null)
            {
                throw new ArgumentNullException(nameof(handGrip));
            }

            Thumb = thumb;

            IndexFinger = indexFinger;

            HandGrip = handGrip;
        }

        public HandControllerThreshold(TiltThreshold stick, HysteresisThreshold trigger)
        {
            if (stick == null)
            {
                throw new ArgumentNullException(nameof(stick));
            }
            if (trigger == null)
            {
                throw new ArgumentNullException(nameof(trigger));
            }

            Thumb = stick;

            IndexFinger = trigger;

            HandGrip = trigger;
        }
    }
}
