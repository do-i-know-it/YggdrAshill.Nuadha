using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha.Signals
{
    /// <summary>
    /// Implementation of <see cref="ISignal"/> for <see cref="Tilt"/>.
    /// </summary>
    public struct Tilt :
        ISignal,
        IEquatable<Tilt>
    {
        /// <summary>
        /// Maximum of <see cref="Length"/> for <see cref="Tilt"/>.
        /// </summary>
        public const float Length = 1.0f;

        /// <summary>
        /// <see cref="Minimum"/> of <see cref="Horizontal"/> and <see cref="Vertical"/>.
        /// </summary>
        public const float Minimum = -Length;

        /// <summary>
        /// <see cref="Maximum"/> of <see cref="Horizontal"/> and <see cref="Vertical"/>.
        /// </summary>
        public const float Maximum = Length;

        /// <summary>
        /// <see cref="Origin"/> of the coordinate.
        /// </summary>
        public static Tilt Origin { get; } = new Tilt(0.0f, 0.0f);

        /// <summary>
        /// <see cref="Right"/> in the coordinate.
        /// </summary>
        public static Tilt Right { get; } = new Tilt(1.0f, 0.0f);

        /// <summary>
        /// <see cref="Left"/> in the coordinate.
        /// </summary>
        public static Tilt Left { get; } = new Tilt(-1.0f, 0.0f);

        /// <summary>
        /// <see cref="Upward"/> in the coordinate.
        /// </summary>
        public static Tilt Upward { get; } = new Tilt(0.0f, 1.0f);

        /// <summary>
        /// <see cref="Downward"/> in the coordinate.
        /// </summary>
        public static Tilt Downward { get; } = new Tilt(0.0f, -1.0f);

        /// <summary>
        /// <see cref="Horizontal"/> of the coordinate.
        /// </summary>
        public float Horizontal { get; }

        /// <summary>
        /// <see cref="Vertical"/> of the coordinate.
        /// </summary>
        public float Vertical { get; }

        private float distance;
        /// <summary>
        /// <see cref="Distance"/> of <see cref="Tilt"/>.
        /// </summary>
        public float Distance
        {
            get
            {
                InitializeIfNeeded();

                return distance;
            }
        }

        private bool initialized;
        private void InitializeIfNeeded()
        {
            if (initialized)
            {
                return;
            }

            var dotted
                = Horizontal * Horizontal
                + Vertical * Vertical;

            distance = (float)Math.Sqrt(dotted);

            initialized = true;
        }

        /// <summary>
        /// <see cref="Reversed"/> <see cref="Tilt"/>.
        /// </summary>
        [Obsolete("Please use \"operator -\" instead of this.")]
        public Tilt Reversed
            => -this;

        /// <summary>
        /// Constructs instance.
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
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown if <see cref="Distance"/> is out of <see cref="Length"/>.
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

            var dotted
                = horizontal * horizontal
                + vertical * vertical;
            if (dotted > Length)
            {
                throw new ArgumentOutOfRangeException($"{nameof(Distance)}");
            }

            Horizontal = horizontal;

            Vertical = vertical;

            distance = (float)Math.Sqrt(dotted);

            initialized = true;
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
        /// Checks if <see cref="Tilt"/> and <see cref="Tilt"/> are equal.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(Tilt left, Tilt right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Checks if <see cref="Tilt"/> and <see cref="Tilt"/> are not equal.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(Tilt left, Tilt right)
        {
            return !(left == right);
        }
    }
}
