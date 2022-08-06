using YggdrAshill.Nuadha.Signalization;
using System;
using System.Collections.Generic;

namespace YggdrAshill.Nuadha
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
        /// Propagates <typeparamref name="TSignal"/> without cache.
        /// </summary>
        /// <returns>
        /// <see cref="IPropagation{TSignal}"/> for <typeparamref name="TSignal"/>.
        /// </returns>
        public static IPropagation<TSignal> WithoutCache()
        {
            return new PropagateWithList();
        }
        private sealed class PropagateWithList :
            IPropagation<TSignal>
        {
            private readonly List<IConsumption<TSignal>> consumptionList = new List<IConsumption<TSignal>>();

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

                return Cancellation.Of(() =>
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
        }

        /// <summary>
        /// Propagates <typeparamref name="TSignal"/> with latest cache.
        /// </summary>
        /// <param name="signal">
        /// <typeparamref name="TSignal"/> for initiali cache.
        /// </param>
        /// <returns>
        /// <see cref="IPropagation{TSignal}"/> for <typeparamref name="TSignal"/>.
        /// </returns>
        public static IPropagation<TSignal> WithLatestCache(TSignal signal)
        {
            return new PropagateWithLatestCache(signal);
        }
        private sealed class PropagateWithLatestCache :
            IPropagation<TSignal>
        {
            private readonly PropagateWithList propagation = new PropagateWithList();

            private TSignal previous;

            internal PropagateWithLatestCache(TSignal signal)
            {
                previous = signal;
            }

            public ICancellation Produce(IConsumption<TSignal> consumption)
            {
                if (consumption == null)
                {
                    throw new ArgumentNullException(nameof(consumption));
                }

                var cancellation = propagation.Produce(consumption);

                consumption.Consume(previous);

                return cancellation;
            }

            public void Consume(TSignal signal)
            {
                previous = signal;

                propagation.Consume(signal);
            }
        }
    }
}
