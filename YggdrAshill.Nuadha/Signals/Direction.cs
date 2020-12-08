using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha.Signals
{
    public struct Direction :
        ISignal,
        IEquatable<Direction>
    {
        public static Direction Right { get; } = new Direction(1.0f, 0.0f, 0.0f);
        public static Direction Left { get; } = new Direction(-1.0f, 0.0f, 0.0f);
        public static Direction Up { get; } = new Direction(0.0f, 1.0f, 0.0f);
        public static Direction Down { get; } = new Direction(0.0f, -1.0f, 0.0f);
        public static Direction Forward { get; } = new Direction(0.0f, 0.0f, 1.0f);
        public static Direction Backward { get; } = new Direction(0.0f, 0.0f, -1.0f);

        public float Horizontal { get; }

        public float Vertical { get; }

        public float Frontal { get; }

        public Direction(float horizontal, float vertical, float frontal)
        {
            if (float.IsNaN(horizontal))
            {
                throw new ArgumentException($"{nameof(horizontal)} is NaN.");
            }
            if (float.IsNaN(vertical))
            {
                throw new ArgumentException($"{nameof(vertical)} is NaN.");
            }
            if (float.IsNaN(frontal))
            {
                throw new ArgumentException($"{nameof(frontal)} is NaN.");
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
            if (frontal < Min || Max < frontal)
            {
                throw new ArgumentOutOfRangeException(nameof(frontal));
            }

            Horizontal = horizontal;

            Vertical = vertical;

            Frontal = frontal;
        }

        public Direction Inversed
            => new Direction(-Horizontal, -Vertical, -Frontal);

        public override string ToString()
        {
            return $"{Horizontal}, {Vertical}, {Frontal}";
        }

        #region IEquatable as value object

        public bool Equals(Direction other)
        {
            return Horizontal.Equals(other.Horizontal)
                && Vertical.Equals(other.Vertical)
                && Frontal.Equals(other.Frontal);
        }

        #endregion
    }
}
