using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha.Signals
{
    public struct Blink :
        ISignal,
        IEquatable<Blink>
    {
        public float Ratio { get; }

        public Blink(float ratio)
        {
            if (float.IsNaN(ratio))
            {
                throw new ArgumentException($"{nameof(ratio)} is NaN.");
            }

            const float Min = 0.0f;
            const float Max = 1.0f;
            if (ratio < Min || Max < ratio)
            {
                throw new ArgumentOutOfRangeException(nameof(ratio));
            }

            Ratio = ratio;
        }

        public bool Equals(Blink other)
        {
            return Ratio.Equals(other.Ratio);
        }
    }
}
