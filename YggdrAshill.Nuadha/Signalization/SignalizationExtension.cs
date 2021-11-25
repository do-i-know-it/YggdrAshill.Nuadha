using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Defines extensions for Signalization.
    /// </summary>
    public static class SignalizationExtension
    {
        /// <summary>
        /// Sends <typeparamref name="TSignal"/> to <see cref="IConsumption{TSignal}"/>.
        /// </summary>
        /// <typeparam name="TSignal">
        /// Type of <see cref="ISignal"/> to produce.
        /// </typeparam>
        /// <param name="production">
        /// <see cref="IProduction{TSignal}"/> to send <typeparamref name="TSignal"/>.
        /// </param>
        /// <param name="consumption">
        /// <see cref="Action{T}"/> to receive <typeparamref name="TSignal"/>.
        /// </param>
        /// <returns>
        /// <see cref="ICancellation"/> to cancel.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="production"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="consumption"/> is null.
        /// </exception>
        public static ICancellation Produce<TSignal>(this IProduction<TSignal> production, Action<TSignal> consumption)
            where TSignal : ISignal
        {
            if (production == null)
            {
                throw new ArgumentNullException(nameof(production));
            }
            if (consumption == null)
            {
                throw new ArgumentNullException(nameof(consumption));
            }

            return production.Produce(Consume.Signal(consumption));
        }

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
