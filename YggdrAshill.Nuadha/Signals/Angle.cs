using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha.Signals
{
    public struct Angle :
        ISignal,
        IEquatable<Angle>
    {
        public float Degree { get; }

        public Angle(float degree)
        {
            if (float.IsNaN(degree))
            {
                throw new ArgumentException($"{nameof(degree)} is NaN.");
            }

            const float Min = -180.0f;
            const float Max = 180.0f;
            if (degree < Min || Max < degree)
            {
                throw new ArgumentOutOfRangeException(nameof(degree));
            }

            Degree = degree;
        }

        public bool Equals(Angle other)
        {
            return Degree.Equals(other.Degree);
        }
    }
}
