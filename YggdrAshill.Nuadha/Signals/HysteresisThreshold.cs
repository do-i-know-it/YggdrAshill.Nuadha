using System;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Threshold to convert analog signal into digital signal.
    /// <see cref="HysteresisThreshold"/> has two threshold.
    /// </summary>
    public sealed class HysteresisThreshold
    {
        /// <summary>
        /// <see cref="Minimum"/> of <see cref="HysteresisThreshold"/>.
        /// </summary>
        public static float Minimum { get; } = 0.0f;

        /// <summary>
        /// <see cref="Maximum"/> of <see cref="HysteresisThreshold"/>.
        /// </summary>
        public static float Maximum { get; } = 1.0f;

        /// <summary>
        /// Lower threshold.
        /// </summary>
        public float Lower { get; }

        /// <summary>
        /// Upper threshold.
        /// </summary>
        public float Upper { get; }

        #region Constructor

        /// <summary>
        /// Constructs an instance.
        /// </summary>
        /// <param name="lower">
        /// Threshold for <see cref="Lower"/>.
        /// </param>
        /// <param name="upper">
        /// Threshold for <see cref="Upper"/>.
        /// </param>
        /// <exception cref="ArgumentException">
        /// Thrown if <paramref name="lower"/> is <see cref="float.NaN"/>.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown if <paramref name="upper"/> is <see cref="float.NaN"/>.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown if <paramref name="lower"/> is out of range between <see cref="Minimum"/> and <see cref="Maximum"/>.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown if <paramref name="upper"/> is out of range between <see cref="Minimum"/> and <see cref="Maximum"/>.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown if <paramref name="lower"/> is greater than <paramref name="upper"/>.
        /// </exception>
        public HysteresisThreshold(float lower, float upper)
        {
            if (float.IsNaN(upper))
            {
                throw new ArgumentException($"{nameof(upper)} is NaN.");
            }
            if (float.IsNaN(lower))
            {
                throw new ArgumentException($"{nameof(lower)} is NaN.");
            }

            if (lower < Minimum || Maximum < lower)
            {
                throw new ArgumentOutOfRangeException(nameof(lower));
            }
            if (upper < Minimum || Maximum < upper)
            {
                throw new ArgumentOutOfRangeException(nameof(upper));
            }
            if (upper < lower)
            {
                throw new ArgumentException($"{nameof(upper)} < {nameof(lower)}");
            }

            Lower = lower;

            Upper = upper;
        }

        /// <summary>
        /// Constructs an instance.
        /// </summary>
        /// <param name="threshold">
        /// Threshold for <see cref="Lower"/> and <see cref="Upper"/>.
        /// </param>
        /// <exception cref="ArgumentException">
        /// Thrown if <paramref name="threshold"/> is <see cref="float.NaN"/>.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown if <paramref name="threshold"/> is out of range between <see cref="Minimum"/> and <see cref="Maximum"/>.
        /// </exception>
        public HysteresisThreshold(float threshold = 0.5f)
        {
            if (float.IsNaN(threshold))
            {
                throw new ArgumentException($"{nameof(threshold)} is NaN.");
            }
            if (threshold < Minimum || Maximum < threshold)
            {
                throw new ArgumentOutOfRangeException(nameof(threshold));
            }

            Lower = threshold;

            Upper = threshold;
        }

        #endregion
    }
}
