using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Conduction;
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
        /// <see cref="ICancellation"/> to covert.
        /// </param>
        /// <returns>
        /// <see cref="IDisposable"/> converted.
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

            return new DisposeToCancel(cancellation);
        }
    }
}
