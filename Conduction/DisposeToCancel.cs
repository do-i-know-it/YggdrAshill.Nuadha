using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha.Conduction
{
    /// <summary>
    /// <see cref="IDisposable"/> to cancel.
    /// </summary>
    public sealed class DisposeToCancel :
        IDisposable
    {
        private readonly ICancellation cancellation;

        private bool disposed;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="cancellation">
        /// <see cref="ICancellation"/> to cancel.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="cancellation"/> is null.
        /// </exception>
        public DisposeToCancel(ICancellation cancellation)
        {
            if (cancellation == null)
            {
                throw new ArgumentNullException(nameof(cancellation));
            }

            this.cancellation = cancellation;
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            if (disposed)
            {
                throw new ObjectDisposedException(nameof(IDisposable));
            }

            cancellation.Cancel();

            disposed = true;
        }
    }
}
