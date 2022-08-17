using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Conduction;
using System;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Defines extensions for <see cref="IProduction{TSignal}"/>.
    /// </summary>
    public static class ProductionExtension
    {
        /// <summary>
        /// Sends produced <typeparamref name="TSignal"/> to <paramref name="consumption"/>.
        /// </summary>
        /// <typeparam name="TSignal">
        /// Type of <see cref="ISignal"/> to produce.
        /// </typeparam>
        /// <param name="production">
        /// <see cref="IProduction{TSignal}"/> for <typeparamref name="TSignal"/>.
        /// </param>
        /// <param name="consumption">
        /// <see cref="Action{T}"/> to consume <typeparamref name="TSignal"/>.
        /// </param>
        /// <returns>
        /// <see cref="ICancellation"/> to cancel sending.
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

            return production.Produce(Consume<TSignal>.Like(consumption));
        }
    }
}
