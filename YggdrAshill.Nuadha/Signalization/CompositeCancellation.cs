using YggdrAshill.Nuadha.Signalization;
using System;
using System.Collections.Generic;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// <see cref="ICancellation"/> to execute each of synthesized <see cref="ICancellation"/> simultaneously.
    /// </summary>
    public sealed class CompositeCancellation :
        ICancellation,
        IDisposable
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

        /// <inheritdoc/>
        public void Dispose()
        {
            Cancel();
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
