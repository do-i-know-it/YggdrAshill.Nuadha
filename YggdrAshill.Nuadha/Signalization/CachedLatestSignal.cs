using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Defines implementations for Signalization.
    /// </summary>
    public static class CachedLatestSignal
    {
        #region Propagation

        /// <summary>
        /// Implementation of <see cref="IPropagation{TSignal}"/> with cached latest <typeparamref name="TSignal"/>.
        /// </summary>
        /// <typeparam name="TSignal">
        /// Type of <see cref="ISignal"/> to propagate.
        /// </typeparam>
        public sealed class Propagation<TSignal> :
            IPropagation<TSignal>
            where TSignal : ISignal
        {
            private readonly NotCached.Propagation<TSignal> propagation = new NotCached.Propagation<TSignal>();

            private TSignal cached;

            /// <summary>
            /// Constructs an instance.
            /// </summary>
            /// <param name="initial">
            /// <typeparamref name="TSignal"/> to initialize.
            /// </param>
            public Propagation(TSignal initial)
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

        #endregion

        #region Conduction

        /// <summary>
        /// Implementation of <see cref="IConduction{TSignal}"/> with cached latest <typeparamref name="TSignal"/>.
        /// </summary>
        /// <typeparam name="TSignal">
        /// Type of <see cref="ISignal"/> to conduct.
        /// </typeparam>
        public sealed class Conduction<TSignal> :
            IConduction<TSignal>
            where TSignal : ISignal
        {
            private readonly Propagation<TSignal> propagation;

            private readonly Func<TSignal> onEmitted;

            /// <summary>
            /// Constructs an instance.
            /// </summary>
            /// <param name="onEmitted">
            /// <see cref="Func{TSignal}"/> to execute when this has emitted.
            /// </param>
            /// <param name="initial">
            /// <typeparamref name="TSignal"/> to initialize.
            /// </param>
            /// <exception cref="ArgumentNullException">
            /// Thrown if <paramref name="onEmitted"/> is null.
            /// </exception>
            public Conduction(Func<TSignal> onEmitted, TSignal initial)
            {
                if (onEmitted == null)
                {
                    throw new ArgumentNullException(nameof(onEmitted));
                }

                this.onEmitted = onEmitted;

                propagation = new Propagation<TSignal>(initial);
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

        #endregion
    }
}
