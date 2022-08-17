using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha.Signals
{
    /// <summary>
    /// Implementation of <see cref="ISignal"/> for tilt.
    /// </summary>
    public struct Tilt :
        ISignal,
        IEquatable<Tilt>
    {
        /// <summary>
        /// <see cref="float"/> of difference of <see cref="Tilt"/>.
        /// </summary>
        public static float Tolerance { get; } = 1e-5f;

        /// <summary>
        /// <see cref="float"/> for length of <see cref="Tilt"/>.
        /// </summary>
        public const float Length = 1.0f;

        /// <summary>
        /// Minimum <see cref="float"/> for <see cref="Horizontal"/> and <see cref="Vertical"/>.
        /// </summary>
        public const float Minimum = -Length;

        /// <summary>
        /// Maximum <see cref="float"/> for <see cref="Horizontal"/> and <see cref="Vertical"/>.
        /// </summary>
        public const float Maximum = Length;

        /// <summary>
        /// Origin of <see cref="Tilt"/>.
        /// </summary>
        public static Tilt Origin { get; } = new Tilt(0.0f, 0.0f);

        /// <summary>
        /// Right of <see cref="Tilt"/>.
        /// </summary>
        public static Tilt Right { get; } = new Tilt(Maximum, 0.0f);

        /// <summary>
        /// Left of <see cref="Tilt"/>.
        /// </summary>
        public static Tilt Left { get; } = new Tilt(Minimum, 0.0f);

        /// <summary>
        /// Forward of <see cref="Tilt"/>.
        /// </summary>
        public static Tilt Forward { get; } = new Tilt(0.0f, Maximum);

        /// <summary>
        /// Backward of <see cref="Tilt"/>.
        /// </summary>
        public static Tilt Backward { get; } = new Tilt(0.0f, Minimum);

        /// <summary>
        /// <see cref="float"/> for horizontal of <see cref="Tilt"/>.
        /// </summary>
        public float Horizontal { get; }

        /// <summary>
        /// <see cref="float"/> for vertical of <see cref="Tilt"/>.
        /// </summary>
        public float Vertical { get; }

        /// <summary>
        /// <see cref="float"/> for distance of <see cref="Tilt"/>.
        /// </summary>
        public float Distance
        {
            get
            {
                var dotted
                    = Horizontal * Horizontal
                    + Vertical * Vertical;

                return (float)Math.Sqrt(dotted);
            }
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="horizontal">
        /// <see cref="float"/> for <see cref="Horizontal"/>.
        /// </param>
        /// <param name="vertical">
        /// <see cref="float"/> for <see cref="Vertical"/>.
        /// </param>
        /// <exception cref="ArgumentException">
        /// Thrown if <paramref name="horizontal"/> is <see cref="float.NaN"/>.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown if <paramref name="vertical"/> is <see cref="float.NaN"/>.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown if <paramref name="horizontal"/> is out of range between <see cref="Minimum"/> and <see cref="Maximum"/>.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown if <paramref name="vertical"/> is out of range between <see cref="Minimum"/> and <see cref="Maximum"/>.
        /// </exception>
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

            if (horizontal < Minimum || Maximum < horizontal)
            {
                throw new ArgumentOutOfRangeException(nameof(horizontal));
            }
            if (vertical < Minimum || Maximum < vertical)
            {
                throw new ArgumentOutOfRangeException(nameof(vertical));
            }

            Horizontal = horizontal;

            Vertical = vertical;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"{Horizontal}, {Vertical}";
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            // Visual Studio auto generated.
            var hashCode = 1238135884;
            hashCode = hashCode * -1521134295 + Horizontal.GetHashCode();
            hashCode = hashCode * -1521134295 + Vertical.GetHashCode();
            return hashCode;
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj is Tilt signal)
            {
                return Equals(signal);
            }

            return false;
        }

        /// <inheritdoc/>
        public bool Equals(Tilt other)
        {
            return Horizontal.Equals(other.Horizontal)
                && Vertical.Equals(other.Vertical);
        }

        /// <summary>
        /// Inverses <see cref="Tilt"/>.
        /// </summary>
        /// <param name="signal">
        /// <see cref="Tilt"/> to inverse.
        /// </param>
        /// <returns>
        /// <see cref="Tilt"/> inversed.
        /// </returns>
        public static Tilt operator -(Tilt signal)
        {
            var horizontal = -signal.Horizontal;

            var vertical = -signal.Vertical;

            return new Tilt(horizontal, vertical);
        }

        /// <summary>
        /// Checks if <paramref name="left"/> and <paramref name="right"/> are equal.
        /// </summary>
        /// <param name="left">
        /// <see cref="Tilt"/> to check.
        /// </param>
        /// <param name="right">
        /// <see cref="Tilt"/> to check.
        /// </param>
        /// <returns>
        /// True if <paramref name="left"/> and <paramref name="right"/> are equal.
        /// </returns>
        public static bool operator ==(Tilt left, Tilt right)
        {
            if (left.Equals(right))
            {
                return true;
            }

            var horizontalDifference = left.Horizontal - right.Horizontal;

            var verticalDifference = left.Vertical - right.Vertical;

            var dotted
                = horizontalDifference * horizontalDifference
                + verticalDifference * verticalDifference;

            return dotted <= Tolerance;
        }

        /// <summary>
        /// Checks if <paramref name="left"/> and <paramref name="right"/> are not equal.
        /// </summary>
        /// <param name="left">
        /// <see cref="Tilt"/> to check.
        /// </param>
        /// <param name="right">
        /// <see cref="Tilt"/> to check.
        /// </param>
        /// <returns>
        /// True if <paramref name="left"/> and <paramref name="right"/> are not equal.
        /// </returns>
        public static bool operator !=(Tilt left, Tilt right)
        {
            return !(left == right);
        }
    }
}
