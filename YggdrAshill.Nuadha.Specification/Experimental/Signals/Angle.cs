using YggdrAshill.Nuadha.Signalization.Experimental;
using System;

namespace YggdrAshill.Nuadha.Signals.Experimental
{
    /// <summary>
    /// Defines some types of <see cref="ISignal"/> for angle.
    /// </summary>
    public static class Angle
    {
        #region Constants

        /// <summary>
        /// Coefficient to convert <see cref="Degree"/> to <see cref="Radian"/>.
        /// </summary>
        public const float DegreeToRadian = Radian.Maximum / Degree.Maximum;

        /// <summary>
        /// Coefficient to convert <see cref="Radian"/> to <see cref="Degree"/>.
        /// </summary>
        public const float RadianToDegree = Degree.Maximum / Radian.Maximum;

        private const float Tolerance = 1e-4f;

        #endregion

        #region Radian

        /// <summary>
        /// Implementation of <see cref="ISignal"/> to describe radian.
        /// </summary>
        public struct Radian :
            ISignal,
            IEquatable<Radian>
        {
            /// <summary>
            /// <see cref="Minimum"/> of <see cref="Radian"/>.
            /// </summary>
            public const float Minimum = -MathF.PI;

            /// <summary>
            /// <see cref="Maximum"/> of <see cref="Radian"/>.
            /// </summary>
            public const float Maximum = MathF.PI;

            internal readonly float value;

            /// <summary>
            /// Constructs an instance.
            /// </summary>
            /// <param name="value"></param>
            /// <exception cref="ArgumentException">
            /// Thrown if <paramref name="value"/> is <see cref="float.NaN"/>.
            /// </exception>
            /// <exception cref="ArgumentOutOfRangeException">
            /// Thrown if <paramref name="value"/> is not between <see cref="Minimum"/> to <see cref="Maximum"/>.
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
            /// <exception cref="ArgumentException">
            /// Thrown if <paramref name="signal"/> is <see cref="float.NaN"/>.
            /// </exception>
            /// <exception cref="ArgumentOutOfRangeException">
            /// Thrown if <paramref name="signal"/> is not between <see cref="Minimum"/> to <see cref="Maximum"/>.
            /// </exception>
            public static explicit operator Radian(float signal)
            {
                return new Radian(signal);
            }

            /// <summary>
            /// Converts explicitly <see cref="Radian"/> to <see cref="float"/>.
            /// </summary>
            /// <param name="radian">
            /// <see cref="Radian"/> to covert.
            /// </param>
            /// <returns>
            /// <see cref="float"/> converted.
            /// </returns>
            public static explicit operator float(Radian radian)
            {
                return radian.value;
            }

            /// <summary>
            /// Converts explicitly <see cref="Degree"/> to <see cref="Radian"/>.
            /// </summary>
            /// <param name="degree">
            /// <see cref="Degree"/> to covert.
            /// </param>
            /// <returns>
            /// <see cref="Radian"/> converted.
            /// </returns>
            public static explicit operator Radian(Degree degree)
            {
                var value = degree.value * DegreeToRadian;

                return new Radian(value);
            }

            /// <summary>
            /// Inverses <see cref="Radian"/>.
            /// </summary>
            /// <param name="radian">
            /// <see cref="Radian"/> to inverse.
            /// </param>
            /// <returns>
            /// <see cref="Radian"/> inversed.
            /// </returns>
            public static Radian operator -(Radian radian)
            {
                return new Radian(-radian.value);
            }

            /// <summary>
            /// Adds <see cref="Radian"/> and <see cref="Radian"/>.
            /// </summary>
            /// <param name="left"></param>
            /// <param name="right"></param>
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
                    value += 2 * Maximum;
                }
                else if (value > Maximum)
                {
                    value += 2 * Minimum;
                }

                return new Radian(value);
            }

            /// <summary>
            /// Subtracts <see cref="Radian"/> and <see cref="Radian"/>.
            /// </summary>
            /// <param name="left"></param>
            /// <param name="right"></param>
            /// <returns>
            /// <see cref="Radian"/> subtracted.
            /// </returns>
            public static Radian operator -(Radian left, Radian right)
            {
                return left + (-right);
            }

            /// <summary>
            /// Checks if <see cref="Radian"/> and <see cref="Radian"/> are equal.
            /// </summary>
            /// <param name="left"></param>
            /// <param name="right"></param>
            /// <returns></returns>
            public static bool operator ==(Radian left, Radian right)
            {
                if (left.Equals(right))
                {
                    return true;
                }

                return MathF.Abs(left.value - right.value) < Tolerance;
            }

            /// <summary>
            /// Checks if <see cref="Radian"/> and <see cref="Radian"/> are not equal.
            /// </summary>
            /// <param name="left"></param>
            /// <param name="right"></param>
            /// <returns></returns>
            public static bool operator !=(Radian left, Radian right)
            {
                return !(left == right);
            }
        }

        #endregion

        #region Degree

        /// <summary>
        /// Implementation of <see cref="ISignal"/> to describe degree.
        /// </summary>
        public struct Degree :
            ISignal,
            IEquatable<Degree>
        {
            /// <summary>
            /// <see cref="Minimum"/> of <see cref="Degree"/>.
            /// </summary>
            public const float Minimum = -180.0f;

            /// <summary>
            /// <see cref="Maximum"/> of <see cref="Degree"/>.
            /// </summary>
            public const float Maximum = 180.0f;

            internal readonly float value;

            /// <summary>
            /// Constructs an instance.
            /// </summary>
            /// <param name="value"></param>
            /// <exception cref="ArgumentException">
            /// Thrown if <paramref name="value"/> is <see cref="float.NaN"/>.
            /// </exception>
            /// <exception cref="ArgumentOutOfRangeException">
            /// Thrown if <paramref name="value"/> is not between <see cref="Minimum"/> to <see cref="Maximum"/>.
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
            /// <exception cref="ArgumentException">
            /// Thrown if <paramref name="signal"/> is <see cref="float.NaN"/>.
            /// </exception>
            /// <exception cref="ArgumentOutOfRangeException">
            /// Thrown if <paramref name="signal"/> is not between <see cref="Minimum"/> to <see cref="Maximum"/>.
            /// </exception>
            public static explicit operator Degree(float signal)
            {
                return new Degree(signal);
            }

            /// <summary>
            /// Converts explicitly <see cref="Degree"/> to <see cref="float"/>.
            /// </summary>
            /// <param name="degree">
            /// <see cref="Degree"/> to covert.
            /// </param>
            /// <returns>
            /// <see cref="float"/> converted.
            /// </returns>
            public static explicit operator float(Degree degree)
            {
                return degree.value;
            }

            /// <summary>
            /// Converts explicitly <see cref="Radian"/> to <see cref="Degree"/>.
            /// </summary>
            /// <param name="radian">
            /// <see cref="Radian"/> to covert.
            /// </param>
            /// <returns>
            /// <see cref="Degree"/> converted.
            /// </returns>
            public static explicit operator Degree(Radian radian)
            {
                var value = radian.value * RadianToDegree;

                return new Degree(value);
            }

            /// <summary>
            /// Inverses <see cref="Degree"/>.
            /// </summary>
            /// <param name="degree">
            /// <see cref="Degree"/> to inverse.
            /// </param>
            /// <returns>
            /// <see cref="Degree"/> inversed.
            /// </returns>
            public static Degree operator -(Degree degree)
            {
                return new Degree(-degree.value);
            }

            /// <summary>
            /// Adds <see cref="Degree"/> and <see cref="Degree"/>.
            /// </summary>
            /// <param name="left"></param>
            /// <param name="right"></param>
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
                    value += 2 * Maximum;
                }
                else if (value > Maximum)
                {
                    value += 2 * Minimum;
                }

                return new Degree(value);
            }

            /// <summary>
            /// Subtracts <see cref="Degree"/> and <see cref="Degree"/>.
            /// </summary>
            /// <param name="left"></param>
            /// <param name="right"></param>
            /// <returns>
            /// <see cref="Degree"/> subtracted.
            /// </returns>
            public static Degree operator -(Degree left, Degree right)
            {
                return left + (-right);
            }

            /// <summary>
            /// Checks if <see cref="Degree"/> and <see cref="Degree"/> are equal.
            /// </summary>
            /// <param name="left"></param>
            /// <param name="right"></param>
            /// <returns></returns>
            public static bool operator ==(Degree left, Degree right)
            {
                if (left.Equals(right))
                {
                    return true;
                }

                return MathF.Abs(left.value - right.value) < Tolerance;
            }

            /// <summary>
            /// Checks if <see cref="Degree"/> and <see cref="Degree"/> are not equal.
            /// </summary>
            /// <param name="left"></param>
            /// <param name="right"></param>
            /// <returns></returns>
            public static bool operator !=(Degree left, Degree right)
            {
                return !(left == right);
            }
        }

        #endregion
    }
}
