using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using System;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Defines implementations of <see cref="IConversion{TInput, TOutput}"/>.
    /// </summary>
    public static class SignalInto
    {
        /// <summary>
        /// Converts <typeparamref name="TInput"/> into <typeparamref name="TOutput"/>.
        /// </summary>
        /// <typeparam name="TInput">
        /// Type of <see cref="ISignal"/> for input.
        /// </typeparam>
        /// <typeparam name="TOutput">
        /// Type of <see cref="ISignal"/> for output.
        /// </typeparam>
        /// <param name="conversion">
        /// <see cref="Func{T, TResult}"/> to convert <typeparamref name="TInput"/> into <typeparamref name="TOutput"/>.
        /// </param>
        /// <returns>
        /// <see cref="IConversion{TInput, TOutput}"/> created.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="conversion"/> is null.
        /// </exception>
        public static IConversion<TInput, TOutput> Signal<TInput, TOutput>(Func<TInput, TOutput> conversion)
            where TInput : ISignal
            where TOutput : ISignal
        {
            if (conversion == null)
            {
                throw new ArgumentNullException(nameof(conversion));
            }

            return new Conversion<TInput, TOutput>(conversion);
        }
        private sealed class Conversion<TInput, TOutput> :
            IConversion<TInput, TOutput>
            where TInput : ISignal
            where TOutput : ISignal
        {
            private readonly Func<TInput, TOutput> onConverted;

            internal Conversion(Func<TInput, TOutput> onConverted)
            {
                this.onConverted = onConverted;
            }

            /// <inheritdoc/>
            public TOutput Convert(TInput signal)
            {
                return onConverted.Invoke(signal);
            }
        }

        /// <summary>
        /// Converts each <typeparamref name="TInput"/> into <typeparamref name="TOutput"/> generated.
        /// </summary>
        /// <typeparam name="TInput">
        /// Type of <see cref="ISignal"/> for input.
        /// </typeparam>
        /// <typeparam name="TOutput">
        /// Type of <see cref="ISignal"/> for output.
        /// </typeparam>
        /// <param name="generation">
        /// <see cref="IGeneration{TSignal}"/> to generate <typeparamref name="TOutput"/>.
        /// </param>
        /// <returns>
        /// <see cref="IConversion{TInput, TOutput}"/> created.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="generation"/> is null.
        /// </exception>
        public static IConversion<TInput, TOutput> Signal<TInput, TOutput>(IGeneration<TOutput> generation)
            where TInput : ISignal
            where TOutput : ISignal
        {
            if (generation == null)
            {
                throw new ArgumentNullException(nameof(generation));
            }

            return Signal<TInput, TOutput>(_ => generation.Generate());
        }

        /// <summary>
        /// Converts each <typeparamref name="TInput"/> into <typeparamref name="TOutput"/> generated.
        /// </summary>
        /// <typeparam name="TInput">
        /// Type of <see cref="ISignal"/> for input.
        /// </typeparam>
        /// <typeparam name="TOutput">
        /// Type of <see cref="ISignal"/> for output.
        /// </typeparam>
        /// <param name="generation">
        /// <see cref="IGeneration{TSignal}"/> to generate <typeparamref name="TOutput"/>.
        /// </param>
        /// <returns>
        /// <see cref="IConversion{TInput, TOutput}"/> created.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="generation"/> is null.
        /// </exception>
        public static IConversion<TInput, TOutput> Signal<TInput, TOutput>(Func<TOutput> generation)
            where TInput : ISignal
            where TOutput : ISignal
        {
            if (generation == null)
            {
                throw new ArgumentNullException(nameof(generation));
            }

            return Signal<TInput, TOutput>(_ => generation.Invoke());
        }

        /// <summary>
        /// Converts each <typeparamref name="TInput"/> into constant <typeparamref name="TOutput"/>.
        /// </summary>
        /// <typeparam name="TInput">
        /// Type of <see cref="ISignal"/> for input.
        /// </typeparam>
        /// <typeparam name="TOutput">
        /// Type of <see cref="ISignal"/> for output.
        /// </typeparam>
        /// <param name="output">
        /// <typeparamref name="TOutput"/> converted.
        /// </param>
        /// <returns>
        /// <see cref="IConversion{TInput, TOutput}"/> created.
        /// </returns>
        public static IConversion<TInput, TOutput> Signal<TInput, TOutput>(TOutput output)
            where TInput : ISignal
            where TOutput : ISignal
        {
            return Signal<TInput, TOutput>(() => output);
        }
    }
}
