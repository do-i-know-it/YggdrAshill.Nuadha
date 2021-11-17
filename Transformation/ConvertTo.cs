using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha.Transformation
{
    /// <summary>
    /// Defines <see cref="IProduction{TSignal}"/> and <see cref="ICondition{TSignal}"/> for <see cref="ITranslation{TInput, TOutput}"/>.
    /// </summary>
    public static class ConvertTo
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
        /// <param name="translation">
        /// <see cref="ITranslation{TInput, TOutput}"/> to convert <typeparamref name="TInput"/> into <typeparamref name="TOutput"/>.
        /// </param>
        /// <param name="consumption">
        /// <see cref="IConsumption{TSignal}"/> to consume <typeparamref name="TOutput"/>.
        /// </param>
        /// <returns>
        /// <see cref="IConsumption{TSignal}"/> to consume <typeparamref name="TInput"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="translation"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="consumption"/> is null.
        /// </exception>
        public static IConsumption<TInput> Consume<TInput, TOutput>(ITranslation<TInput, TOutput> translation, IConsumption<TOutput> consumption)
            where TInput : ISignal
            where TOutput : ISignal
        {
            if (translation is null)
            {
                throw new ArgumentNullException(nameof(translation));
            }
            if (consumption is null)
            {
                throw new ArgumentNullException(nameof(consumption));
            }

            return new Consumption<TInput, TOutput>(translation, consumption);
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
        /// <see cref="IProduction{TSignal}"/> to produce <typeparamref name="TInput"/>.
        /// </param>
        /// <param name="translation">
        /// <see cref="ITranslation{TInput, TOutput}"/> to convert <typeparamref name="TInput"/> into <typeparamref name="TOutput"/>.
        /// </param>
        /// <returns>
        /// <see cref="IProduction{TSignal}"/> to produce <typeparamref name="TOutput"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="production"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="translation"/> is null.
        /// </exception>
        public static IProduction<TOutput> Produce<TInput, TOutput>(IProduction<TInput> production, ITranslation<TInput, TOutput> translation)
            where TInput : ISignal
            where TOutput : ISignal
        {
            if (production is null)
            {
                throw new ArgumentNullException(nameof(production));
            }
            if (translation is null)
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

                return production.Produce(Consume(translation, consumption));
            }
        }
    }
}
