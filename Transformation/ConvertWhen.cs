using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha.Transformation
{
    /// <summary>
    /// Converts <typeparamref name="TInput"/> into <typeparamref name="TOutput"/>.
    /// </summary>
    /// <typeparam name="TInput">
    /// Type of <see cref="ISignal"/> to convert.
    /// </typeparam>
    /// <typeparam name="TOutput">
    /// Type of <see cref="ISignal"/> converted.
    /// </typeparam>
    public static class ConvertWhen<TInput, TOutput>
        where TInput : ISignal
        where TOutput : ISignal
    {
        /// <summary>
        /// Consumes <typeparamref name="TInput"/> to convert into <typeparamref name="TOutput"/>.
        /// </summary>
        /// <param name="translation">
        /// <see cref="ITranslation{TInput, TOutput}"/> to convert <typeparamref name="TInput"/> into <typeparamref name="TOutput"/>.
        /// </param>
        /// <param name="consumption">
        /// <see cref="IConsumption{TSignal}"/> for <typeparamref name="TOutput"/>.
        /// </param>
        /// <returns>
        /// <see cref="IConsumption{TSignal}"/> for <typeparamref name="TInput"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="translation"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="consumption"/> is null.
        /// </exception>
        public static IConsumption<TInput> IsConsumed(ITranslation<TInput, TOutput> translation, IConsumption<TOutput> consumption)
        {
            if (translation == null)
            {
                throw new ArgumentNullException(nameof(translation));
            }
            if (consumption == null)
            {
                throw new ArgumentNullException(nameof(consumption));
            }

            return new ConsumeToConvert(translation, consumption);
        }
        private sealed class ConsumeToConvert :
            IConsumption<TInput>
        {
            private readonly ITranslation<TInput, TOutput> translation;

            private readonly IConsumption<TOutput> consumption;

            internal ConsumeToConvert(ITranslation<TInput, TOutput> translation, IConsumption<TOutput> consumption)
            {
                this.translation = translation;

                this.consumption = consumption;
            }

            public void Consume(TInput signal)
            {
                var translated = translation.Translate(signal);

                consumption.Consume(translated);
            }
        }

        /// <summary>
        /// Produces <typeparamref name="TOutput"/> converted from <typeparamref name="TInput"/>.
        /// </summary>
        /// <param name="production">
        /// <see cref="IProduction{TSignal}"/> for <typeparamref name="TInput"/>.
        /// </param>
        /// <param name="translation">
        /// <see cref="ITranslation{TInput, TOutput}"/> to convert <typeparamref name="TInput"/> into <typeparamref name="TOutput"/>.
        /// </param>
        /// <returns>
        /// <see cref="IProduction{TSignal}"/> for <typeparamref name="TOutput"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="production"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="translation"/> is null.
        /// </exception>
        public static IProduction<TOutput> IsProduced(IProduction<TInput> production, ITranslation<TInput, TOutput> translation)
        {
            if (production == null)
            {
                throw new ArgumentNullException(nameof(production));
            }
            if (translation == null)
            {
                throw new ArgumentNullException(nameof(translation));
            }

            return new ProduceToConvert(production, translation);
        }
        private sealed class ProduceToConvert :
            IProduction<TOutput>
        {
            private readonly IProduction<TInput> production;

            private readonly ITranslation<TInput, TOutput> translation;

            internal ProduceToConvert(IProduction<TInput> production, ITranslation<TInput, TOutput> translation)
            {
                this.production = production;

                this.translation = translation;
            }

            public ICancellation Produce(IConsumption<TOutput> consumption)
            {
                if (consumption == null)
                {
                    throw new ArgumentNullException(nameof(consumption));
                }

                return production.Produce(IsConsumed(translation, consumption));
            }
        }
    }
}
