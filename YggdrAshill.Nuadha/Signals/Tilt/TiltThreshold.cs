using YggdrAshill.Nuadha.Signals;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class TiltThreshold :
        ITiltThreshold
    {
        public IHysteresisThreshold Left { get; }

        public IHysteresisThreshold Right { get; }

        public IHysteresisThreshold Forward { get; }

        public IHysteresisThreshold Backward { get; }

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
