using YggdrAshill.Nuadha.Signalization;
using System;
using System.Collections.Generic;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Defines implementations of <see cref="IPropagation{TSignal}"/>.
    /// </summary>
    public static class Propagate
    {
        /// <summary>
        /// Propagates <typeparamref name="TSignal"/> without cache.
        /// </summary>
        /// <typeparam name="TSignal">
        /// Type of <see cref="ISignal"/> to propagate.
        /// </typeparam>
        /// <returns>
        /// <see cref="IPropagation{TSignal}"/> created.
        /// </returns>
        public static IPropagation<TSignal> WithoutCache<TSignal>()
            where TSignal : ISignal
        {
            return new NotCachedPropagation<TSignal>();
        }
        private sealed class NotCachedPropagation<TSignal> :
            IPropagation<TSignal>
            where TSignal : ISignal
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

            public void Dispose()
            {
                consumptionList.Clear();
            }
        }

        /// <summary>
        /// Propagates <typeparamref name="TSignal"/> with latest cache.
        /// </summary>
        /// <typeparam name="TSignal">
        /// Type of <see cref="ISignal"/> to propagate.
        /// </typeparam>
        /// <param name="generation">
        /// <see cref="IGeneration{TSignal}"/> to initialize cache of <typeparamref name="TSignal"/>.
        /// </param>
        /// <returns>
        /// <see cref="IPropagation{TSignal}"/> created.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="generation"/> is null.
        /// </exception>
        public static IPropagation<TSignal> WithLatestCache<TSignal>(IGeneration<TSignal> generation)
            where TSignal : ISignal
        {
            if (generation == null)
            {
                throw new ArgumentNullException(nameof(generation));
            }

            return new CachedPropagation<TSignal>(generation);
        }
        private sealed class CachedPropagation<TSignal> :
            IPropagation<TSignal>
            where TSignal : ISignal
        {
            private readonly NotCachedPropagation<TSignal> propagation = new NotCachedPropagation<TSignal>();

            private TSignal cached;

            internal CachedPropagation(IGeneration<TSignal> generation)
            {
                cached = generation.Generate();
            }

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

            public void Consume(TSignal signal)
            {
                cached = signal;

                propagation.Consume(signal);
            }

            public void Dispose()
            {
                propagation.Dispose();
            }
        }
    }
}
