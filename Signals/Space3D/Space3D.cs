using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha.Signals
{
    /// <summary>
    /// Defines <see cref="ISignal"/>s for <see cref="Space3D"/>.
    /// </summary>
    public static class Space3D
    {
        /// <summary>
        /// <see cref="float"/> of difference of <see cref="Space3D"/>.
        /// </summary>
        public static float Tolerance { get; } = 1e-5f;

        private const float Length = 1.0f;

        #region Position

        /// <summary>
        /// Implementation of <see cref="ISignal"/> for position in <see cref="Space3D"/>.
        /// </summary>
        public struct Position :
            ISignal,
            IEquatable<Position>
        {
            /// <summary>
            /// Origin of <see cref="Position"/>.
            /// </summary>
            public static Position Origin { get; } = new Position(0.0f, 0.0f, 0.0f);

            /// <summary>
            /// Right of <see cref="Position"/>.
            /// </summary>
            public static Position Right { get; } = new Position(1.0f, 0.0f, 0.0f);

            /// <summary>
            /// Left of <see cref="Position"/>.
            /// </summary>
            public static Position Left { get; } = new Position(-1.0f, 0.0f, 0.0f);

            /// <summary>
            /// Upward of <see cref="Position"/>.
            /// </summary>
            public static Position Upward { get; } = new Position(0.0f, 1.0f, 0.0f);

            /// <summary>
            /// Downward of <see cref="Position"/>.
            /// </summary>
            public static Position Downward { get; } = new Position(0.0f, -1.0f, 0.0f);

            /// <summary>
            /// Forward of <see cref="Position"/>.
            /// </summary>
            public static Position Forward { get; } = new Position(0.0f, 0.0f, 1.0f);

            /// <summary>
            /// Backward of <see cref="Position"/>.
            /// </summary>
            public static Position Backward { get; } = new Position(0.0f, 0.0f, -1.0f);

            /// <summary>
            /// <see cref="float"/> for horizontal of <see cref="Position"/>.
            /// </summary>
            public float Horizontal { get; }

            /// <summary>
            /// <see cref="float"/> for vertical of <see cref="Position"/>.
            /// </summary>
            public float Vertical { get; }

            /// <summary>
            /// <see cref="float"/> for frontal of <see cref="Position"/>.
            /// </summary>
            public float Frontal { get; }

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
                    + Vertical * position.Vertical
                    + Frontal * position.Frontal;
            }

            /// <summary>
            /// Calculates cross product.
            /// </summary>
            /// <param name="position">
            /// <see cref="Position"/> to calculate.
            /// </param>
            /// <returns>
            /// <see cref="Position"/> calculated.
            /// </returns>
            public Position Cross(Position position)
            {
                var horizontal
                    = Vertical * position.Frontal
                    - Frontal * position.Vertical;
                var vertical
                    = Frontal * position.Horizontal
                    - Horizontal * position.Frontal;

                var frontal
                    = Horizontal * position.Vertical
                    - Vertical * position.Horizontal;

                return new Position(horizontal, vertical, frontal);
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

                var frontal = -signal.Frontal;

                return new Position(horizontal, vertical, frontal);
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

                var frontal
                    = left.Frontal
                    + right.Frontal;

                return new Position(horizontal, vertical, frontal);
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
        /// Implementation of <see cref="ISignal"/> for rotation in <see cref="Space3D"/>.
        /// </summary>
        public struct Rotation :
            ISignal,
            IEquatable<Rotation>
        {
            /// <summary>
            /// Minimum <see cref="float"/> for <see cref="Horizontal"/> and <see cref="Vertical"/>, <see cref="Frontal"/> and <see cref="Real"/>.
            /// </summary>
            public const float Minimum = -Length;

            /// <summary>
            /// Maximum <see cref="float"/> for <see cref="Horizontal"/> and <see cref="Vertical"/>, <see cref="Frontal"/> and <see cref="Real"/>.
            /// </summary>
            public const float Maximum = Length;

            /// <summary>
            /// <see cref="Rotation"/> not to rotate.
            /// </summary>
            public static Rotation None { get; } = new Rotation(0.0f, 0.0f, 0.0f, Length);

            private float horizontal;
            /// <summary>
            /// <see cref="float"/> for horizontal of <see cref="Rotation"/>.
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
            /// <see cref="float"/> for vertical of <see cref="Rotation"/>.
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
            /// <see cref="float"/> for frontal of <see cref="Rotation"/>.
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
            /// <see cref="float"/> for real of <see cref="Rotation"/>.
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
            /// Constructor.
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

                if (Math.Abs(Length - dotted) > Tolerance)
                {
                    throw new ArgumentOutOfRangeException($"{nameof(horizontal)}^2 + {nameof(vertical)}^2 + {nameof(frontal)}^2 + {nameof(real)}^2 > {Tolerance}");
                }

                this.horizontal = horizontal;

                this.vertical = vertical;

                this.frontal = frontal;

                this.real = real;

                initialized = true;
            }

            /// <summary>
            /// Calculates dot product.
            /// </summary>
            /// <param name="rotation">
            /// <see cref="Rotation"/> to calculate.
            /// </param>
            /// <returns>
            /// <see cref="float"/> calculated.
            /// </returns>
            public float Dot(Rotation rotation)
            {
                return Horizontal * rotation.Horizontal
                    + Vertical * rotation.Vertical
                    + Frontal * rotation.Frontal
                    + Real * rotation.Real;
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

                if (obj is Rotation signal)
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
            /// Inverses <paramref name="signal"/>.
            /// </summary>
            /// <param name="signal">
            /// <see cref="Rotation"/> to inverse.
            /// </param>
            /// <returns>
            /// <see cref="Rotation"/> inversed.
            /// </returns>
            public static Rotation operator -(Rotation signal)
            {
                var horizontal = -signal.Horizontal;

                var vertical = -signal.Vertical;

                var frontal = -signal.Frontal;

                var real = signal.Real;

                return new Rotation(horizontal, vertical, frontal, real);
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
                return (Rotation)((Quaternion)left + (Quaternion)right);
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
                return (Position)Rotate((Quaternion)rotation, (Quaternion)position);
            }
            private static Quaternion Rotate(Quaternion rotation, Quaternion position)
            {
                return rotation + position - rotation;
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
                
                return Length - Math.Abs(left.Dot(right)) <= Tolerance;
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

        #region Quaternion

        internal struct Quaternion :
            IEquatable<Quaternion>
        {
            public static Quaternion None { get; } = new Quaternion();

            public float Horizontal { get; }

            public float Vertical { get; }

            public float Frontal { get; }

            public float Real { get; }

            public Quaternion(float horizontal, float vertical, float frontal, float real)
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

                Horizontal = horizontal;

                Vertical = vertical;

                Frontal = frontal;

                Real = real;
            }

            public float Dot(Quaternion quaternion)
            {
                return Horizontal * quaternion.Horizontal
                    + Vertical * quaternion.Vertical
                    + Frontal * quaternion.Frontal
                    + Real * quaternion.Real;
            }

            public override string ToString()
            {
                return $"{Horizontal}, {Vertical}, {Frontal}, {Real}";
            }

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

            public override bool Equals(object obj)
            {
                if (ReferenceEquals(this, obj))
                {
                    return true;
                }

                if (obj is Quaternion signal)
                {
                    return Equals(signal);
                }

                return false;
            }

            public bool Equals(Quaternion other)
            {
                return Real.Equals(other.Real)
                    && Horizontal.Equals(other.Horizontal)
                    && Vertical.Equals(other.Vertical)
                    && Frontal.Equals(other.Frontal);
            }

            public static explicit operator Quaternion(Position position)
            {
                return new Quaternion(position.Horizontal, position.Vertical, position.Frontal, 0.0f);
            }

            public static explicit operator Position(Quaternion quaternion)
            {
                return new Position(quaternion.Horizontal, quaternion.Vertical, quaternion.Frontal);
            }

            public static explicit operator Quaternion(Rotation rotation)
            {
                return new Quaternion(rotation.Horizontal, rotation.Vertical, rotation.Frontal, rotation.Real);
            }

            public static explicit operator Rotation(Quaternion quaternion)
            {
                return new Rotation(quaternion.Horizontal, quaternion.Vertical, quaternion.Frontal, quaternion.Real);
            }

            public static Quaternion operator -(Quaternion quaternion)
            {
                var horizontal = -quaternion.Horizontal;

                var vertical = -quaternion.Vertical;

                var frontal = -quaternion.Frontal;

                var real = quaternion.Real;

                return new Quaternion(horizontal, vertical, frontal, real);
            }

            public static Quaternion operator +(Quaternion left, Quaternion right)
            {
                var horizontal
                    = left.Real * right.Horizontal
                    + left.Horizontal * right.Real
                    + left.Vertical * right.Frontal
                    - left.Frontal * right.Vertical;

                var vertical
                    = left.Real * right.Vertical
                    + left.Vertical * right.Real
                    + left.Frontal * right.Horizontal
                    - left.Horizontal * right.Frontal;

                var frontal
                    = left.Real * right.Frontal
                    + left.Frontal * right.Real
                    + left.Horizontal * right.Vertical
                    - left.Vertical * right.Horizontal;

                var real
                    = left.Real * right.Real
                    - left.Horizontal * right.Horizontal
                    - left.Vertical * right.Vertical
                    - left.Frontal * right.Frontal;

                return new Quaternion(horizontal, vertical, frontal, real);
            }

            public static Quaternion operator -(Quaternion left, Quaternion right)
            {
                return left + (-right);
            }

            public static bool operator ==(Quaternion left, Quaternion right)
            {
                if (left.Equals(right))
                {
                    return true;
                }

                var leftLength = Math.Sqrt(left.Dot(left));
                var rightLength = Math.Sqrt(right.Dot(right));

                var dotted = left.Dot(right) / (leftLength * rightLength);

                return Length - Math.Abs(dotted) <= Tolerance;
            }

            public static bool operator !=(Quaternion left, Quaternion right)
            {
                return !(left == right);
            }
        }

        #endregion
    }
}
