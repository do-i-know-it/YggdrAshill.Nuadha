using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha.Transformation
{
    /// <summary>
    /// Defines extensions for <see cref="IConversion{TInput, TOutput}"/>.
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
        /// <see cref="IProduction{TSignal}"/> for <typeparamref name="TInput"/> to convert.
        /// </param>
        /// <param name="conversion">
        /// <see cref="IConversion{TInput, TOutput}"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="IProduction{TSignal}"/> for <typeparamref name="TOutput"/> converted.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="production"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="conversion"/> is null.
        /// </exception>
        public static IProduction<TOutput> Convert<TInput, TOutput>(this IProduction<TInput> production, IConversion<TInput, TOutput> conversion)
            where TInput : ISignal
            where TOutput : ISignal
        {
            if (production == null)
            {
                throw new ArgumentNullException(nameof(production));
            }
            if (conversion == null)
            {
                throw new ArgumentNullException(nameof(conversion));
            }

            return new Production<TInput, TOutput>(production, conversion);
        }
        private sealed class Production<TInput, TOutput> :
            IProduction<TOutput>
            where TInput : ISignal
            where TOutput : ISignal
        {
            private readonly IProduction<TInput> production;

            private readonly IConversion<TInput, TOutput> conversion;

            internal Production(IProduction<TInput> production, IConversion<TInput, TOutput> conversion)
            {
                this.production = production;

                this.conversion = conversion;
            }

            /// <inheritdoc/>
            public ICancellation Produce(IConsumption<TOutput> consumption)
            {
                if (consumption == null)
                {
                    throw new ArgumentNullException(nameof(consumption));
                }

                return production.Produce(new Consumption<TInput, TOutput>(conversion, consumption));
            }
        }
        private sealed class Consumption<TInput, TOutput> :
            IConsumption<TInput>
            where TInput : ISignal
            where TOutput : ISignal
        {
            private readonly IConversion<TInput, TOutput> conversion;

            private readonly IConsumption<TOutput> consumption;

            internal Consumption(IConversion<TInput, TOutput> conversion, IConsumption<TOutput> consumption)
            {
                this.conversion = conversion;

                this.consumption = consumption;
            }

            /// <inheritdoc/>
            public void Consume(TInput signal)
            {
                var converted = conversion.Convert(signal);

                consumption.Consume(converted);
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
        /// <see cref="IProduction{TSignal}"/> for <typeparamref name="TInput"/> to convert.
        /// </param>
        /// <param name="conversion">
        /// <see cref="Func{T, TResult}"/> to convert <typeparamref name="TInput"/> into <typeparamref name="TOutput"/>.
        /// </param>
        /// <returns>
        /// <see cref="IProduction{TSignal}"/> for <typeparamref name="TOutput"/> converted.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="production"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="conversion"/> is null.
        /// </exception>
        public static IProduction<TOutput> Convert<TInput, TOutput>(this IProduction<TInput> production, Func<TInput, TOutput> conversion)
            where TInput : ISignal
            where TOutput : ISignal
        {
            if (production == null)
            {
                throw new ArgumentNullException(nameof(production));
            }
            if (conversion == null)
            {
                throw new ArgumentNullException(nameof(conversion));
            }

            return production.Convert(new Conversion<TInput, TOutput>(conversion));
        }
        private sealed class Conversion<TInput, TOutput> :
            IConversion<TInput, TOutput>
            where TInput : ISignal
            where TOutput : ISignal
        {
            private readonly Func<TInput, TOutput> onConverted;

            internal Conversion(Func<TInput, TOutput> onConverted)
            {
                if (onConverted == null)
                {
                    throw new ArgumentNullException(nameof(onConverted));
                }

                this.onConverted = onConverted;
            }

            /// <inheritdoc/>
            public TOutput Convert(TInput signal)
            {
                return onConverted.Invoke(signal);
            }
        }

        public static IConversion<TInput, TOutput> Then<TInput, TMedium, TOutput>(this IConversion<TInput, TMedium> inputToMedium, IConversion<TMedium, TOutput> mediumToOutput)
            where TInput : ISignal
            where TMedium : ISignal
            where TOutput : ISignal
        {
            if (inputToMedium == null)
            {
                throw new ArgumentNullException(nameof(inputToMedium));
            }
            if (mediumToOutput == null)
            {
                throw new ArgumentNullException(nameof(mediumToOutput));
            }

            return new Intermediate<TInput, TMedium, TOutput>(inputToMedium, mediumToOutput);
        }
        private sealed class Intermediate<TInput, TMedium, TOutput> :
            IConversion<TInput, TOutput>
            where TInput : ISignal
            where TMedium : ISignal
            where TOutput : ISignal
        {
            private readonly IConversion<TInput, TMedium> inputToMedium;

            private readonly IConversion<TMedium, TOutput> mediumToOutput;

            internal Intermediate(IConversion<TInput, TMedium> inputToMedium, IConversion<TMedium, TOutput> mediumToOutput)
            {
                this.inputToMedium = inputToMedium;

                this.mediumToOutput = mediumToOutput;
            }

            /// <inheritdoc/>
            public TOutput Convert(TInput signal)
            {
                var medium = inputToMedium.Convert(signal);

                return mediumToOutput.Convert(medium);
            }
        }
    }
}
