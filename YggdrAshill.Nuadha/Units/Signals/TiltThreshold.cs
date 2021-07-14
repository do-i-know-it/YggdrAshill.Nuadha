using YggdrAshill.Nuadha.Signals;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class TiltThreshold
    {
        public HysteresisThreshold Distance { get; }

        public HysteresisThreshold Left { get; }

        public HysteresisThreshold Right { get; }

        public HysteresisThreshold Forward { get; }

        public HysteresisThreshold Backward { get; }

        public TiltThreshold(
            HysteresisThreshold distance,
            HysteresisThreshold left, HysteresisThreshold right,
            HysteresisThreshold forward, HysteresisThreshold backward)
        {
            if (distance == null)
            {
                throw new ArgumentNullException(nameof(distance));
            }
            if (left == null)
            {
                throw new ArgumentNullException(nameof(left));
            }
            if (right == null)
            {
                throw new ArgumentNullException(nameof(right));
            }
            if (forward == null)
            {
                throw new ArgumentNullException(nameof(forward));
            }
            if (backward == null)
            {
                throw new ArgumentNullException(nameof(backward));
            }

            Distance = distance;
            Left = left;
            Right = right;
            Forward = forward;
            Backward = backward;
        }

        public TiltThreshold(HysteresisThreshold threshold)
        {
            if (threshold == null)
            {
                throw new ArgumentNullException(nameof(threshold));
            }

            Distance = threshold;
            Left = threshold;
            Right = threshold;
            Forward = threshold;
            Backward = threshold;
        }
    }
}
