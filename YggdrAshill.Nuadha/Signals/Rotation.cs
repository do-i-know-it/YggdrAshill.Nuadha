using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha.Signals
{
    public struct Rotation :
        ISignal,
        IEquatable<Rotation>
    {
        public static Rotation None { get; } = new Rotation(0.0f, 0.0f, 0.0f, 1.0f);

        public float Horizontal { get; }

        public float Vertical { get; }

        public float Frontal { get; }

        public float Angle { get; }

        public Rotation(float horizontal, float vertical, float frontal, float angle)
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
            if (angle < Min || Max < angle)
            {
                throw new ArgumentOutOfRangeException(nameof(angle));
            }

            Horizontal = horizontal;

            Vertical = vertical;

            Frontal = frontal;

            Angle = angle;
        }

        public Rotation Inversed
            => new Rotation(-Horizontal, -Vertical, -Frontal, Angle);

        public override string ToString()
        {
            return $"{Horizontal}, {Vertical}, {Frontal}, {Angle}";
        }

        #region IEquatable as value object

        public bool Equals(Rotation other)
        {
            return Angle.Equals(other.Angle)
                && Horizontal.Equals(other.Horizontal)
                && Vertical.Equals(other.Vertical)
                && Frontal.Equals(other.Frontal);
        }

        #endregion
    }
}
