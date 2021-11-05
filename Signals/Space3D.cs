using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha.Signals
{
    /// <summary>
    /// Defines some types of <see cref="ISignal"/> for <see cref="Space3D"/>.
    /// </summary>
    public static class Space3D
    {
        private const float Tolerance = 1e-5f;

        private const float Length = 1.0f;

        #region Position

        /// <summary>
        /// Implementation of <see cref="ISignal"/> for <see cref="Position"/> of <see cref="Space3D"/>.
        /// </summary>
        public struct Position :
            ISignal,
            IEquatable<Position>
        {
            /// <summary>
            /// <see cref="Origin"/> of the coordinate.
            /// </summary>
            public static Position Origin { get; } = new Position(0.0f, 0.0f, 0.0f);

            /// <summary>
            /// <see cref="Right"/> in the coordinate.
            /// </summary>
            public static Position Right { get; } = new Position(1.0f, 0.0f, 0.0f);

            /// <summary>
            /// <see cref="Left"/> in the coordinate.
            /// </summary>
            public static Position Left { get; } = new Position(-1.0f, 0.0f, 0.0f);

            /// <summary>
            /// <see cref="Upward"/> in the coordinate.
            /// </summary>
            public static Position Upward { get; } = new Position(0.0f, 1.0f, 0.0f);

            /// <summary>
            /// <see cref="Downward"/> in the coordinate.
            /// </summary>
            public static Position Downward { get; } = new Position(0.0f, -1.0f, 0.0f);

            /// <summary>
            /// <see cref="Forward"/> in the coordinate.
            /// </summary>
            public static Position Forward { get; } = new Position(0.0f, 0.0f, 1.0f);

            /// <summary>
            /// <see cref="Backward"/> in the coordinate.
            /// </summary>
            public static Position Backward { get; } = new Position(0.0f, 0.0f, -1.0f);

            /// <summary>
            /// <see cref="Horizontal"/> of the coordinate.
            /// </summary>
            public float Horizontal { get; }

            /// <summary>
            /// <see cref="Vertical"/> of the coordinate.
            /// </summary>
            public float Vertical { get; }

            /// <summary>
            /// <see cref="Frontal"/> of the coordinate.
            /// </summary>
            public float Frontal { get; }

            private float distance;
            /// <summary>
            /// <see cref="Distance"/> of <see cref="Position"/>.
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
                    + Vertical * Vertical
                    + Frontal * Frontal;

                distance = (float)Math.Sqrt(dotted);

                initialized = true;
            }

            /// <summary>
            /// Constructs instance.
            /// </summary>
            /// <param name="horizontal">
            /// <see cref="float"/> for <see cref="Horizontal"/>.
            /// </param>
            /// <param name="vertical">
            /// <see cref="float"/> for <see cref="Vertical"/>.
            /// </param>
            /// <param name="frontal">
            /// <see cref="float"/> for <see cref="Frontal"/>.
            /// </param>
            /// <exception cref="ArgumentException">
            /// Thrown if <paramref name="horizontal"/> is <see cref="float.NaN"/>.
            /// </exception>
            /// <exception cref="ArgumentException">
            /// Thrown if <paramref name="vertical"/> is <see cref="float.NaN"/>.
            /// </exception>
            /// <exception cref="ArgumentException">
            /// Thrown if <paramref name="frontal"/> is <see cref="float.NaN"/>.
            /// </exception>
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

                initialized = false;

                distance = 0f;
            }

            /// <summary>
            /// <see cref="Direction"/> from <see cref="Position"/>.
            /// </summary>
            /// <param name="position"></param>
            /// <returns>
            /// <see cref="Direction"/> calculated.
            /// </returns>
            public Direction DirectionFrom(Position position)
            {
                if (this == position)
                {
                    return Direction.Forward;
                }

                var difference = this - position;

                var horizontal = difference.Horizontal / difference.Distance;

                var vertical = difference.Vertical / difference.Distance;

                var frontal = difference.Frontal / difference.Distance;

                return new Direction(horizontal, vertical, frontal);
            }

            /// <inheritdoc/>
            public override string ToString()
            {
                return $"{Horizontal}, {Vertical}, {Frontal}";
            }

            /// <inheritdoc/>
            public override int GetHashCode()
            {
                // Visual Studio auto generated.
                var hashCode = -55840831;
                hashCode = hashCode * -1521134295 + Horizontal.GetHashCode();
                hashCode = hashCode * -1521134295 + Vertical.GetHashCode();
                hashCode = hashCode * -1521134295 + Frontal.GetHashCode();
                return hashCode;
            }

            /// <inheritdoc/>
            public override bool Equals(object obj)
            {
                if (ReferenceEquals(this, obj))
                {
                    return true;
                }

                if (obj is Position signal)
                {
                    return Equals(signal);
                }

                return false;
            }

            /// <inheritdoc/>
            public bool Equals(Position other)
            {
                return Horizontal.Equals(other.Horizontal)
                    && Vertical.Equals(other.Vertical)
                    && Frontal.Equals(other.Frontal);
            }

            /// <summary>
            /// Inverses <see cref="Position"/>.
            /// </summary>
            /// <param name="signal">
            /// <see cref="Position"/> to inverse.
            /// </param>
            /// <returns>
            /// <see cref="Position"/> inversed.
            /// </returns>
            public static Position operator -(Position signal)
            {
                var horizontal = -signal.Horizontal;

                var vertical = -signal.Vertical;

                var frontal = -signal.Frontal;

                return new Position(horizontal, vertical, frontal);
            }

            /// <summary>
            /// Adds <see cref="Position"/> and <see cref="Position"/>.
            /// </summary>
            /// <param name="left"></param>
            /// <param name="right"></param>
            /// <returns>
            /// <see cref="Position"/> added.
            /// </returns>
            public static Position operator +(Position left, Position right)
            {
                var horizontal
                    = left.Horizontal
                    + right.Horizontal;

                var vertical
                    = left.Vertical
                    + right.Vertical;

                var frontal
                    = left.Frontal
                    + right.Frontal;

                return new Position(horizontal, vertical, frontal);
            }

            /// <summary>
            /// Subtracts <see cref="Position"/> and <see cref="Position"/>.
            /// </summary>
            /// <param name="left"></param>
            /// <param name="right"></param>
            /// <returns>
            /// <see cref="Position"/> subtracted.
            /// </returns>
            public static Position operator -(Position left, Position right)
            {
                return left + (-right);
            }

            /// <summary>
            /// Checks if <see cref="Position"/> and <see cref="Position"/> are equal.
            /// </summary>
            /// <param name="left"></param>
            /// <param name="right"></param>
            /// <returns></returns>
            public static bool operator ==(Position left, Position right)
            {
                return left.Equals(right);
            }

            /// <summary>
            /// Checks if <see cref="Position"/> and <see cref="Position"/> are not equal.
            /// </summary>
            /// <param name="left"></param>
            /// <param name="right"></param>
            /// <returns></returns>
            public static bool operator !=(Position left, Position right)
            {
                return !(left == right);
            }
        }

        #endregion

        #region Direction

        /// <summary>
        /// Implementation of <see cref="ISignal"/> for <see cref="Direction"/> of <see cref="Space3D"/>.
        /// </summary>
        public struct Direction :
            ISignal,
            IEquatable<Direction>
        {
            /// <summary>
            /// <see cref="Minimum"/> of <see cref="Horizontal"/> and <see cref="Vertical"/> and <see cref="Frontal"/>.
            /// </summary>
            public const float Minimum = -Length;

            /// <summary>
            /// <see cref="Maximum"/> of <see cref="Horizontal"/> and <see cref="Vertical"/> and <see cref="Frontal"/>.
            /// </summary>
            public const float Maximum = Length;

            /// <summary>
            /// <see cref="Tolerance"/> for <see cref="Direction"/>.
            /// </summary>
            public static float Tolerance { get; } = Space3D.Tolerance;

            /// <summary>
            /// <see cref="Right"/> in the coordinate.
            /// </summary>
            public static Direction Right { get; } = Position.Right.DirectionFrom(Position.Origin);

            /// <summary>
            /// <see cref="Left"/> in the coordinate.
            /// </summary>
            public static Direction Left { get; } = Position.Left.DirectionFrom(Position.Origin);

            /// <summary>
            /// <see cref="Upward"/> in the coordinate.
            /// </summary>
            public static Direction Upward { get; } = Position.Upward.DirectionFrom(Position.Origin);

            /// <summary>
            /// <see cref="Downward"/> in the coordinate.
            /// </summary>
            public static Direction Downward { get; } = Position.Downward.DirectionFrom(Position.Origin);

            /// <summary>
            /// <see cref="Forward"/> in the coordinate.
            /// </summary>
            public static Direction Forward { get; } = Position.Forward.DirectionFrom(Position.Origin);

            /// <summary>
            /// <see cref="Backward"/> in the coordinate.
            /// </summary>
            public static Direction Backward { get; } = Position.Backward.DirectionFrom(Position.Origin);

            private float horizontal;
            /// <summary>
            /// <see cref="Horizontal"/> of the coordinate.
            /// </summary>
            public float Horizontal
            {
                get
                {
                    InitializeIfNeeded();

                    return horizontal;
                }
            }

            private float vertical;
            /// <summary>
            /// <see cref="Vertical"/> of the coordinate.
            /// </summary>
            public float Vertical
            {
                get
                {
                    InitializeIfNeeded();

                    return vertical;
                }
            }

            private float frontal;
            /// <summary>
            /// <see cref="Frontal"/> of the coordinate.
            /// </summary>
            public float Frontal
            {
                get
                {
                    InitializeIfNeeded();

                    return frontal;
                }
            }

            private bool initialized;
            private void InitializeIfNeeded()
            {
                if (initialized)
                {
                    return;
                }

                horizontal = Forward.Horizontal;

                vertical = Forward.Vertical;

                frontal = Forward.Frontal;

                initialized = true;
            }

            /// <summary>
            /// Reversed <see cref="Direction"/>.
            /// </summary>
            [Obsolete("Please use \"operator -\" instead of this.")]
            public Direction Reversed
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
            /// <param name="frontal">
            /// <see cref="float"/> for <see cref="Frontal"/>.
            /// </param>
            /// <exception cref="ArgumentException">
            /// Thrown if <paramref name="horizontal"/> is <see cref="float.NaN"/>.
            /// </exception>
            /// <exception cref="ArgumentException">
            /// Thrown if <paramref name="vertical"/> is <see cref="float.NaN"/>.
            /// </exception>
            /// <exception cref="ArgumentException">
            /// Thrown if <paramref name="frontal"/> is <see cref="float.NaN"/>.
            /// </exception>
            /// <exception cref="ArgumentOutOfRangeException">
            /// Thrown if <paramref name="horizontal"/> is out of range between <see cref="Minimum"/> and <see cref="Maximum"/>.
            /// </exception>
            /// <exception cref="ArgumentOutOfRangeException">
            /// Thrown if <paramref name="vertical"/> is  out of range between <see cref="Minimum"/> and <see cref="Maximum"/>.
            /// </exception>
            /// <exception cref="ArgumentOutOfRangeException">
            /// Thrown if <paramref name="frontal"/> is out of range between <see cref="Minimum"/> and <see cref="Maximum"/>.
            /// </exception>
            /// <exception cref="ArgumentOutOfRangeException">
            /// Thrown if <paramref name="horizontal"/>^2 + <paramref name="vertical"/>^2 + <paramref name="frontal"/>^2 is larger than <see cref="Tolerance"/>.
            /// </exception>
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

                if (horizontal < Minimum || Maximum < horizontal)
                {
                    throw new ArgumentOutOfRangeException(nameof(horizontal));
                }
                if (vertical < Minimum || Maximum < vertical)
                {
                    throw new ArgumentOutOfRangeException(nameof(vertical));
                }
                if (frontal < Minimum || Maximum < frontal)
                {
                    throw new ArgumentOutOfRangeException(nameof(frontal));
                }

                var dotted
                    = horizontal * horizontal
                    + vertical * vertical
                    + frontal * frontal;
                var difference = Math.Abs(Length - dotted);

                if (difference > Tolerance)
                {
                    throw new ArgumentOutOfRangeException($"{nameof(horizontal)}^2 + {nameof(vertical)}^2 + {nameof(frontal)}^2 > {Tolerance}");
                }

                this.horizontal = horizontal;

                this.vertical = vertical;

                this.frontal = frontal;

                initialized = true;
            }

            /// <summary>
            /// <see cref="Rotation"/> from <see cref="Direction"/>.
            /// </summary>
            /// <param name="direction"></param>
            /// <returns>
            /// <see cref="Rotation"/> calculated.
            /// </returns>
            public Rotation RotationFrom(Direction direction)
            {
                var horizontal
                    = Vertical * direction.Frontal
                    - Frontal * direction.Vertical;

                var vertical
                    = Frontal * direction.Horizontal
                    - Horizontal * direction.Frontal;

                var frontal
                    = Horizontal * direction.Vertical
                    - Vertical * direction.Horizontal;

                var real
                    = Horizontal * direction.Horizontal
                    + Vertical * direction.Vertical
                    + Frontal * direction.Frontal;

                return new Rotation(horizontal, vertical, frontal, real);
            }

            /// <summary>
            /// <see cref="Rotation"/> of <see cref="Angle.Degree"/>.
            /// </summary>
            /// <param name="degree"></param>
            /// <returns>
            /// <see cref="Rotation"/> calculated.
            /// </returns>
            public Rotation RotationOf(Angle.Degree degree)
            {
                return RotationOf((Angle.Radian)degree);
            }

            /// <summary>
            /// <see cref="Rotation"/> of <see cref="Angle.Radian"/>.
            /// </summary>
            /// <param name="radian"></param>
            /// <returns>
            /// <see cref="Rotation"/> calculated.
            /// </returns>
            public Rotation RotationOf(Angle.Radian radian)
            {
                var cosine = (float)Math.Cos((float)radian);
                var sine = (float)Math.Sin((float)radian);

                var real = cosine;
                var horizontal = Horizontal * sine;
                var vertical = Vertical * sine;
                var frontal = Frontal * sine;

                return new Rotation(horizontal, vertical, frontal, real);
            }

            /// <inheritdoc/>
            public override string ToString()
            {
                return $"{Horizontal}, {Vertical}, {Frontal}";
            }

            /// <inheritdoc/>
            public override int GetHashCode()
            {
                // Visual Studio auto generated.
                var hashCode = -55840831;
                hashCode = hashCode * -1521134295 + Horizontal.GetHashCode();
                hashCode = hashCode * -1521134295 + Vertical.GetHashCode();
                hashCode = hashCode * -1521134295 + Frontal.GetHashCode();
                return hashCode;
            }

            /// <inheritdoc/>
            public override bool Equals(object obj)
            {
                if (ReferenceEquals(this, obj))
                {
                    return true;
                }

                if (obj is Direction signal)
                {
                    return Equals(signal);
                }

                return false;
            }

            /// <inheritdoc/>
            public bool Equals(Direction other)
            {
                return Horizontal.Equals(other.Horizontal)
                    && Vertical.Equals(other.Vertical)
                    && Frontal.Equals(other.Frontal);
            }

            /// <summary>
            /// Inverses <see cref="Direction"/>.
            /// </summary>
            /// <param name="signal">
            /// <see cref="Direction"/> to inverse.
            /// </param>
            /// <returns>
            /// <see cref="Direction"/> inversed.
            /// </returns>
            public static Direction operator -(Direction signal)
            {
                var horizontal = -signal.Horizontal;

                var vertical = -signal.Vertical;

                var frontal = -signal.Frontal;

                return new Direction(horizontal, vertical, frontal);
            }


            /// <summary>
            /// Checks if <see cref="Direction"/> and <see cref="Direction"/> are equal.
            /// </summary>
            /// <param name="left"></param>
            /// <param name="right"></param>
            /// <returns></returns>
            public static bool operator ==(Direction left, Direction right)
            {
                return left.Equals(right);
            }

            /// <summary>
            /// Checks if <see cref="Direction"/> and <see cref="Direction"/> are not equal.
            /// </summary>
            /// <param name="left"></param>
            /// <param name="right"></param>
            /// <returns></returns>
            public static bool operator !=(Direction left, Direction right)
            {
                return !(left == right);
            }
        }

        #endregion

        #region Rotation

        /// <summary>
        /// Implementation of <see cref="ISignal"/> for <see cref="Rotation"/> of <see cref="Space3D"/>.
        /// </summary>
        public struct Rotation :
            ISignal,
            IEquatable<Rotation>
        {
            /// <summary>
            /// <see cref="Minimum"/> of <see cref="Horizontal"/> and <see cref="Vertical"/> and <see cref="Frontal"/> and <see cref="Real"/>.
            /// </summary>
            public const float Minimum = -Length;

            /// <summary>
            /// <see cref="Maximum"/> of <see cref="Horizontal"/> and <see cref="Vertical"/> and <see cref="Frontal"/> and <see cref="Real"/>.
            /// </summary>
            public const float Maximum = Length;

            /// <summary>
            /// <see cref="Tolerance"/> for <see cref="Rotation"/>.
            /// </summary>
            public static float Tolerance { get; } = Space3D.Tolerance;

            /// <summary>
            /// <see cref="Rotation"/> not rotated.
            /// </summary>
            public static Rotation None { get; } = new Rotation(0.0f, 0.0f, 0.0f, 1.0f);

            private float horizontal;
            /// <summary>
            /// <see cref="Horizontal"/> of the coordinate.
            /// </summary>
            public float Horizontal
            {
                get
                {
                    InitializeIfNeeded();

                    return horizontal;
                }
            }

            private float vertical;
            /// <summary>
            /// <see cref="Vertical"/> of the coordinate.
            /// </summary>
            public float Vertical
            {
                get
                {
                    InitializeIfNeeded();

                    return vertical;
                }
            }

            private float frontal;
            /// <summary>
            /// <see cref="Frontal"/> of the coordinate.
            /// </summary>
            public float Frontal
            {
                get
                {
                    InitializeIfNeeded();

                    return frontal;
                }
            }

            private float real;
            /// <summary>
            /// <see cref="Real"/> of the coordinate.
            /// </summary>
            public float Real
            {
                get
                {
                    InitializeIfNeeded();

                    return real;
                }
            }

            private bool initialized;
            private void InitializeIfNeeded()
            {
                if (initialized)
                {
                    return;
                }

                horizontal = None.Horizontal;

                vertical = None.Vertical;

                frontal = None.Frontal;

                real = None.Real;

                initialized = true;
            }

            /// <summary>
            /// Constructs instance.
            /// </summary>
            /// <param name="horizontal">
            /// <see cref="float"/> for <see cref="Rotation"/>.
            /// </param>
            /// <param name="vertical">
            /// <see cref="float"/> for <see cref="Rotation"/>.
            /// </param>
            /// <param name="frontal">
            /// <see cref="float"/> for <see cref="Rotation"/>.
            /// </param>
            /// <param name="real">
            /// <see cref="float"/> for <see cref="Rotation"/>.
            /// </param>
            /// <exception cref="ArgumentException">
            /// Thrown if <paramref name="horizontal"/> is <see cref="float.NaN"/>.
            /// </exception>
            /// <exception cref="ArgumentException">
            /// Thrown if <paramref name="vertical"/> is <see cref="float.NaN"/>.
            /// </exception>
            /// <exception cref="ArgumentException">
            /// Thrown if <paramref name="frontal"/> is <see cref="float.NaN"/>.
            /// </exception>
            /// <exception cref="ArgumentException">
            /// Thrown if <paramref name="real"/> is <see cref="float.NaN"/>.
            /// </exception>
            /// <exception cref="ArgumentOutOfRangeException">
            /// Thrown if <paramref name="horizontal"/> is out of range between <see cref="Minimum"/> and <see cref="Maximum"/>.
            /// </exception>
            /// <exception cref="ArgumentOutOfRangeException">
            /// Thrown if <paramref name="vertical"/> is  out of range between <see cref="Minimum"/> and <see cref="Maximum"/>.
            /// </exception>
            /// <exception cref="ArgumentOutOfRangeException">
            /// Thrown if <paramref name="frontal"/> is out of range between <see cref="Minimum"/> and <see cref="Maximum"/>.
            /// </exception>
            /// <exception cref="ArgumentOutOfRangeException">
            /// Thrown if <paramref name="real"/> is out of range between <see cref="Minimum"/> and <see cref="Maximum"/>.
            /// </exception>
            /// <exception cref="ArgumentOutOfRangeException">
            /// Thrown if <paramref name="horizontal"/>^2 + <paramref name="vertical"/>^2 + <paramref name="frontal"/>^2 + <paramref name="real"/>^2 is larger than <see cref="Tolerance"/>.
            /// </exception>
            public Rotation(float horizontal, float vertical, float frontal, float real)
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
                if (float.IsNaN(real))
                {
                    throw new ArgumentException($"{nameof(real)} is NaN.");
                }

                if (horizontal < Minimum || Maximum < horizontal)
                {
                    throw new ArgumentOutOfRangeException(nameof(horizontal));
                }
                if (vertical < Minimum || Maximum < vertical)
                {
                    throw new ArgumentOutOfRangeException(nameof(vertical));
                }
                if (frontal < Minimum || Maximum < frontal)
                {
                    throw new ArgumentOutOfRangeException(nameof(frontal));
                }
                if (real < Minimum || Maximum < real)
                {
                    throw new ArgumentOutOfRangeException(nameof(real));
                }

                var dotted
                    = horizontal * horizontal
                    + vertical * vertical
                    + frontal * frontal
                    + real * real;
                var difference = Math.Abs(Length - dotted);

                if (difference > Tolerance)
                {
                    throw new ArgumentOutOfRangeException($"{nameof(horizontal)}^2 + {nameof(vertical)}^2 + {nameof(frontal)}^2 + {nameof(real)}^2 > {Tolerance}");
                }

                this.horizontal = horizontal;

                this.vertical = vertical;

                this.frontal = frontal;

                this.real = real;

                initialized = true;
            }

            /// <inheritdoc/>
            public override string ToString()
            {
                return $"{Horizontal}, {Vertical}, {Frontal}, {Real}";
            }

            /// <inheritdoc/>
            public override int GetHashCode()
            {
                // Visual Studio auto generated.
                var hashCode = -448432282;
                hashCode = hashCode * -1521134295 + Horizontal.GetHashCode();
                hashCode = hashCode * -1521134295 + Vertical.GetHashCode();
                hashCode = hashCode * -1521134295 + Frontal.GetHashCode();
                hashCode = hashCode * -1521134295 + Real.GetHashCode();
                return hashCode;
            }

            /// <inheritdoc/>
            public override bool Equals(object obj)
            {
                if (ReferenceEquals(this, obj))
                {
                    return true;
                }

                if (obj is Direction signal)
                {
                    return Equals(signal);
                }

                return false;
            }

            /// <inheritdoc/>
            public bool Equals(Rotation other)
            {
                return Real.Equals(other.Real)
                    && Horizontal.Equals(other.Horizontal)
                    && Vertical.Equals(other.Vertical)
                    && Frontal.Equals(other.Frontal);
            }

            /// <summary>
            /// Inverses <see cref="Rotation"/>.
            /// </summary>
            /// <param name="rotation">
            /// <see cref="Rotation"/> to inverse.
            /// </param>
            /// <returns>
            /// <see cref="Rotation"/> inversed.
            /// </returns>
            public static Rotation operator -(Rotation rotation)
            {
                var horizontal = -rotation.Horizontal;

                var vertical = -rotation.Vertical;

                var frontal = -rotation.Frontal;

                var real = rotation.Real;

                return new Rotation(horizontal, vertical, frontal, real);
            }

            /// <summary>
            /// Adds <see cref="Rotation"/> and <see cref="Rotation"/>.
            /// </summary>
            /// <param name="left"></param>
            /// <param name="right"></param>
            /// <returns>
            /// <see cref="Rotation"/> added.
            /// </returns>
            public static Rotation operator +(Rotation left, Rotation right)
            {
                var leftW = left.Real;
                var leftX = left.Horizontal;
                var leftY = left.Vertical;
                var leftZ = left.Frontal;

                var rightW = right.Real;
                var rightX = right.Horizontal;
                var rightY = right.Vertical;
                var rightZ = right.Frontal;

                var horizontal
                    = (leftW * rightX)
                    + (leftX * rightW)
                    + (leftY * rightZ)
                    - (leftZ * rightY);

                var vertical
                    = (leftW * rightY)
                    + (leftY * rightW)
                    + (leftZ * rightX)
                    - (leftX * rightZ);

                var frontal
                    = (leftW * rightZ)
                    + (leftZ * rightW)
                    + (leftX * rightY)
                    - (leftY * rightX);

                var real
                    = (leftW * rightW)
                    - (leftX * rightX)
                    - (leftY * rightY)
                    - (leftZ * rightZ);

                return new Rotation(horizontal, vertical, frontal, real);
            }

            /// <summary>
            /// Subtracts <see cref="Rotation"/> and <see cref="Rotation"/>.
            /// </summary>
            /// <param name="left"></param>
            /// <param name="right"></param>
            /// <returns>
            /// <see cref="Rotation"/> subtracted.
            /// </returns>
            public static Rotation operator -(Rotation left, Rotation right)
            {
                return left + (-right);
            }

            /// <summary>
            /// Rotates <see cref="Position"/>.
            /// </summary>
            /// <param name="rotation">
            /// <see cref="Rotation"/> to rotate.
            /// </param>
            /// <param name="position">
            /// <see cref="Position"/> to rotate.
            /// </param>
            /// <returns>
            /// <see cref="Position"/> rotated.
            /// </returns>
            public static Position operator *(Rotation rotation, Position position)
            {
                var direction = position.DirectionFrom(Position.Origin);

                var directionAsRotation = new Rotation(direction.Horizontal, direction.Vertical, direction.Frontal, 0f);

                directionAsRotation = rotation + directionAsRotation - rotation;

                var horizontal = directionAsRotation.Horizontal * position.Distance;
                var vertical = directionAsRotation.Vertical * position.Distance;
                var frontal = directionAsRotation.Frontal * position.Distance;

                return new Position(horizontal, vertical, frontal);
            }

            /// <summary>
            /// Rotates <see cref="Position"/> inversely.
            /// </summary>
            /// <param name="position">
            /// <see cref="Position"/> to rotate.
            /// </param>
            /// <param name="rotation">
            /// <see cref="Rotation"/> to rotate.
            /// </param>
            /// <returns>
            /// <see cref="Position"/> rotated.
            /// </returns>
            public static Position operator /(Position position, Rotation rotation)
            {
                return (-rotation) * position;
            }

            /// <summary>
            /// Checks if <see cref="Rotation"/> and <see cref="Rotation"/> are equal.
            /// </summary>
            /// <param name="left"></param>
            /// <param name="right"></param>
            /// <returns></returns>
            public static bool operator ==(Rotation left, Rotation right)
            {
                if (left.Equals(right))
                {
                    return true;
                }

                var dotted
                    = left.Horizontal * right.Horizontal
                    + left.Vertical * right.Vertical
                    + left.Frontal * right.Frontal
                    + left.Real * right.Real;

                var difference = Length - Math.Abs(dotted);

                return difference <= Tolerance;
            }

            /// <summary>
            /// Checks if <see cref="Rotation"/> and <see cref="Rotation"/> are not equal.
            /// </summary>
            /// <param name="left"></param>
            /// <param name="right"></param>
            /// <returns></returns>
            public static bool operator !=(Rotation left, Rotation right)
            {
                return !(left == right);
            }
        }

        #endregion
    }
}
