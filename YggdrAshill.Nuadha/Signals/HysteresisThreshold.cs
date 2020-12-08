using System;

namespace YggdrAshill.Nuadha
{
    public struct HysteresisThreshold
    {
        public float UpperLimit { get; }

        public float LowerLimit { get; }

        public HysteresisThreshold(float upperLimit, float lowerLimit)
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
            if (upperLimit < Min || Max < upperLimit)
            {
                throw new ArgumentOutOfRangeException(nameof(upperLimit));
            }
            if (lowerLimit < Min || Max < lowerLimit)
            {
                throw new ArgumentOutOfRangeException(nameof(lowerLimit));
            }
            if (upperLimit < lowerLimit)
            {
                throw new ArgumentException($"{nameof(upperLimit)} < {nameof(lowerLimit)}");
            }

            UpperLimit = upperLimit;

            LowerLimit = lowerLimit;
        }
    }
}
