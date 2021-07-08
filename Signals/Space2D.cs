using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha.Signals
{
    /// <summary>
    /// Defines some types of <see cref="ISignal"/> for two dimentional space.
    /// </summary>
    public static class Space2D
    {
        private const float Tolerance = float.Epsilon;
        private const float Length = 1.0f;

        #region Position

        /// <summary>
        /// Implementation of <see cref="ISignal"/> to describe position of <see cref="Space2D"/>.
        /// </summary>
        public struct Position :
            ISignal,
            IEquatable<Position>
        {
            /// <summary>
            /// Origin of the coordinate.
            /// </summary>
            public static Position Origin { get; } = new Position(0.0f, 0.0f);

            /// <summary>
            /// Right side in the coordinate.
            /// </summary>
            public static Position Right { get; } = new Position(1.0f, 0.0f);

            /// <summary>
            /// Left side in the coordinate.
            /// </summary>
            public static Position Left { get; } = new Position(-1.0f, 0.0f);

            /// <summary>
            /// Up side in the coordinate.
            /// </summary>
            public static Position Upward { get; } = new Position(0.0f, 1.0f);

            /// <summary>
            /// Down side in the coordinate.
            /// </summary>
            public static Position Downward { get; } = new Position(0.0f, -1.0f);

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
                    + Vertical * Vertical;

                distance = (float)Math.Sqrt(dotted);

                initialized = true;
            }

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
            public Position(float horizontal, float vertical)
            {
                if (float.IsNaN(horizontal))
                {
                    throw new ArgumentException($"{nameof(horizontal)} is NaN.");
                }
                if (float.IsNaN(vertical))
                {
                    throw new ArgumentException($"{nameof(vertical)} is NaN.");
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
                    && Vertical.Equals(other.Vertical);
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
                    return Direction.Upward;
                }

                var difference = this - position;

                var horizontal = difference.Horizontal / difference.Distance;

                var vertical = difference.Vertical / difference.Distance;

                return new Direction(horizontal, vertical);
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

                return new Position(horizontal, vertical);
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

                return new Position(horizontal, vertical);
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

        #endregion

        #region Direction

        /// <summary>
        /// Implementation of <see cref="ISignal"/> to describe direction of <see cref="Space2D"/>.
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

            private bool initialized;
            private void InitializeIfNeeded()
            {
                if (initialized)
                {
                    return;
                }

                horizontal = Upward.Horizontal;

                vertical = Upward.Vertical;

                initialized = true;
            }

            /// <summary>
            /// Reversed <see cref="Direction"/>.
            /// </summary>
            public Direction Reversed
                => new Direction(-Horizontal, -Vertical);

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
            public Direction(float horizontal, float vertical)
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
                var difference = Length - dotted;

                if (difference < -Tolerance || Tolerance < difference)
                {
                    throw new ArgumentOutOfRangeException($"{nameof(horizontal)}^2 + {nameof(vertical)}^2");
                }

                this.horizontal = horizontal;

                this.vertical = vertical;

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
                    && Vertical.Equals(other.Vertical);
            }

            /// <summary>
            /// Calculates <see cref="Rotation"/> from <see cref="Direction"/>.
            /// </summary>
            /// <param name="direction"></param>
            /// <returns>
            /// <see cref="Rotation"/> calculated.
            /// </returns>
            public Rotation RotationFrom(Direction direction)
            {
                var horizontal
                    = Horizontal * direction.Vertical
                    - direction.Vertical * Vertical;

                var vertical
                    = Horizontal * direction.Horizontal
                    + Vertical * direction.Vertical;

                return new Rotation(horizontal, vertical);
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
                    + left.Vertical * right.Vertical;

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
        /// Implementation of <see cref="ISignal"/> to describe rotation of <see cref="Space2D"/>.
        /// </summary>
        public struct Rotation :
            ISignal,
            IEquatable<Rotation>
        {
            public static Rotation None { get; } = new Rotation(1f, 0f);

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

            private bool initialized;
            private void InitializeIfNeeded()
            {
                if (initialized)
                {
                    return;
                }

                horizontal = None.Horizontal;

                vertical = None.Vertical;

                initialized = true;
            }

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
            public Rotation(float horizontal, float vertical)
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
                var difference = Length - dotted;

                if (difference < -Tolerance || Tolerance < difference)
                {
                    throw new ArgumentOutOfRangeException($"{nameof(horizontal)}^2 + {nameof(vertical)}^2");
                }

                this.horizontal = horizontal;

                this.vertical = vertical;

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

                if (obj is Rotation signal)
                {
                    return Equals(signal);
                }

                return false;
            }

            /// <inheritdoc/>
            public bool Equals(Rotation other)
            {
                return Horizontal.Equals(other.Horizontal)
                    && Vertical.Equals(other.Vertical);
            }

            /// <summary>
            /// Converts explicitly <see cref="Angle.Radian"/> to <see cref="Rotation"/>.
            /// </summary>
            /// <param name="radian">
            /// <see cref="Angle.Radian"/> to covert.
            /// </param>
            /// <returns>
            /// <see cref="Rotation"/> converted.
            /// </returns>
            public static explicit operator Rotation(Angle.Radian radian)
            {
                var horizontal = (float)Math.Cos((float)radian);

                var vertical = (float)Math.Sin((float)radian);

                return new Rotation(horizontal, vertical);
            }

            /// <summary>
            /// Converts explicitly <see cref="Rotation"/> to <see cref="Angle.Radian"/>.
            /// </summary>
            /// <param name="rotation">
            /// <see cref="Rotation"/> to covert.
            /// </param>
            /// <returns>
            /// <see cref="Angle.Radian"/> converted.
            /// </returns>
            public static explicit operator Angle.Radian(Rotation rotation)
            {
                var radian = (float)Math.Acos(rotation.Horizontal) * Math.Sign(rotation.Vertical);

                return (Angle.Radian)radian;
            }

            /// <summary>
            /// Converts explicitly <see cref="Angle.Degree"/> to <see cref="Rotation"/>.
            /// </summary>
            /// <param name="degree">
            /// <see cref="Angle.Degree"/> to covert.
            /// </param>
            /// <returns>
            /// <see cref="Rotation"/> converted.
            /// </returns>
            public static explicit operator Rotation(Angle.Degree degree)
            {
                return (Rotation)(Angle.Radian)degree;
            }

            /// <summary>
            /// Converts explicitly <see cref="Rotation"/> to <see cref="Angle.Degree"/>.
            /// </summary>
            /// <param name="rotation">
            /// <see cref="Rotation"/> to covert.
            /// </param>
            /// <returns>
            /// <see cref="Angle.Degree"/> converted.
            /// </returns>
            public static explicit operator Angle.Degree(Rotation rotation)
            {
                return (Angle.Degree)(Angle.Radian)rotation;
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
                var horizontal = rotation.Horizontal;

                var vertical = -rotation.Vertical;

                return new Rotation(horizontal, vertical);
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
                var horizontal
                   = left.Horizontal * right.Horizontal
                   - left.Vertical * right.Vertical;

                var vertical
                    = left.Vertical * right.Horizontal
                    + left.Horizontal * right.Vertical;

                return new Rotation(horizontal, vertical);
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

                var directionAsRotation = new Rotation(direction.Horizontal, direction.Vertical);

                directionAsRotation = rotation + directionAsRotation;

                var horizontal = directionAsRotation.Horizontal * position.Distance;
                var vertical = directionAsRotation.Vertical * position.Distance;

                return new Position(horizontal, vertical);
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
                    + left.Vertical * right.Vertical;

                var difference = Math.Abs(Length - dotted);

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
