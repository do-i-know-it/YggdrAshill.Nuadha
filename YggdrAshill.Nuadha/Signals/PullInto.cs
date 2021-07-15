using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Signals;
using System;

namespace YggdrAshill.Nuadha
{
    public static class PullInto
    {
        public static IConversion<Pull, Push> Push(HysteresisThreshold threshold)
        {
            if (threshold == null)
            {
                throw new ArgumentNullException(nameof(threshold));
            }

            var detection = new Detection(threshold);
            return SignalInto.Signal<Pull, Push>(signal => detection.Detect(signal).ToPush());
        }
        private sealed class Detection :
            IDetection<Pull>
        {
            private readonly HysteresisThreshold threshold;

            private bool previous = false;

            internal Detection(HysteresisThreshold threshold)
            {
                this.threshold = threshold;
            }

            public bool Detect(Pull signal)
            {
                if (previous)
                {
                    return previous = threshold.Lower <= (float)signal;
                }
                else
                {
                    return previous = threshold.Upper <= (float)signal;
                }
            }
        }
       
        public static IConversion<Pull, Pulse> Pulse(HysteresisThreshold threshold)
        {
            if (threshold == null)
            {
                throw new ArgumentNullException(nameof(threshold));
            }

            return Push(threshold).Then(PushInto.Pulse);
        }
    }
}
