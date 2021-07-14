using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using System;

namespace YggdrAshill.Nuadha.Signals
{
    /// <summary>
    /// Defines some types of <see cref="ISignal"/> for three dimentional space.
    /// </summary>
    public static class Space3D
    {
        private const float Tolerance = float.Epsilon;
        private const float Length = 1.0f;

        #region Position

        /// <summary>
        /// Implementation of <see cref="ISignal"/> to describe position of <see cref="Space3D"/>.
        /// </summary>
        public struct Position :
            ISignal,
            IEquatable<Position>
        {
            /// <summary>
            /// Origin of the coordinate.
            /// </summary>
            public static Position Origin { get; } = new Position(0.0f, 0.0f, 0.0f);

            /// <summary>
            /// Right side in the coordinate.
            /// </summary>
            public static Position Right { get; } = new Position(1.0f, 0.0f, 0.0f);

            /// <summary>
            /// Left side in the coordinate.
            /// </summary>
            public static Position Left { get; } = new Position(-1.0f, 0.0f, 0.0f);

            /// <summary>
            /// Up side in the coordinate.
            /// </summary>
            public static Position Upward { get; } = new Position(0.0f, 1.0f, 0.0f);

            /// <summary>
            /// Down side in the coordinate.
            /// </summary>
            public static Position Downward { get; } = new Position(0.0f, -1.0f, 0.0f);

            /// <summary>
            /// Front side in the coordinate.
            /// </summary>
            public static Position Forward { get; } = new Position(0.0f, 0.0f, 1.0f);

            /// <summary>
            /// Back side in the coordinate.
            /// </summary>
            public static Position Backward { get; } = new Position(0.0f, 0.0f, -1.0f);

            /// <summary>
            /// Value for horizontal of the coordinate.
            /// </summary>
            public float Horizontal { get; }

            /// <summary>
            /// Value for vertical of the coordinate.
            /// </summary>
            public float Vertical { get; }

            /// <summary>
            /// Value for frontal of the coordinate.
            /// </summary>
            public float Frontal { get; }

            private float distance;
            /// <summary>
            /// Distance of <see cref="Position"/>.
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
            /// Constructs an instance.
            /// </summary>
            /// <param name="horizontal"></param>
            /// <param name="vertical"></param>
            /// <param name="frontal"></param>
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

            /// <inheritdoc/>
            public override string ToString()
            {
                return $"{Horizontal}, {Vertical}, {Frontal}";
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
            /// Calculates <see cref="Direction"/> from <see cref="Position"/>.
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

            /// <summary>
            /// Inverses <see cref="Position"/>.
            /// </summary>
            /// <param name="position">
            /// <see cref="Position"/> to inverse.
            /// </param>
            /// <returns>
            /// <see cref="Position"/> inversed.
            /// </returns>
            public static Position operator -(Position position)
            {
                var horizontal = -position.Horizontal;

                var vertical = -position.Vertical;

                var frontal = -position.Frontal;

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
                if (left.Equals(right))
                {
                    return true;
                }

                return (left - right).Distance < Tolerance;
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

        public static class PositionInto
        {
            public sealed class PositionTo :
                ICalibration<Position>
            {
                public static IConversion<Position, Position> Calibrate(IGeneration<Position> generation)
                {
                    if (generation == null)
                    {
                        throw new ArgumentNullException(nameof(generation));
                    }

                    return Instance.ToConversion(generation);
                }

                public static PositionTo Instance { get; } = new PositionTo();

                private PositionTo()
                {

                }

                public Position Calibrate(Position signal, Position offset)
                {
                    return signal + offset;
                }
            }
        }

        #endregion

        #region Direction

        /// <summary>
        /// Implementation of <see cref="ISignal"/> to describe direction of <see cref="Space3D"/>.
        /// </summary>
        public struct Direction :
            ISignal,
            IEquatable<Direction>
        {
            /// <summary>
            /// Right side in the coordinate.
            /// </summary>
            public static Direction Right { get; } = Position.Right.DirectionFrom(Position.Origin);

            /// <summary>
            /// Left side in the coordinate.
            /// </summary>
            public static Direction Left { get; } = Position.Left.DirectionFrom(Position.Origin);

            /// <summary>
            /// Up side in the coordinate.
            /// </summary>
            public static Direction Upward { get; } = Position.Upward.DirectionFrom(Position.Origin);

            /// <summary>
            /// Down side in the coordinate.
            /// </summary>
            public static Direction Downward { get; } = Position.Downward.DirectionFrom(Position.Origin);

            /// <summary>
            /// Front side in the coordinate.
            /// </summary>
            public static Direction Forward { get; } = Position.Forward.DirectionFrom(Position.Origin);

            /// <summary>
            /// Back side in the coordinate.
            /// </summary>
            public static Direction Backward { get; } = Position.Backward.DirectionFrom(Position.Origin);

            private float horizontal;
            /// <summary>
            /// Value for horizontal of the coordinate.
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
            /// Value for vertical of the coordinate.
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
            /// Value for vertical of the coordinate.
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
            public Direction Reversed
                => new Direction(-Horizontal, -Vertical, -Frontal);

            /// <summary>
            /// Constructs an instance.
            /// </summary>
            /// <param name="horizontal"></param>
            /// <param name="vertical"></param>
            /// <param name="frontal"></param>
            /// <exception cref="ArgumentException">
            /// Thrown if <paramref name="horizontal"/> is <see cref="float.NaN"/>.
            /// </exception>
            /// <exception cref="ArgumentException">
            /// Thrown if <paramref name="vertical"/> is <see cref="float.NaN"/>.
            /// </exception>
            /// <exception cref="ArgumentException">
            /// Thrown if <paramref name="frontal"/> is <see cref="float.NaN"/>.
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

                if (horizontal < -Length || Length < horizontal)
                {
                    throw new ArgumentOutOfRangeException(nameof(horizontal));
                }
                if (vertical < -Length || Length < vertical)
                {
                    throw new ArgumentOutOfRangeException(nameof(vertical));
                }
                if (frontal < -Length || Length < frontal)
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
                    throw new ArgumentOutOfRangeException($"{nameof(horizontal)}^2 + {nameof(vertical)}^2 + {nameof(frontal)}^2");
                }

                this.horizontal = horizontal;

                this.vertical = vertical;

                this.frontal = frontal;

                initialized = true;
            }

            /// <inheritdoc/>
            public override string ToString()
            {
                return $"{Horizontal}, {Vertical}, {Frontal}";
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

            public Rotation RotationOf(Angle.Degree degree)
            {
                return RotationOf((Angle.Radian)degree);
            }

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

            /// <summary>
            /// Checks if <see cref="Direction"/> and <see cref="Direction"/> are equal.
            /// </summary>
            /// <param name="left"></param>
            /// <param name="right"></param>
            /// <returns></returns>
            public static bool operator ==(Direction left, Direction right)
            {
                if (left.Equals(right))
                {
                    return true;
                }

                var dotted
                    = left.Horizontal * right.Horizontal
                    + left.Vertical * right.Vertical
                    + left.Frontal * right.Frontal;

                var difference = Math.Abs(Length - dotted);

                return difference <= Tolerance;
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
        /// Implementation of <see cref="ISignal"/> to describe rotation.
        /// </summary>
        public struct Rotation :
            ISignal,
            IEquatable<Rotation>
        {
            /// <summary>
            /// <see cref="Rotation"/> not rotated.
            /// </summary>
            public static Rotation None { get; } = new Rotation(0.0f, 0.0f, 0.0f, 1.0f);

            private float horizontal;
            private float Horizontal
            {
                get
                {
                    InitializeIfNeeded();

                    return horizontal;
                }
            }

            private float vertical;
            private float Vertical
            {
                get
                {
                    InitializeIfNeeded();

                    return vertical;
                }
            }

            private float frontal;
            private float Frontal
            {
                get
                {
                    InitializeIfNeeded();

                    return frontal;
                }
            }

            private float real;
            private float Real
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

                if (horizontal < -Length || Length < horizontal)
                {
                    throw new ArgumentOutOfRangeException(nameof(horizontal));
                }
                if (vertical < -Length || Length < vertical)
                {
                    throw new ArgumentOutOfRangeException(nameof(vertical));
                }
                if (frontal < -Length || Length < frontal)
                {
                    throw new ArgumentOutOfRangeException(nameof(frontal));
                }
                if (real < -Length || Length < real)
                {
                    throw new ArgumentOutOfRangeException(nameof(frontal));
                }

                var dotted
                    = horizontal * horizontal
                    + vertical * vertical
                    + frontal * frontal
                    + real * real;
                var difference = Math.Abs(Length - dotted);

                if (difference > Tolerance)
                {
                    throw new ArgumentOutOfRangeException($"{nameof(horizontal)}^2 + {nameof(vertical)}^2 + {nameof(frontal)}^2 + {nameof(real)}^2");
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

        public static class RotationInto
        {
            public sealed class RotationTo :
                ICalibration<Rotation>
            {
                public static IConversion<Rotation, Rotation> Calibrate(IGeneration<Rotation> generation)
                {
                    if (generation == null)
                    {
                        throw new ArgumentNullException(nameof(generation));
                    }

                    return Instance.ToConversion(generation);
                }

                public static RotationTo Instance { get; } = new RotationTo();

                private RotationTo()
                {

                }

                public Rotation Calibrate(Rotation signal, Rotation offset)
                {
                    return signal + offset;
                }
            }
        }

        #endregion
    }
}
