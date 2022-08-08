using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha.Transformation
{
    /// <summary>
    /// Produces <typeparamref name="TOutput"/> converted from <typeparamref name="TInput"/>.
    /// </summary>
    /// <typeparam name="TInput">
    /// Type of <see cref="ISignal"/> to convert.
    /// </typeparam>
    /// <typeparam name="TOutput">
    /// Type of <see cref="ISignal"/> converted.
    /// </typeparam>
    public sealed class ProduceToConvert<TInput, TOutput> :
        IProduction<TOutput>
        where TInput : ISignal
        where TOutput : ISignal
    {
        private readonly IProduction<TInput> production;

        private readonly IConversion<TInput, TOutput> conversion;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="production">
        /// <see cref="IProduction{TSignal}"/> for <typeparamref name="TInput"/>.
        /// </param>
        /// <param name="conversion">
        /// <see cref="IConversion{TInput, TOutput}"/> to convert <typeparamref name="TInput"/> into <typeparamref name="TOutput"/>.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="production"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="conversion"/> is null.
        /// </exception>
        public ProduceToConvert(IProduction<TInput> production, IConversion<TInput, TOutput> conversion)
        {
            if (production == null)
            {
                throw new ArgumentNullException(nameof(production));
            }
            if (conversion == null)
            {
                throw new ArgumentNullException(nameof(conversion));
            }

            this.production = production;

            this.conversion = conversion;
        }

        /// <summary>
        /// Produces <typeparamref name="TOutput"/> converted.
        /// </summary>
        /// <param name="consumption">
        /// <see cref="IConsumption{TSignal}"/> for <typeparamref name="TOutput"/> converted from <typeparamref name="TInput"/>.
        /// </param>
        /// <returns>
        /// <see cref="ICancellation"/> to cancel sending.
        /// </returns>
        public ICancellation Produce(IConsumption<TOutput> consumption)
        {
            if (consumption == null)
            {
                throw new ArgumentNullException(nameof(consumption));
            }

            return production.Produce(new ConsumeToConvert<TInput, TOutput>(conversion, consumption));
        }
    }
}
