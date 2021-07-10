using YggdrAshill.Nuadha.Transformation;
using System;

namespace YggdrAshill.Nuadha.Signals
{
    public static class PullInto
    {
        public static IConversion<Pull, Push> Push(HysteresisThreshold threshold)
        {
            if (threshold == null)
            {
                throw new ArgumentNullException(nameof(threshold));
            }

            return new Conversion(threshold);
        }
        private sealed class Conversion :
            IConversion<Pull, Push>
        {
            private readonly HysteresisThreshold threshold;

            private bool previous = false;

            internal Conversion(HysteresisThreshold threshold)
            {
                if (threshold == null)
                {
                    throw new ArgumentNullException(nameof(threshold));
                }

                this.threshold = threshold;
            }

            /// <inheritdoc/>
            public Push Convert(Pull signal)
            {
                if (previous)
                {
                    previous = threshold.Lower <= (float)signal;
                }
                else
                {
                    previous = threshold.Upper <= (float)signal;
                }

                return previous.ToPush();
            }
        }

        public static IPulsation<Pull> Pulse(HysteresisThreshold threshold)
        {
            if (threshold == null)
            {
                throw new ArgumentNullException(nameof(threshold));
            }

            return new Pulsation(Push(threshold));
        }
        private sealed class Pulsation :
            IPulsation<Pull>
        {
            private readonly IConversion<Pull, Push> conversion;

            private readonly IPulsation<Push> pulsation;

            internal Pulsation(IConversion<Pull, Push> conversion)
            {
                this.conversion = conversion;

                pulsation = PushInto.Pulse;
            }

            public Pulse Pulsate(Pull signal)
            {
                var converted = conversion.Convert(signal);

                return pulsation.Pulsate(converted);
            }
        }
    }
}
