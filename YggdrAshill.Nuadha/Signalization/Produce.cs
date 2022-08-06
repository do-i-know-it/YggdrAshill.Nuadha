using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Defines implementations of <see cref="IProduction{TSignal}"/>.
    /// </summary>
    /// <typeparam name="TSignal">
    /// Type of <see cref="ISignal"/> to produce.
    /// </typeparam>
    public static class Produce<TSignal>
        where TSignal : ISignal
    {
        /// <summary>
        /// Sends <typeparamref name="TSignal"/> produced to <see cref="IConsumption{TSignal}"/>.
        /// </summary>
        /// <param name="production">
        /// <see cref="Func{T, TResult}"/> to produce.
        /// </param>
        /// <returns>
        /// <see cref="IProduction{TSignal}"/> for <typeparamref name="TSignal"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="production"/> is null.
        /// </exception>
        public static IProduction<TSignal> With(Func<IConsumption<TSignal>, ICancellation> production)
        {
            if (production == null)
            {
                throw new ArgumentNullException(nameof(production));
            }

            return new ProduceWithFunction(production);
        }
        private sealed class ProduceWithFunction :
            IProduction<TSignal>
        {
            private readonly Func<IConsumption<TSignal>, ICancellation> onProduced;

            internal ProduceWithFunction(Func<IConsumption<TSignal>, ICancellation> onProduced)
            {
                this.onProduced = onProduced;
            }

            public ICancellation Produce(IConsumption<TSignal> consumption)
            {
                if (consumption == null)
                {
                    throw new ArgumentNullException(nameof(consumption));
                }

                return onProduced.Invoke(consumption);
            }
        }
    }
}
