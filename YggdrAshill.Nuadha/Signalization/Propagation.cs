using YggdrAshill.Nuadha.Signalization;
using System;
using System.Collections.Generic;

namespace YggdrAshill.Nuadha
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

        #region IConnection

        /// <inheritdoc/>
        public IDisconnection Connect(IConsumption<TSignal> consumption)
        {
            if (consumption == null)
            {
                throw new ArgumentNullException(nameof(consumption));
            }

            if (!consumptionList.Contains(consumption))
            {
                consumptionList.Add(consumption);
            }

            return new Disconnection(() =>
            {
                if (consumptionList.Contains(consumption))
                {
                    consumptionList.Remove(consumption);
                }
            });
        }

        #endregion

        #region IConsumption

        /// <summary>
        /// Propagates <typeparamref name="TSignal"/> to each connected <see cref="IConsumption{TSignal}"/>.
        /// </summary>
        /// <param name="signal">
        /// <see cref="ISignal"/> to propagate.
        /// </param>
        public void Consume(TSignal signal)
        {
            foreach (var consumption in consumptionList)
            {
                consumption.Consume(signal);
            }
        }

        #endregion

        #region IDisconnection

        /// <inheritdoc/>
        public void Disconnect()
        {
            consumptionList.Clear();
        }

        #endregion
    }
}
