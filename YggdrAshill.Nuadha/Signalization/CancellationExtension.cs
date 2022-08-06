using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Defines extensions for <see cref="ICancellation"/>.
    /// </summary>
    public static class CancellationExtension
    {
        /// <summary>
        /// Converts <see cref="ICancellation"/> to <see cref="IDisposable"/>.
        /// </summary>
        /// <param name="cancellation">
        /// <see cref="ICancellation"/>.
        /// </param>
        /// <returns>
        /// <see cref="IDisposable"/>
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="cancellation"/> is null.
        /// </exception>
        public static IDisposable ToDisposable(this ICancellation cancellation)
        {
            if (cancellation == null)
            {
                throw new ArgumentNullException(nameof(cancellation));
            }

            return new Disposable(cancellation);
        }
        private sealed class Disposable :
            IDisposable
        {
            private readonly ICancellation cancellation;

            private bool disposed;

            internal Disposable(ICancellation cancellation)
            {
                this.cancellation = cancellation;
            }

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
}
