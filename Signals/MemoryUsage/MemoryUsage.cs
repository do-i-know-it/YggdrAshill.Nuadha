using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha.Signals
{
    /// <summary>
    /// Implementation of <see cref="ISignal"/> for memory usage.
    /// </summary>
    public struct MemoryUsage :
        ISignal,
        IEquatable<MemoryUsage>
    {
        /// <summary>
        /// <see cref="float"/> of coefficient to convert byte into kilo byte.
        /// </summary>
        public const float ByteToKiloByte = 1 / 1000.0f;

        /// <summary>
        /// <see cref="float"/> of coefficient to convert kilo byte into mega byte.
        /// </summary>
        public const float KiloByteToMegaByte = 1 / 1000.0f;

        /// <summary>
        /// <see cref="float"/> of coefficient to convert byte into mega byte.
        /// </summary>
        public const float ByteToMegaByte = ByteToKiloByte * KiloByteToMegaByte;

        /// <summary>
        /// <see cref="long"/> of used <see cref="MemoryUsage"/> in byte.
        /// </summary>
        public long Used { get; }

        /// <summary>
        /// <see cref="long"/> of unused <see cref="MemoryUsage"/> in byte.
        /// </summary>
        public long Unused { get; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="used">
        /// <see cref="long"/> for <see cref="Used"/>.
        /// </param>
        /// <param name="unused">
        /// <see cref="long"/> for <see cref="Unused"/>.
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown if <paramref name="used"/> is negative.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown if <paramref name="unused"/> is negative.
        /// </exception>
        public MemoryUsage(long used, long unused)
        {
            if (used < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(used));
            }
            if (unused < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(unused));
            }

            Used = used;

            Unused = unused;
        }

        /// <summary>
        /// <see cref="long"/> of total <see cref="MemoryUsage"/> in byte.
        /// </summary>
        public long Total
            => Used + Unused;

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"{Total}";
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = 1985031587;
            hashCode = hashCode * -1521134295 + Used.GetHashCode();
            hashCode = hashCode * -1521134295 + Unused.GetHashCode();
            return hashCode;
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj is MemoryUsage signal)
            {
                return Equals(signal);
            }

            return false;
        }

        /// <inheritdoc/>
        public bool Equals(MemoryUsage other)
        {
            return Used.Equals(other.Used)
                && Unused.Equals(other.Unused);
        }

        /// <summary>
        /// Checks if <paramref name="left"/> and <paramref name="right"/> are equal.
        /// </summary>
        /// <param name="left">
        /// <see cref="MemoryUsage"/> to check.
        /// </param>
        /// <param name="right">
        /// <see cref="MemoryUsage"/> to check.
        /// </param>
        /// <returns>
        /// True if <paramref name="left"/> and <paramref name="right"/> are equal.
        /// </returns>
        public static bool operator ==(MemoryUsage left, MemoryUsage right)
        {
            if (left.Equals(right))
            {
                return true;
            }

            return left.Total.Equals(right.Total);
        }

        /// <summary>
        /// Checks if <paramref name="left"/> and <paramref name="right"/> are equal.
        /// </summary>
        /// <param name="left">
        /// <see cref="MemoryUsage"/> to check.
        /// </param>
        /// <param name="right">
        /// <see cref="MemoryUsage"/> to check.
        /// </param>
        /// <returns>
        /// True if <paramref name="left"/> and <paramref name="right"/> are not equal.
        /// </returns>
        public static bool operator !=(MemoryUsage left, MemoryUsage right)
        {
            return !(left == right);
        }
    }
}
