using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha.Signals
{
    /// <summary>
    /// Defines <see cref="ISignal"/>s for <see cref="Angle"/>.
    /// </summary>
    public static class Angle
    {
        /// <summary>
        /// <see cref="float"/> of difference of <see cref="Angle"/>.
        /// </summary>
        public static float Tolerance { get; } = 1e-5f;

        /// <summary>
        /// Coefficient to convert <see cref="Degree"/> to <see cref="Radian"/>.
        /// </summary>
        public const float DegreeToRadian = Radian.Maximum / Degree.Maximum;

        /// <summary>
        /// Coefficient to convert <see cref="Radian"/> to <see cref="Degree"/>.
        /// </summary>
        public const float RadianToDegree = Degree.Maximum / Radian.Maximum;

        #region Radian

        /// <summary>
        /// Implementation of <see cref="ISignal"/> to <see cref="Radian"/>.
        /// </summary>
        public struct Radian :
            ISignal,
            IEquatable<Radian>
        {
            /// <summary>
            /// Minimum <see cref="float"/> of <see cref="Radian"/>.
            /// </summary>
            public const float Minimum = -(float)Math.PI;

            /// <summary>
            /// Maximum <see cref="float"/> of <see cref="Radian"/>.
            /// </summary>
            public const float Maximum = (float)Math.PI;

            /// <summary>
            /// Zero of <see cref="Radian"/>.
            /// </summary>
            public static Radian Zero { get; } = new Radian(0.0f);

            private readonly float value;

            /// <summary>
            /// Constructor.
            /// </summary>
            /// <param name="value">
            /// <see cref="float"/> for <see cref="Radian"/>.
            /// </param>
            /// <exception cref="ArgumentException">
            /// Thrown if <paramref name="value"/> is <see cref="float.NaN"/>.
            /// </exception>
            /// <exception cref="ArgumentOutOfRangeException">
            /// Thrown if <paramref name="value"/> is out of range between <see cref="Minimum"/> and <see cref="Maximum"/>.
            /// </exception>
            public Radian(float value)
            {
                if (float.IsNaN(value))
                {
                    throw new ArgumentException($"{nameof(value)} is NaN.");
                }

                if (value < Minimum || Maximum < value)
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }

                this.value = value;
            }

            /// <inheritdoc/>
            public override string ToString()
            {
                return $"{value}";
            }

            /// <inheritdoc/>
            public override int GetHashCode()
            {
                return value.GetHashCode();
            }

            /// <inheritdoc/>
            public override bool Equals(object obj)
            {
                if (ReferenceEquals(this, obj))
                {
                    return true;
                }

                if (obj is Radian signal)
                {
                    return Equals(signal);
                }

                return false;
            }

            /// <inheritdoc/>
            public bool Equals(Radian other)
            {
                return value.Equals(other.value);
            }

            /// <summary>
            /// Converts explicitly <see cref="float"/> to <see cref="Radian"/>.
            /// </summary>
            /// <param name="signal">
            /// <see cref="float"/> to covert.
            /// </param>
            /// <returns>
            /// <see cref="Radian"/> converted.
            /// </returns>
            public static explicit operator Radian(float signal)
            {
                if (signal < Minimum)
                {
                    return new Radian(Minimum);
                }
                if (signal > Maximum)
                {
                    return new Radian(Maximum);
                }

                return new Radian(signal);
            }

            /// <summary>
            /// Converts explicitly <see cref="Radian"/> to <see cref="float"/>.
            /// </summary>
            /// <param name="signal">
            /// <see cref="Radian"/> to covert.
            /// </param>
            /// <returns>
            /// <see cref="float"/> converted.
            /// </returns>
            public static explicit operator float(Radian signal)
            {
                return signal.value;
            }

            /// <summary>
            /// Converts explicitly <see cref="Radian"/> to <see cref="Degree"/>.
            /// </summary>
            /// <param name="signal">
            /// <see cref="Radian"/> to covert.
            /// </param>
            /// <returns>
            /// <see cref="Degree"/> converted.
            /// </returns>
            public static explicit operator Degree(Radian signal)
            {
                var value = signal.value * RadianToDegree;

                return new Degree(value);
            }

            /// <summary>
            /// Inverses <paramref name="signal"/>.
            /// </summary>
            /// <param name="signal">
            /// <see cref="Radian"/> to inverse.
            /// </param>
            /// <returns>
            /// <see cref="Radian"/> inversed.
            /// </returns>
            public static Radian operator -(Radian signal)
            {
                return new Radian(-signal.value);
            }

            /// <summary>
            /// Adds <paramref name="right"/> into <paramref name="left"/>.
            /// </summary>
            /// <param name="left">
            /// <see cref="Radian"/> to add.
            /// </param>
            /// <param name="right">
            /// <see cref="Radian"/> to add.
            /// </param>
            /// <returns>
            /// <see cref="Radian"/> added.
            /// </returns>
            public static Radian operator +(Radian left, Radian right)
            {
                var value
                    = left.value
                    + right.value;

                if (value < Minimum)
                {
                    return new Radian(value + Maximum * 2);
                }

                if (value > Maximum)
                {
                    return new Radian(value + Minimum * 2);
                }

                return new Radian(value);
            }

            /// <summary>
            /// Subtracts <paramref name="right"/> from <paramref name="left"/>.
            /// </summary>
            /// <param name="left">
            /// <see cref="Radian"/> to subtract.
            /// </param>
            /// <param name="right">
            /// <see cref="Radian"/> to subtract.
            /// </param>
            /// <returns>
            /// <see cref="Radian"/> subtracted.
            /// </returns>
            public static Radian operator -(Radian left, Radian right)
            {
                return left + (-right);
            }

            /// <summary>
            /// Checks if <paramref name="left"/> and <paramref name="right"/> are equal.
            /// </summary>
            /// <param name="left">
            /// <see cref="Radian"/> to check.
            /// </param>
            /// <param name="right">
            /// <see cref="Radian"/> to check.
            /// </param>
            /// <returns>
            /// True if <paramref name="left"/> and <paramref name="right"/> are equal.
            /// </returns>
            public static bool operator ==(Radian left, Radian right)
            {
                return left.Equals(right);
            }

            /// <summary>
            /// Checks if <paramref name="left"/> and <paramref name="right"/> are not equal.
            /// </summary>
            /// <param name="left">
            /// <see cref="Radian"/> to check.
            /// </param>
            /// <param name="right">
            /// <see cref="Radian"/> to check.
            /// </param>
            /// <returns>
            /// True if <paramref name="left"/> and <paramref name="right"/> are not equal.
            /// </returns>
            public static bool operator !=(Radian left, Radian right)
            {
                return !(left == right);
            }
        }

        #endregion

        #region Degree

        /// <summary>
        /// Implementation of <see cref="ISignal"/> for <see cref="Degree"/>.
        /// </summary>
        public struct Degree :
            ISignal,
            IEquatable<Degree>
        {
            /// <summary>
            /// Minimum <see cref="float"/> of <see cref="Degree"/>.
            /// </summary>
            public const float Minimum = -180.0f;

            /// <summary>
            /// Maximum <see cref="float"/> of <see cref="Degree"/>.
            /// </summary>
            public const float Maximum = 180.0f;

            /// <summary>
            /// Zero of <see cref="Radian"/>.
            /// </summary>
            public static Radian Zero { get; } = new Radian(0.0f);

            private readonly float value;

            /// <summary>
            /// Constructor.
            /// </summary>
            /// <param name="value">
            /// <see cref="float"/> for <see cref="Degree"/>.
            /// </param>
            /// <exception cref="ArgumentException">
            /// Thrown if <paramref name="value"/> is <see cref="float.NaN"/>.
            /// </exception>
            /// <exception cref="ArgumentOutOfRangeException">
            /// Thrown if <paramref name="value"/> is out of range between <see cref="Minimum"/> and <see cref="Maximum"/>.
            /// </exception>
            public Degree(float value)
            {
                if (float.IsNaN(value))
                {
                    throw new ArgumentException($"{nameof(value)} is NaN.");
                }

                if (value < Minimum || Maximum < value)
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }

                this.value = value;
            }

            /// <inheritdoc/>
            public override string ToString()
            {
                return $"{value}";
            }

            /// <inheritdoc/>
            public override int GetHashCode()
            {
                return value.GetHashCode();
            }

            /// <inheritdoc/>
            public override bool Equals(object obj)
            {
                if (ReferenceEquals(this, obj))
                {
                    return true;
                }

                if (obj is Degree signal)
                {
                    return Equals(signal);
                }

                return false;
            }

            /// <inheritdoc/>
            public bool Equals(Degree other)
            {
                return value.Equals(other.value);
            }

            /// <summary>
            /// Converts explicitly <see cref="float"/> to <see cref="Degree"/>.
            /// </summary>
            /// <param name="signal">
            /// <see cref="float"/> to covert.
            /// </param>
            /// <returns>
            /// <see cref="Degree"/> converted.
            /// </returns>
            public static explicit operator Degree(float signal)
            {
                if (signal < Minimum)
                {
                    return new Degree(Minimum);
                }
                if (signal > Maximum)
                {
                    return new Degree(Maximum);
                }

                return new Degree(signal);
            }

            /// <summary>
            /// Converts explicitly <see cref="Degree"/> to <see cref="float"/>.
            /// </summary>
            /// <param name="signal">
            /// <see cref="Degree"/> to covert.
            /// </param>
            /// <returns>
            /// <see cref="float"/> converted.
            /// </returns>
            public static explicit operator float(Degree signal)
            {
                return signal.value;
            }

            /// <summary>
            /// Converts explicitly <see cref="Degree"/> to <see cref="Radian"/>.
            /// </summary>
            /// <param name="signal">
            /// <see cref="Degree"/> to covert.
            /// </param>
            /// <returns>
            /// <see cref="Radian"/> converted.
            /// </returns>
            public static explicit operator Radian(Degree signal)
            {
                var value = signal.value * DegreeToRadian;

                return new Radian(value);
            }

            /// <summary>
            /// Inverses <paramref name="signal"/>.
            /// </summary>
            /// <param name="signal">
            /// <see cref="Degree"/> to inverse.
            /// </param>
            /// <returns>
            /// <see cref="Degree"/> inversed.
            /// </returns>
            public static Degree operator -(Degree signal)
            {
                return new Degree(-signal.value);
            }

            /// <summary>
            /// Adds <paramref name="right"/> into <paramref name="left"/>.
            /// </summary>
            /// <param name="left">
            /// <see cref="Degree"/> to add.
            /// </param>
            /// <param name="right">
            /// <see cref="Degree"/> to add.
            /// </param>
            /// <returns>
            /// <see cref="Degree"/> added.
            /// </returns>
            public static Degree operator +(Degree left, Degree right)
            {
                var value
                    = left.value
                    + right.value;

                if (value < Minimum)
                {
                    return new Degree(value + Maximum * 2);
                }

                if (value > Maximum)
                {
                    return new Degree(value + Minimum * 2);
                }

                return new Degree(value);
            }

            /// <summary>
            /// Subtracts <paramref name="right"/> from <paramref name="left"/>.
            /// </summary>
            /// <param name="left">
            /// <see cref="Degree"/> to subtract.
            /// </param>
            /// <param name="right">
            /// <see cref="Degree"/> to subtract.
            /// </param>
            /// <returns>
            /// <see cref="Degree"/> subtracted.
            /// </returns>
            public static Degree operator -(Degree left, Degree right)
            {
                return left + (-right);
            }

            /// <summary>
            /// Checks if <paramref name="left"/> and <paramref name="right"/> are equal.
            /// </summary>
            /// <param name="left">
            /// <see cref="Degree"/> to check.
            /// </param>
            /// <param name="right">
            /// <see cref="Degree"/> to check.
            /// </param>
            /// <returns>
            /// True if <paramref name="left"/> and <paramref name="right"/> are equal.
            /// </returns>
            public static bool operator ==(Degree left, Degree right)
            {
                return left.Equals(right);
            }

            /// <summary>
            /// Checks if <paramref name="left"/> and <paramref name="right"/> are not equal.
            /// </summary>
            /// <param name="left">
            /// <see cref="Degree"/> to check.
            /// </param>
            /// <param name="right">
            /// <see cref="Degree"/> to check.
            /// </param>
            /// <returns>
            /// True if <paramref name="left"/> and <paramref name="right"/> are not equal.
            /// </returns>
            public static bool operator !=(Degree left, Degree right)
            {
                return !(left == right);
            }
        }

        #endregion
    }
}
