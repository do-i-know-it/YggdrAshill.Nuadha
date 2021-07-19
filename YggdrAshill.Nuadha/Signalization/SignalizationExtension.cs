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

            return production.Produce(Consumption.Of(consumption));
        }

        /// <summary>
        /// Creates <see cref="ITransmission{TSignal}"/>.
        /// </summary>
        /// <typeparam name="TSignal">
        /// Type of <see cref="ISignal"/> to transmit.
        /// </typeparam>
        /// <param name="propagation">
        /// <see cref="IPropagation{TSignal}"/> to propagate <typeparamref name="TSignal"/>.
        /// </param>
        /// <param name="generation">
        /// <see cref="Func{TResult}"/> to generate <typeparamref name="TSignal"/>.
        /// </param>
        /// <returns>
        /// <see cref="ITransmission{TSignal}"/> to transmit.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="propagation"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="generation"/> is null.
        /// </exception>
        public static ITransmission<TSignal> Transmit<TSignal>(this IPropagation<TSignal> propagation, Func<TSignal> generation)
            where TSignal : ISignal
        {
            if (propagation == null)
            {
                throw new ArgumentNullException(nameof(propagation));
            }
            if (generation == null)
            {
                throw new ArgumentNullException(nameof(generation));
            }

            return propagation.ToTransmit(Generation.Of(generation));
        }

        /// <summary>
        /// Collects <see cref="ICancellation"/> to cancel simultaneously.
        /// </summary>
        /// <param name="cancellation">
        /// <see cref="ICancellation"/> collected.
        /// </param>
        /// <param name="composite">
        /// <see cref="CompositeCancellation"/> to collect.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="cancellation"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="composite"/> is null.
        /// </exception>
        public static void Synthesize(this ICancellation cancellation, CompositeCancellation composite)
        {
            if (cancellation == null)
            {
                throw new ArgumentNullException(nameof(cancellation));
            }
            if (composite == null)
            {
                throw new ArgumentNullException(nameof(composite));
            }

            composite.Synthesize(cancellation);
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
}
