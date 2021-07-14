using YggdrAshill.Nuadha.Signalization;
using System;
using System.Collections.Generic;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Implementation of <see cref="IPropagation{TSignal}"/>.
    /// </summary>
    public static class Propagation
    {
        public static class WithoutCache
        {
            /// <summary>
            /// Creates <see cref="IPropagation{TSignal}"/> without cache of <typeparamref name="TSignal"/>.
            /// </summary>
            /// <typeparam name="TSignal">
            /// Type of <see cref="ISignal"/> to propagate.
            /// </typeparam>
            /// <returns>
            /// <see cref="IPropagation{TSignal}"/> created.
            /// </returns>
            public static IPropagation<TSignal> Create<TSignal>()
                where TSignal : ISignal
            {
                return new Created<TSignal>();
            }
            private sealed class Created<TSignal> :
                IPropagation<TSignal>
                where TSignal : ISignal
            {
                private readonly List<IConsumption<TSignal>> consumptionList = new List<IConsumption<TSignal>>();

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

                /// <inheritdoc/>
                public void Consume(TSignal signal)
                {
                    foreach (var consumption in consumptionList)
                    {
                        consumption.Consume(signal);
                    }
                }

                /// <inheritdoc/>
                public void Dispose()
                {
                    consumptionList.Clear();
                }
            }
        }
        public static class WithLatestCache
        {
            /// <summary>
            /// Creates <see cref="IPropagation{TSignal}"/> with latest cache of <typeparamref name="TSignal"/>.
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
            public static IPropagation<TSignal> Create<TSignal>(IGeneration<TSignal> generation)
                where TSignal : ISignal
            {
                if (generation == null)
                {
                    throw new ArgumentNullException(nameof(generation));
                }

                return new Created<TSignal>(generation);
            }
            private sealed class Created<TSignal> :
                IPropagation<TSignal>
                where TSignal : ISignal
            {
                private readonly IPropagation<TSignal> propagation = WithoutCache.Create<TSignal>();

                private TSignal cached;

                internal Created(IGeneration<TSignal> generation)
                {
                    cached = generation.Generate();
                }

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

                /// <inheritdoc/>
                public void Consume(TSignal signal)
                {
                    cached = signal;

                    propagation.Consume(signal);
                }

                /// <inheritdoc/>
                public void Dispose()
                {
                    propagation.Dispose();
                }
            }
        }
    }
}
