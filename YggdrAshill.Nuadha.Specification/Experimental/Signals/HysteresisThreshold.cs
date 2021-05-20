using System;

namespace YggdrAshill.Nuadha.Signals.Experimental
{
    public sealed class HysteresisThreshold
    {
        public static float Minimum { get; } = 0.0f;

        public static float Maximum { get; } = 1.0f;

        public float Lower { get; }

        public float Upper { get; }

        public HysteresisThreshold(float lower, float upper)
        {
            if (float.IsNaN(upper))
            {
                throw new ArgumentException($"{nameof(upper)} is NaN.");
            }
            if (float.IsNaN(lower))
            {
                throw new ArgumentException($"{nameof(lower)} is NaN.");
            }

            if (lower < Minimum || Maximum < lower)
            {
                throw new ArgumentOutOfRangeException(nameof(lower));
            }
            if (upper < Minimum || Maximum < upper)
            {
                throw new ArgumentOutOfRangeException(nameof(upper));
            }
            if (upper < lower)
            {
                throw new ArgumentException($"{nameof(upper)} < {nameof(lower)}");
            }

            Lower = lower;

            Upper = upper;
        }

        public HysteresisThreshold(float threshold = 0.5f) : this(threshold, threshold)
        {

        }
    }
}
