using YggdrAshill.Nuadha.Signalization.Experimental;
using System;

namespace YggdrAshill.Nuadha.Experimental
{
    /// <summary>
    /// Implementation of <see cref="IConduction{TSignal}"/>.
    /// </summary>
    /// <typeparam name="TSignal">
    /// Type of <see cref="ISignal"/> to conduct.
    /// </typeparam>
    public sealed class Conduction<TSignal> :
        IConduction<TSignal>
        where TSignal : ISignal
    {
        private readonly Propagation<TSignal> propagation = new Propagation<TSignal>();

        private readonly Func<TSignal> onEmitted;

        /// <summary>
        /// Constructs an instance.
        /// </summary>
        /// <param name="onEmitted">
        /// <see cref="Func{TSignal}"/> to execute when this has emitted.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="onEmitted"/> is null.
        /// </exception>
        public Conduction(Func<TSignal> onEmitted)
        {
            if (onEmitted == null)
            {
                throw new ArgumentNullException(nameof(onEmitted));
            }

            this.onEmitted = onEmitted;
        }

        #region IProduction

        /// <inheritdoc/>
        public ICancellation Produce(IConsumption<TSignal> consumption)
        {
            if (consumption == null)
            {
                throw new ArgumentNullException(nameof(consumption));
            }

            return propagation.Produce(consumption);
        }

        #endregion

        #region IEmission

        /// <inheritdoc/>
        public void Emit()
        {
            var emitted = onEmitted.Invoke();

            propagation.Consume(emitted);
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
