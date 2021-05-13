using YggdrAshill.Nuadha.Signalization.Experimental;
using System;
using System.Collections.Generic;

namespace YggdrAshill.Nuadha.Experimental
{
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
}
