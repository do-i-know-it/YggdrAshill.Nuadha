using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha.Transformation
{
    /// <summary>
    /// Defines extensions to convert one <see cref="ISignal"/> into another <see cref="ISignal"/>.
    /// </summary>
    public static class ConversionExtension
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
        /// <param name="production">
        /// <see cref="IProduction{TSignal}"/> to send <typeparamref name="TInput"/>.
        /// </param>
        /// <param name="translation">
        /// <see cref="ITranslation{TInput, TOutput}"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="IProduction{TSignal}"/> to send <typeparamref name="TOutput"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="production"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="translation"/> is null.
        /// </exception>
        public static IProduction<TOutput> Convert<TInput, TOutput>(this IProduction<TInput> production, ITranslation<TInput, TOutput> translation)
            where TInput : ISignal
            where TOutput : ISignal
        {
            if (production == null)
            {
                throw new ArgumentNullException(nameof(production));
            }
            if (translation == null)
            {
                throw new ArgumentNullException(nameof(translation));
            }

            return new Production<TInput, TOutput>(production, translation);
        }
        private sealed class Production<TInput, TOutput> :
            IProduction<TOutput>
            where TInput : ISignal
            where TOutput : ISignal
        {
            private readonly IProduction<TInput> production;

            private readonly ITranslation<TInput, TOutput> translation;

            internal Production(IProduction<TInput> production, ITranslation<TInput, TOutput> translation)
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

                return production.Produce(new Consumption<TInput, TOutput>(translation, consumption));
            }
        }
        private sealed class Consumption<TInput, TOutput> :
            IConsumption<TInput>
            where TInput : ISignal
            where TOutput : ISignal
        {
            private readonly ITranslation<TInput, TOutput> translation;

            private readonly IConsumption<TOutput> consumption;

            internal Consumption(ITranslation<TInput, TOutput> translation, IConsumption<TOutput> consumption)
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
    }
}
