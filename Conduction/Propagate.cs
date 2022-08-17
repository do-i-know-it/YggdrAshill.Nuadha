using YggdrAshill.Nuadha.Signalization;
using System;
using System.Collections.Generic;

namespace YggdrAshill.Nuadha.Conduction
{
    /// <summary>
    /// Defines implementations of <see cref="IPropagation{TSignal}"/>.
    /// </summary>
    /// <typeparam name="TSignal">
    /// Type of <see cref="ISignal"/> to propagate.
    /// </typeparam>
    public static class Propagate<TSignal>
        where TSignal : ISignal
    {
        /// <summary>
        /// Propagates <typeparamref name="TSignal"/> with <paramref name="consumptionList"/>.
        /// </summary>
        /// <param name="consumptionList">
        /// <see cref="IList{T}"/> of <see cref="IConsumption{TSignal}"/> for <typeparamref name="TSignal"/>.
        /// </param>
        /// <returns>
        /// <see cref="IPropagation{TSignal}"/> for <typeparamref name="TSignal"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="consumptionList"/> is null.
        /// </exception>
        public static IPropagation<TSignal> WithList(IList<IConsumption<TSignal>> consumptionList)
        {
            if (consumptionList == null)
            {
                throw new ArgumentNullException(nameof(consumptionList));
            }

            return new PropagateSignalWithList(consumptionList);
        }
        private sealed class PropagateSignalWithList :
            IPropagation<TSignal>
        {
            private readonly IList<IConsumption<TSignal>> consumptionList;

            public PropagateSignalWithList(IList<IConsumption<TSignal>> consumptionList)
            {
                this.consumptionList = consumptionList;
            }

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

                return Cancel.With(() =>
                {
                    if (consumptionList.Contains(consumption))
                    {
                        consumptionList.Remove(consumption);
                    }
                });
            }

            public void Consume(TSignal signal)
            {
                foreach (var consumption in consumptionList)
                {
                    consumption.Consume(signal);
                }
            }

            public void Dispose()
            {
                consumptionList.Clear();
            }
        }

        /// <summary>
        /// Propagates <typeparamref name="TSignal"/> with <see cref="IList{T}"/> of <see cref="IConsumption{TSignal}"/> for <typeparamref name="TSignal"/>.
        /// </summary>
        /// <returns>
        /// <see cref="IPropagation{TSignal}"/> for <typeparamref name="TSignal"/>.
        /// </returns>
        public static IPropagation<TSignal> WithList()
        {
            return new PropagateSignalWithList(new List<IConsumption<TSignal>>());
        }
    }
}
