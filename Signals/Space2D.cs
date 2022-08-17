using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha.Signals
{
    /// <summary>
    /// Defines <see cref="ISignal"/>s for <see cref="Space2D"/>.
    /// </summary>
    public static class Space2D
    {
        /// <summary>
        /// <see cref="float"/> of difference of <see cref="Space2D"/>.
        /// </summary>
        public static float Tolerance { get; } = 1e-5f;

        private const float Length = 1.0f;

        #region Position

        /// <summary>
        /// Implementation of <see cref="ISignal"/> for position in <see cref="Space2D"/>.
        /// </summary>
        public struct Position :
            ISignal,
            IEquatable<Position>
        {
            /// <summary>
            /// Origin of <see cref="Position"/>.
            /// </summary>
            public static Position Origin { get; } = new Position(0.0f, 0.0f);

            /// <summary>
            /// Right of <see cref="Position"/>.
            /// </summary>
            public static Position Right { get; } = new Position(1.0f, 0.0f);

            /// <summary>
            /// Left of <see cref="Position"/>.
            /// </summary>
            public static Position Left { get; } = new Position(-1.0f, 0.0f);

            /// <summary>
            /// Upward of <see cref="Position"/>.
            /// </summary>
            public static Position Upward { get; } = new Position(0.0f, 1.0f);

            /// <summary>
            /// Downward of <see cref="Position"/>.
            /// </summary>
            public static Position Downward { get; } = new Position(0.0f, -1.0f);

            /// <summary>
            /// <see cref="float"/> for horizontal of <see cref="Position"/>.
            /// </summary>
            public float Horizontal { get; }

            /// <summary>
            /// <see cref="float"/> for vertical of <see cref="Position"/>.
            /// </summary>
            public float Vertical { get; }

            /// <summary>
            /// <see cref="float"/> for distance of <see cref="Position"/>.
            /// </summary>
            public float Distance
            {
                get
                {
                    return (float)Math.Sqrt(Dot(this));
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
            }

            /// <summary>
            /// Calculates dot product.
            /// </summary>
            /// <param name="position">
            /// <see cref="Position"/> to calculate.
            /// </param>
            /// <returns>
            /// <see cref="float"/> calculated.
            /// </returns>
            public float Dot(Position position)
            {
                return Horizontal * position.Horizontal
                    + Vertical * position.Vertical;
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
            /// Inverses <paramref name="signal"/>.
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

                return new Position(horizontal, vertical);
            }

            /// <summary>
            /// Adds <paramref name="right"/> into <paramref name="left"/>.
            /// </summary>
            /// <param name="left">
            /// <see cref="Position"/> to add.
            /// </param>
            /// <param name="right">
            /// <see cref="Position"/> to add.
            /// </param>
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
            /// Subtracts <paramref name="right"/> from <paramref name="left"/>.
            /// </summary>
            /// <param name="left">
            /// <see cref="Position"/> to subtract.
            /// </param>
            /// <param name="right">
            /// <see cref="Position"/> to subtract.
            /// </param>
            /// <returns>
            /// <see cref="Position"/> subtracted.
            /// </returns>
            public static Position operator -(Position left, Position right)
            {
                return left + (-right);
            }

            /// <summary>
            /// Checks if <paramref name="left"/> and <paramref name="right"/> are equal.
            /// </summary>
            /// <param name="left">
            /// <see cref="Position"/> to check.
            /// </param>
            /// <param name="right">
            /// <see cref="Position"/> to check.
            /// </param>
            /// <returns>
            /// True if <paramref name="left"/> and <paramref name="right"/> are equal.
            /// </returns>
            public static bool operator ==(Position left, Position right)
            {
                if (left.Equals(right))
                {
                    return true;
                }

                var difference = left - right;

                return difference.Dot(difference) <= Tolerance;
            }

            /// <summary>
            /// Checks if <paramref name="left"/> and <paramref name="right"/> are not equal.
            /// </summary>
            /// <param name="left">
            /// <see cref="Position"/> to check.
            /// </param>
            /// <param name="right">
            /// <see cref="Position"/> to check.
            /// </param>
            /// <returns>
            /// True if <paramref name="left"/> and <paramref name="right"/> are not equal.
            /// </returns>
            public static bool operator !=(Position left, Position right)
            {
                return !(left == right);
            }
        }

        #endregion

        #region Rotation

        /// <summary>
        /// Implementation of <see cref="ISignal"/> for rotation in <see cref="Space2D"/>.
        /// </summary>
        public struct Rotation :
            ISignal,
            IEquatable<Rotation>
        {
            /// <summary>
            /// Minimum <see cref="float"/> for <see cref="Horizontal"/> and <see cref="Vertical"/>.
            /// </summary>
            public const float Minimum = -Length;

            /// <summary>
            /// Maximum <see cref="float"/> for <see cref="Horizontal"/> and <see cref="Vertical"/>.
            /// </summary>
            public const float Maximum = Length;

            /// <summary>
            /// <see cref="Rotation"/> not rotated.
            /// </summary>
            public static Rotation None { get; } = new Rotation(1f, 0f);

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
            /// Constructor.
            /// </summary>
            /// <param name="horizontal">
            /// <see cref="float"/> for <see cref="Rotation"/>.
            /// </param>
            /// <param name="vertical">
            /// <see cref="float"/> for <see cref="Rotation"/>.
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
            /// Thrown if <paramref name="vertical"/> is  out of range between <see cref="Minimum"/> and <see cref="Maximum"/>.
            /// </exception>
            /// <exception cref="ArgumentOutOfRangeException">
            /// Thrown if <paramref name="horizontal"/>^2 + <paramref name="vertical"/>^2 is larger than <see cref="Tolerance"/>.
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

                var difference = Math.Abs(Length - dotted);

                if (difference > Tolerance)
                {
                    throw new ArgumentOutOfRangeException($"{nameof(horizontal)}^2 + {nameof(vertical)}^2 > {Tolerance}");
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

                return new Angle.Radian(radian);
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
            /// Inverses <paramref name="signal"/>.
            /// </summary>
            /// <param name="signal">
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
            /// Adds <paramref name="right"/> into <paramref name="left"/>.
            /// </summary>
            /// <param name="left">
            /// <see cref="Rotation"/> to add.
            /// </param>
            /// <param name="right">
            /// <see cref="Rotation"/> to add.
            /// </param>
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
            /// Subtracts <paramref name="right"/> from <paramref name="left"/>.
            /// </summary>
            /// <param name="left">
            /// <see cref="Rotation"/> to subtract.
            /// </param>
            /// <param name="right">
            /// <see cref="Rotation"/> to subtract.
            /// </param>
            /// <returns>
            /// <see cref="Rotation"/> subtracted.
            /// </returns>
            public static Rotation operator -(Rotation left, Rotation right)
            {
                return left + (-right);
            }

            /// <summary>
            /// Rotates <paramref name="position"/>.
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

                var horizontal
                   = rotation.Horizontal * position.Horizontal
                   - rotation.Vertical * position.Vertical;

                var vertical
                    = rotation.Vertical * position.Horizontal
                    + rotation.Horizontal * position.Vertical;

                return new Position(horizontal, vertical);
            }

            /// <summary>
            /// Rotates <paramref name="position"/> inversely.
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
            /// Checks if <paramref name="left"/> and <paramref name="right"/> are equal.
            /// </summary>
            /// <param name="left">
            /// <see cref="Rotation"/> to check.
            /// </param>
            /// <param name="right">
            /// <see cref="Rotation"/> to check.
            /// </param>
            /// <returns>
            /// True if <paramref name="left"/> and <paramref name="right"/> are equal.
            /// </returns>
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
            /// Checks if <paramref name="left"/> and <paramref name="right"/> are not equal.
            /// </summary>
            /// <param name="left">
            /// <see cref="Rotation"/> to check.
            /// </param>
            /// <param name="right">
            /// <see cref="Rotation"/> to check.
            /// </param>
            /// <returns>
            /// True if <paramref name="left"/> and <paramref name="right"/> are not equal.
            /// </returns>
            public static bool operator !=(Rotation left, Rotation right)
            {
                return !(left == right);
            }
        }

        #endregion

        #region Pose

        /// <summary>
        /// Implemetation of <see cref="ISignal"/> for pose in <see cref="Space3D"/>.
        /// </summary>
        public struct Pose :
            ISignal,
            IEquatable<Pose>
        {
            /// <summary>
            /// Default <see cref="Pose"/>.
            /// </summary>
            public static Pose Origin { get; } = new Pose(Position.Origin, Rotation.None);

            /// <summary>
            /// <see cref="Space3D.Position"/> of <see cref="Pose"/>.
            /// </summary>
            public Position Position { get; }

            /// <summary>
            /// <see cref="Space3D.Rotation"/> of <see cref="Pose"/>.
            /// </summary>
            public Rotation Rotation { get; }

            /// <summary>
            /// Constructor.
            /// </summary>
            /// <param name="position">
            /// <see cref="Space3D.Position"/> for <see cref="Position"/>.
            /// </param>
            /// <param name="rotation">
            /// <see cref="Space3D.Rotation"/> for <see cref="Rotation"/>.
            /// </param>
            public Pose(Position position, Rotation rotation)
            {
                Position = position;

                Rotation = rotation;
            }

            /// <inheritdoc/>
            public override string ToString()
            {
                return $"({Position}), ({Rotation})";
            }

            /// <inheritdoc/>
            public override int GetHashCode()
            {
                // Visual Studio auto generated.
                var hashCode = -388643783;
                hashCode = hashCode * -1521134295 + Position.GetHashCode();
                hashCode = hashCode * -1521134295 + Rotation.GetHashCode();
                return hashCode;
            }

            /// <inheritdoc/>
            public override bool Equals(object obj)
            {
                if (ReferenceEquals(this, obj))
                {
                    return true;
                }

                if (obj is Pose signal)
                {
                    return Equals(signal);
                }

                return false;
            }

            /// <inheritdoc/>
            public bool Equals(Pose other)
            {
                return Position.Equals(other.Position)
                    && Rotation.Equals(other.Rotation);
            }

            /// <summary>
            /// Converts explicitly <see cref="Space3D.Position"/> to <see cref="Pose"/>.
            /// </summary>
            /// <param name="signal">
            /// <see cref="Space3D.Position"/> to covert.
            /// </param>
            /// <returns>
            /// <see cref="Pose"/> converted.
            /// </returns>
            public static explicit operator Pose(Position signal)
            {
                return new Pose(signal, Rotation.None);
            }

            /// <summary>
            /// Converts explicitly <see cref="Space3D.Rotation"/> to <see cref="Pose"/>.
            /// </summary>
            /// <param name="signal">
            /// <see cref="Space3D.Rotation"/> to covert.
            /// </param>
            /// <returns>
            /// <see cref="Pose"/> converted.
            /// </returns>
            public static explicit operator Pose(Rotation signal)
            {
                return new Pose(Position.Origin, signal);
            }

            /// <summary>
            /// Inverses <paramref name="signal"/>.
            /// </summary>
            /// <param name="signal">
            /// <see cref="Pose"/> to inverse.
            /// </param>
            /// <returns>
            /// <see cref="Pose"/> inversed.
            /// </returns>
            public static Pose operator -(Pose signal)
            {
                var position = -signal.Position;
                var rotation = -signal.Rotation;

                return new Pose(position, rotation);
            }

            /// <summary>
            /// Adds <paramref name="right"/> into <paramref name="left"/>.
            /// </summary>
            /// <param name="left">
            /// <see cref="Pose"/> to add.
            /// </param>
            /// <param name="right">
            /// <see cref="Pose"/> to add.
            /// </param>
            /// <returns>
            /// <see cref="Pose"/> added.
            /// </returns>
            public static Pose operator +(Pose left, Pose right)
            {
                var position = left.Position + right.Position;
                var rotation = left.Rotation + right.Rotation;

                return new Pose(position, rotation);
            }

            /// <summary>
            /// Subtracts <paramref name="right"/> from <paramref name="left"/>.
            /// </summary>
            /// <param name="left">
            /// <see cref="Pose"/> to subtract.
            /// </param>
            /// <param name="right">
            /// <see cref="Pose"/> to subtract.
            /// </param>
            /// <returns>
            /// <see cref="Pose"/> subtracted.
            /// </returns>
            public static Pose operator -(Pose left, Pose right)
            {
                return left + (-right);
            }

            /// <summary>
            /// Checks if <paramref name="left"/> and <paramref name="right"/> are equal.
            /// </summary>
            /// <param name="left">
            /// <see cref="Pose"/> to check.
            /// </param>
            /// <param name="right">
            /// <see cref="Pose"/> to check.
            /// </param>
            /// <returns>
            /// True if <paramref name="left"/> and <paramref name="right"/> are equal.
            /// </returns>
            public static bool operator ==(Pose left, Pose right)
            {
                return left.Equals(right);
            }

            /// <summary>
            /// Checks if <paramref name="left"/> and <paramref name="right"/> are not equal.
            /// </summary>
            /// <param name="left">
            /// <see cref="Pose"/> to check.
            /// </param>
            /// <param name="right">
            /// <see cref="Pose"/> to check.
            /// </param>
            /// <returns>
            /// True if <paramref name="left"/> and <paramref name="right"/> are not equal.
            /// </returns>
            public static bool operator !=(Pose left, Pose right)
            {
                return !(left == right);
            }
        }

        #endregion
    }
}
