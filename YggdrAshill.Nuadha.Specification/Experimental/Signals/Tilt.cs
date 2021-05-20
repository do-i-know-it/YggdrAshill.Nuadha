using YggdrAshill.Nuadha.Signalization.Experimental;
using System;

namespace YggdrAshill.Nuadha.Signals.Experimental
{
    /// <summary>
    /// Implementation of <see cref="ISignal"/> to describe tilt.
    /// </summary>
    public struct Tilt :
        ISignal,
        IEquatable<Tilt>
    {
        private const float Tolerance = float.Epsilon;
        private const float Length = 1.0f;

        /// <summary>
        /// Origin of the coordinate.
        /// </summary>
        public static Tilt Origin { get; } = new Tilt(0.0f, 0.0f);

        /// <summary>
        /// Right side in the coordinate.
        /// </summary>
        public static Tilt Right { get; } = new Tilt(1.0f, 0.0f);

        /// <summary>
        /// Left side in the coordinate.
        /// </summary>
        public static Tilt Left { get; } = new Tilt(-1.0f, 0.0f);

        /// <summary>
        /// Front side in the coordinate.
        /// </summary>
        public static Tilt Upward { get; } = new Tilt(0.0f, 1.0f);

        /// <summary>
        /// Back side in the coordinate.
        /// </summary>
        public static Tilt Downward { get; } = new Tilt(0.0f, -1.0f);

        /// <summary>
        /// Value for horizontal of the coordinate.
        /// </summary>
        public float Horizontal { get; }

        /// <summary>
        /// Value for vertical of the coordinate.
        /// </summary>
        public float Vertical { get; }

        private float distance;
        /// <summary>
        /// Distance of <see cref="Tilt"/>.
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

            distance = MathF.Sqrt(dotted);

            initialized = true;
        }

        /// <summary>
        /// Reversed <see cref="Tilt"/>.
        /// </summary>
        public Tilt Reversed
            => new Tilt(-Horizontal, -Vertical);

        /// <summary>
        /// Constructs an instance.
        /// </summary>
        /// <param name="horizontal"></param>
        /// <param name="vertical"></param>
        /// <exception cref="ArgumentException">
        /// Thrown if <paramref name="horizontal"/> is <see cref="float.NaN"/>.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown if <paramref name="vertical"/> is <see cref="float.NaN"/>.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown if <paramref name="horizontal"/> is not between -1 to 1.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown if <paramref name="vertical"/> is not between -1 to 1.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown if <paramref name="horizontal"/>^2 + <paramref name="vertical"/>^2 is larger than 1.
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

            if (horizontal < -Length || Length < horizontal)
            {
                throw new ArgumentOutOfRangeException(nameof(horizontal));
            }
            if (vertical < -Length || Length < vertical)
            {
                throw new ArgumentOutOfRangeException(nameof(vertical));
            }

            var dotted
                = horizontal * horizontal
                + vertical * vertical;
            if (dotted > Length)
            {
                throw new ArgumentOutOfRangeException($"{nameof(horizontal)}^2 + {nameof(horizontal)}^2");
            }

            Horizontal = horizontal;

            Vertical = vertical;

            initialized = false;

            distance = 0f;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"{Horizontal}, {Vertical}";
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            // todo
            return base.GetHashCode();
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
        /// Checks if <see cref="Tilt"/> and <see cref="Tilt"/> are equal.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(Tilt left, Tilt right)
        {
            if (left.Equals(right))
            {
                return true;
            }

            var horizontal = left.Horizontal - right.Horizontal;
            var vertical = left.Vertical - right.Vertical;

            return new Tilt(horizontal, vertical).Distance < Tolerance;
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
