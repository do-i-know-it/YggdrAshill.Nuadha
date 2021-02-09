using System;

namespace YggdrAshill.Nuadha.Signals
{
    public sealed class HysteresisThreshold
    {
        public float LowerLimit { get; }

        public float UpperLimit { get; }

        public HysteresisThreshold(float lowerLimit, float upperLimit)
        {
            if (float.IsNaN(upperLimit))
            {
                throw new ArgumentException($"{nameof(upperLimit)} is NaN.");
            }
            if (float.IsNaN(lowerLimit))
            {
                throw new ArgumentException($"{nameof(lowerLimit)} is NaN.");
            }

            const float Min = 0.0f;
            const float Max = 1.0f;
            if (lowerLimit < Min || Max < lowerLimit)
            {
                throw new ArgumentOutOfRangeException(nameof(lowerLimit));
            }
            if (upperLimit < Min || Max < upperLimit)
            {
                throw new ArgumentOutOfRangeException(nameof(upperLimit));
            }
            if (upperLimit < lowerLimit)
            {
                throw new ArgumentException($"{nameof(upperLimit)} < {nameof(lowerLimit)}");
            }

            LowerLimit = lowerLimit;

            UpperLimit = upperLimit;
        }
    }
}
