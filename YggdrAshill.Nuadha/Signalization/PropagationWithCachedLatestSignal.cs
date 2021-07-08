using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Implementation of <see cref="IPropagation{TSignal}"/> with cached latest <typeparamref name="TSignal"/>.
    /// </summary>
    /// <typeparam name="TSignal">
    /// Type of <see cref="ISignal"/> to propagate.
    /// </typeparam>
    public sealed class PropagationWithCachedLatestSignal<TSignal> :
        IPropagation<TSignal>
        where TSignal : ISignal
    {
        private readonly Propagation<TSignal> propagation = new Propagation<TSignal>();

        private TSignal cached;

        /// <summary>
        /// Constructs an instance.
        /// </summary>
        /// <param name="initial">
        /// <typeparamref name="TSignal"/> to initialize.
        /// </param>
        public PropagationWithCachedLatestSignal(TSignal initial)
        {
            cached = initial;
        }

        #region IProduction

        /// <inheritdoc/>
        public ICancellation Produce(IConsumption<TSignal> consumption)
        {
            if (consumption == null)
            {
                throw new ArgumentNullException(nameof(consumption));
            }

            var cancellation = propagation.Produce(consumption);

            consumption.Consume(cached);

            return cancellation;
        }

        #endregion

        #region IConsumption

        /// <inheritdoc/>
        public void Consume(TSignal signal)
        {
            cached = signal;

            propagation.Consume(signal);
        }

        #endregion

        #region IDisposable

        /// <inheritdoc/>
        public void Dispose()
        {
            propagation.Dispose();
        }

        #endregion
    }
}
