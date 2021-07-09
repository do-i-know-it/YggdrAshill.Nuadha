using YggdrAshill.Nuadha.Transformation;
using System;

namespace YggdrAshill.Nuadha.Signals
{
    /// <summary>
    /// Converts <see cref="Pull"/> into <see cref="Push"/>.
    /// </summary>
    public sealed class PullToPush :
        IConversion<Pull, Push>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="threshold">
        /// <see cref="HysteresisThreshold"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="PullToPush"/> to convert.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="threshold"/> is null.
        /// </exception>
        public static PullToPush With(HysteresisThreshold threshold)
        {
            if (threshold == null)
            {
                throw new ArgumentNullException(nameof(threshold));
            }

            return new PullToPush(threshold);
        }

        private readonly HysteresisThreshold threshold;

        private bool previous = false;

        private PullToPush(HysteresisThreshold threshold)
        {
            if (threshold == null)
            {
                throw new ArgumentNullException(nameof(threshold));
            }

            this.threshold = threshold;
        }

        /// <inheritdoc/>
        public Push Convert(Pull signal)
        {
            if (previous)
            {
                previous = threshold.Lower <= (float)signal;
            }
            else
            {
                previous = threshold.Upper <= (float)signal;
            }

            return (Push)previous;
        }
    }
}
