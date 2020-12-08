using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha.Signals
{
    public struct Tilt :
        ISignal,
        IEquatable<Tilt>
    {
        public static Tilt Origin { get; } = new Tilt(0.0f, 0.0f);
        public static Tilt Right { get; } = new Tilt(1.0f, 0.0f);
        public static Tilt Left { get; } = new Tilt(-1.0f, 0.0f);
        public static Tilt Up { get; } = new Tilt(0.0f, 1.0f);
        public static Tilt Down { get; } = new Tilt(0.0f, -1.0f);

        public float Horizontal { get; }

        public float Vertical { get; }

        public Tilt(float horizontal, float vertical)
        {
            if (float.IsNaN(horizontal))
            {
                throw new ArgumentException($"{nameof(horizontal)} is NaN.");
            }
            if (float.IsNaN(vertical))
            {
                throw new ArgumentException($"{nameof(vertical)} is NaN.");
            }

            const float Min = -1.0f;
            const float Max = 1.0f;
            if (horizontal < Min || Max < horizontal)
            {
                throw new ArgumentOutOfRangeException(nameof(horizontal));
            }
            if (vertical < Min || Max < vertical)
            {
                throw new ArgumentOutOfRangeException(nameof(vertical));
            }

            Horizontal = horizontal;

            Vertical = vertical;
        }

        public Tilt Inversed
            => new Tilt(-Horizontal, -Vertical);

        public bool Equals(Tilt other)
        {
            return Horizontal.Equals(other.Horizontal)
                && Vertical.Equals(other.Vertical);
        }

        public override string ToString()
        {
            return $"{Horizontal}, {Vertical}";
        }
    }
}
