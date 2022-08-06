using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Defines extensions for <see cref="IProduction{TSignal}"/>.
    /// </summary>
    public static class ProductionExtension
    {
        /// <summary>
        /// Sends <typeparamref name="TSignal"/> to <see cref="IConsumption{TSignal}"/>.
        /// </summary>
        /// <typeparam name="TSignal">
        /// Type of <see cref="ISignal"/> to produce.
        /// </typeparam>
        /// <param name="production">
        /// <see cref="IProduction{TSignal}"/> for <typeparamref name="TSignal"/>.
        /// </param>
        /// <param name="consumption">
        /// <see cref="Action{T}"/> for <typeparamref name="TSignal"/>.
        /// </param>
        /// <returns>
        /// <see cref="ICancellation"/> to cancel.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="production"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="consumption"/> is null.
        /// </exception>
        public static ICancellation Produce<TSignal>(this IProduction<TSignal> production, Action<TSignal> consumption)
            where TSignal : ISignal
        {
            if (production == null)
            {
                throw new ArgumentNullException(nameof(production));
            }
            if (consumption == null)
            {
                throw new ArgumentNullException(nameof(consumption));
            }

            return production.Produce(Consume<TSignal>.With(consumption));
        }
    }
}
