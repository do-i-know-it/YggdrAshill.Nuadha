using YggdrAshill.Nuadha.Signals;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class TiltThreshold :
        ITiltThreshold
    {
        public HysteresisThreshold Left { get; }

        public HysteresisThreshold Right { get; }

        public HysteresisThreshold Forward { get; }

        public HysteresisThreshold Backward { get; }

        public TiltThreshold(HysteresisThreshold threshold)
        {
            if (threshold == null)
            {
                throw new ArgumentNullException(nameof(threshold));
            }

            Left = threshold;

            Right = threshold;

            Forward = threshold;

            Backward = threshold;
        }
    }
}
