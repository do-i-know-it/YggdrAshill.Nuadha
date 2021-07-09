using YggdrAshill.Nuadha.Signalization;
using System;
using System.Collections.Generic;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Defines implementations for Signalization.
    /// </summary>
    public static class NotCached
    {
        #region Propagation

        /// <summary>
        /// Implementation of <see cref="IPropagation{TSignal}"/>.
        /// </summary>
        /// <typeparam name="TSignal">
        /// Type of <see cref="ISignal"/> to propagate.
        /// </typeparam>
        public sealed class Propagation<TSignal> :
            IPropagation<TSignal>
            where TSignal : ISignal
        {
            private readonly List<IConsumption<TSignal>> consumptionList = new List<IConsumption<TSignal>>();

            #region IProduction

            /// <inheritdoc/>
            public ICancellation Produce(IConsumption<TSignal> consumption)
            {
                if (consumption == null)
                {
                    throw new ArgumentNullException(nameof(consumption));
                }

                if (!consumptionList.Contains(consumption))
                {
                    consumptionList.Add(consumption);
                }

                return new Cancellation(() =>
                {
                    if (consumptionList.Contains(consumption))
                    {
                        consumptionList.Remove(consumption);
                    }
                });
            }

            #endregion

            #region IConsumption

            /// <inheritdoc/>
            public void Consume(TSignal signal)
            {
                foreach (var consumption in consumptionList)
                {
                    consumption.Consume(signal);
                }
            }

            #endregion

            #region IDisposable

            /// <inheritdoc/>
            public void Dispose()
            {
                consumptionList.Clear();
            }

            #endregion
        }

        #endregion

        #region Conduction

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

        #endregion
    }
}
