using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha.Signals
{
    public struct Pull :
        ISignal
    {
        public float Strength { get; }

        public Pull(float strength)
        {
            if (float.IsNaN(strength))
            {
                throw new ArgumentException($"{nameof(strength)} is NaN.");
            }

            const float Min = 0.0f;
            const float Max = 1.0f;
            if (strength < Min || Max < strength)
            {
                throw new ArgumentOutOfRangeException(nameof(strength));
            }

            Strength = strength;
        }
    }
}
