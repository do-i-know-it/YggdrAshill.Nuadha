using System;
using System.Collections.Generic;

namespace YggdrAshill.Nuadha.Signalization
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

        internal void Synthesize(ICancellation cancellation)
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
