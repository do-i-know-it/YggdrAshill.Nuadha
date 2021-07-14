using System;

namespace YggdrAshill.Nuadha.Signalization
{
    /// <summary>
    /// Defines extensions for Signalization.
    /// </summary>
    public static class SignalizationExtension
    {
        /// <summary>
        /// Produces <typeparamref name="TSignal"/>.
        /// </summary>
        /// <typeparam name="TSignal">
        /// Type of <see cref="ISignal"/> to send.
        /// </typeparam>
        /// <param name="production">
        /// <see cref="IProduction{TSignal}"/> to produce.
        /// </param>
        /// <param name="consumption">
        /// <see cref="Action{T}"/> executed when this has consumed <typeparamref name="TSignal"/>.
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

            return production.Produce(new Consumption<TSignal>(consumption));
        }
        private sealed class Consumption<TSignal> :
            IConsumption<TSignal>
            where TSignal : ISignal
        {
            private readonly Action<TSignal> onConsumed;

            internal Consumption(Action<TSignal> onConsumed)
            {
                this.onConsumed = onConsumed;
            }

            /// <inheritdoc/>
            public void Consume(TSignal signal)
            {
                onConsumed.Invoke(signal);
            }
        }

        /// <summary>
        /// Converts <see cref="IPropagation{TSignal}"/> into <see cref="ITransmission{TSignal}"/>.
        /// </summary>
        /// <typeparam name="TSignal">
        /// Type of <see cref="ISignal"/> to emit.
        /// </typeparam>
        /// <param name="propagation">
        /// <see cref="IPropagation{TSignal}"/> to convert.
        /// </param>
        /// <param name="generation">
        /// <see cref="IGeneration{TSignal}"/> to generate.
        /// </param>
        /// <returns>
        /// <see cref="ITransmission{TSignal}"/> converted.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="propagation"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="generation"/> is null.
        /// </exception>
        public static ITransmission<TSignal> Transmit<TSignal>(this IPropagation<TSignal> propagation, IGeneration<TSignal> generation)
            where TSignal : ISignal
        {
            if (propagation == null)
            {
                throw new ArgumentNullException(nameof(propagation));
            }
            if (generation == null)
            {
                throw new ArgumentNullException(nameof(generation));
            }

            return new Transmission<TSignal>(propagation, generation);
        }
        private sealed class Transmission<TSignal> :
            ITransmission<TSignal>
            where TSignal : ISignal
        {
            private readonly IPropagation<TSignal> propagation;

            private readonly IGeneration<TSignal> generation;

            internal Transmission(IPropagation<TSignal> propagation, IGeneration<TSignal> generation)
            {
                this.propagation = propagation;

                this.generation = generation;
            }

            /// <inheritdoc/>
            public ICancellation Produce(IConsumption<TSignal> consumption)
            {
                if (consumption == null)
                {
                    throw new ArgumentNullException(nameof(consumption));
                }

                return propagation.Produce(consumption);
            }

            /// <inheritdoc/>
            public void Emit()
            {
                var gemerated = generation.Generate();

                propagation.Consume(gemerated);
            }

            /// <inheritdoc/>
            public void Dispose()
            {
                propagation.Dispose();
            }
        }

        /// <summary>
        /// Converts <see cref="IPropagation{TSignal}"/> into <see cref="ITransmission{TSignal}"/>.
        /// </summary>
        /// <typeparam name="TSignal">
        /// Type of <see cref="ISignal"/> to emit.
        /// </typeparam>
        /// <param name="propagation">
        /// <see cref="IPropagation{TSignal}"/> to convert.
        /// </param>
        /// <param name="generation">
        /// <see cref="Func{TResult}"/> to generate <typeparamref name="TSignal"/>.
        /// </param>
        /// <returns>
        /// <see cref="ITransmission{TSignal}"/> converted.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="propagation"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="generation"/> is null.
        /// </exception>
        public static ITransmission<TSignal> Transmit<TSignal>(this IPropagation<TSignal> propagation, Func<TSignal> generation)
            where TSignal : ISignal
        {
            if (propagation == null)
            {
                throw new ArgumentNullException(nameof(propagation));
            }
            if (generation == null)
            {
                throw new ArgumentNullException(nameof(generation));
            }

            return propagation.Transmit(new Generation<TSignal>(generation));
        }
        private sealed class Generation<TSignal> :
            IGeneration<TSignal>
            where TSignal : ISignal
        {
            private readonly Func<TSignal> onGenerated;

            internal Generation(Func<TSignal> onGenerated)
            {
                this.onGenerated = onGenerated;
            }

            /// <inheritdoc/>
            public TSignal Generate()
            {
                return onGenerated.Invoke();
            }
        }

        /// <summary>
        /// Collects <see cref="ICancellation"/> to cancel simultaneously.
        /// </summary>
        /// <param name="cancellation">
        /// <see cref="ICancellation"/> collected.
        /// </param>
        /// <param name="synthesized">
        /// <see cref="SynthesizedCancellation"/> to collect.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="cancellation"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="synthesized"/> is null.
        /// </exception>
        public static void Synthesize(this ICancellation cancellation, SynthesizedCancellation synthesized)
        {
            if (cancellation == null)
            {
                throw new ArgumentNullException(nameof(cancellation));
            }
            if (synthesized == null)
            {
                throw new ArgumentNullException(nameof(synthesized));
            }

            synthesized.Synthesize(cancellation);
        }
    }
}
