using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha.Signals
{
    /// <summary>
    /// Implementation of <see cref="ISignal"/> for <see cref="MemoryUsage"/>.
    /// </summary>
    public struct MemoryUsage :
        ISignal,
        IEquatable<MemoryUsage>
    {
        public const float ByteToKiloByte = 1 / 1000.0f;

        public const float KiloByteToMegaByte = 1 / 1000.0f;

        public const float ByteToMegaByte = ByteToKiloByte * KiloByteToMegaByte;

        /// <summary>
        /// <see cref="UsedSize"/> in byte.
        /// </summary>
        public long UsedSize { get; }

        /// <summary>
        /// <see cref="UnusedSize"/> in byte.
        /// </summary>
        public long UnusedSize { get; }

        /// <summary>
        /// Construcs instance.
        /// </summary>
        /// <param name="usedSize">
        /// <see cref="long"/> for <see cref="UsedSize"/> in byte.
        /// </param>
        /// <param name="unusedSize">
        /// <see cref="long"/> for <see cref="UnusedSize"/> in byte.
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown if <paramref name="usedSize"/> is negative.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown if <paramref name="unusedSize"/> is negative.
        /// </exception>
        public MemoryUsage(long usedSize, long unusedSize)
        {
            if (usedSize < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(usedSize));
            }
            if (unusedSize < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(unusedSize));
            }

            UsedSize = usedSize;

            UnusedSize = unusedSize;
        }

        /// <summary>
        /// <see cref="TotalSize"/> of <see cref="MemoryUsage"/>.
        /// </summary>
        public long TotalSize
            => UsedSize + UnusedSize;

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"{TotalSize}";
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = 1985031587;
            hashCode = hashCode * -1521134295 + UsedSize.GetHashCode();
            hashCode = hashCode * -1521134295 + UnusedSize.GetHashCode();
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
            return UsedSize.Equals(other.UsedSize)
                && UnusedSize.Equals(other.UnusedSize);
        }

        /// <summary>
        /// Checks if <see cref="MemoryUsage"/> and <see cref="MemoryUsage"/> are equal.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(MemoryUsage left, MemoryUsage right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Checks if <see cref="MemoryUsage"/> and <see cref="MemoryUsage"/> are not equal.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(MemoryUsage left, MemoryUsage right)
        {
            return !(left == right);
        }
    }
}
