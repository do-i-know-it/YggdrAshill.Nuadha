using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha.Signals
{
    public struct Position :
        ISignal,
        IEquatable<Position>
    {
        public static Position Origin { get; } = new Position(0.0f, 0.0f, 0.0f);
        public static Position Right { get; } = new Position(1.0f, 0.0f, 0.0f);
        public static Position Left { get; } = new Position(-1.0f, 0.0f, 0.0f);
        public static Position Up { get; } = new Position(0.0f, 1.0f, 0.0f);
        public static Position Down { get; } = new Position(0.0f, -1.0f, 0.0f);
        public static Position Forward { get; } = new Position(0.0f, 0.0f, 1.0f);
        public static Position Backward { get; } = new Position(0.0f, 0.0f, -1.0f);

        public float Horizontal { get; }

        public float Vertical { get; }

        public float Frontal { get; }

        public Position(float horizontal, float vertical, float frontal)
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

            Horizontal = horizontal;

            Vertical = vertical;

            Frontal = frontal;
        }

        public Position Inversed
            => new Position(-Horizontal, -Vertical, -Frontal);

        public override string ToString()
        {
            return $"{Horizontal}, {Vertical}, {Frontal}";
        }

        #region IEquatable as value object

        public bool Equals(Position other)
        {
            return Horizontal.Equals(other.Horizontal)
                && Vertical.Equals(other.Vertical)
                && Frontal.Equals(other.Frontal);
        }

        #endregion
    }
}
