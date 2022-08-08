using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha.Conduction
{
    /// <summary>
    /// Defines implementations of <see cref="IProduction{TSignal}"/> for <typeparamref name="TSignal"/>.
    /// </summary>
    /// <typeparam name="TSignal">
    /// Type of <see cref="ISignal"/> to produce.
    /// </typeparam>
    public static class Produce<TSignal>
        where TSignal : ISignal
    {
        /// <summary>
        /// Produces <typeparamref name="TSignal"/> like <paramref name="production"/>.
        /// </summary>
        /// <param name="production">
        /// <see cref="Func{T, TResult}"/> to produce <typeparamref name="TSignal"/>.
        /// </param>
        /// <returns>
        /// <see cref="IProduction{TSignal}"/> for <typeparamref name="TSignal"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="production"/> is null.
        /// </exception>
        public static IProduction<TSignal> Like(Func<IConsumption<TSignal>, ICancellation> production)
        {
            if (production == null)
            {
                throw new ArgumentNullException(nameof(production));
            }

            return new ProduceSignalLike(production);
        }
        private sealed class ProduceSignalLike :
            IProduction<TSignal>
        {
            private readonly Func<IConsumption<TSignal>, ICancellation> onProduced;

            public ProduceSignalLike(Func<IConsumption<TSignal>, ICancellation> onProduced)
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
