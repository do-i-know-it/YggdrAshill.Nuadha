using YggdrAshill.Nuadha.Signalization;
using System;
using System.Collections.Generic;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Collects <see cref="ICancellation"/> to cancel simultaneously.
    /// </summary>
    public sealed class SynthesizedCancellation :
        ICancellation
    {
        private readonly List<ICancellation> cancellationList = new List<ICancellation>();

        /// <inheritdoc/>
        public void Cancel()
        {
            foreach (var cancellation in cancellationList)
            {
                cancellation.Cancel();
            }

            cancellationList.Clear();
        }

        /// <summary>
        /// Collects <see cref="ICancellation"/>.
        /// </summary>
        /// <param name="cancellation">
        /// <see cref="ICancellation"/> to collect.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="cancellation"/> is null.
        /// </exception>
        public void Synthesize(ICancellation cancellation)
        {
            if (cancellation == null)
            {
                throw new ArgumentNullException(nameof(cancellation));
            }

            if (cancellationList.Contains(cancellation))
            {
                return;
            }

            cancellationList.Add(cancellation);
        }
    }
}
