using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using System;

namespace YggdrAshill.Nuadha.Conduction
{
    /// <summary>
    /// Defines implementations of <see cref="IConversion{TInput, TOutput}"/> for <typeparamref name="TInput"/>.
    /// </summary>
    /// <typeparam name="TInput">
    /// Type of <see cref="ISignal"/> to convert.
    /// </typeparam>
    public static class From<TInput>
        where TInput : ISignal
    {
        /// <summary>
        /// Converts <typeparamref name="TInput"/> into <typeparamref name="TOutput"/>.
        /// </summary>
        /// <typeparam name="TOutput">
        /// Type of <see cref="ISignal"/> converted.
        /// </typeparam>
        public static class Into<TOutput>
            where TOutput : ISignal
        {
            /// <summary>
            /// Converts <typeparamref name="TInput"/> into <typeparamref name="TOutput"/> like <paramref name="conversion"/>.
            /// </summary>
            /// <param name="conversion">
            /// <see cref="Func{T, TResult}"/> to convert <typeparamref name="TInput"/> into <typeparamref name="TOutput"/>.
            /// </param>
            /// <returns>
            /// <see cref="IConversion{TInput, TOutput}"/> to convert <typeparamref name="TInput"/> into <typeparamref name="TOutput"/>.
            /// </returns>
            /// <exception cref="ArgumentNullException">
            /// Thrown if <paramref name="conversion"/> is null.
            /// </exception>
            public static IConversion<TInput, TOutput> Like(Func<TInput, TOutput> conversion)
            {
                if (conversion == null)
                {
                    throw new ArgumentNullException(nameof(conversion));
                }

                return new FromInputIntoOutputLike(conversion);
            }
            private sealed class FromInputIntoOutputLike :
                IConversion<TInput, TOutput>
            {
                private readonly Func<TInput, TOutput> onConverted;

                public FromInputIntoOutputLike(Func<TInput, TOutput> onConverted)
                {
                    this.onConverted = onConverted;
                }

                public TOutput Convert(TInput signal)
                {
                    return onConverted.Invoke(signal);
                }
            }

            /// <summary>
            /// Converts <typeparamref name="TInput"/> into <typeparamref name="TOutput"/> via <typeparamref name="TMedium"/>.
            /// </summary>
            /// <typeparam name="TMedium">
            /// Type of <see cref="ISignal"/> converted from <typeparamref name="TInput"/> to convert into <typeparamref name="TOutput"/>.
            /// </typeparam>
            /// <param name="inputToMedium">
            /// <see cref="IConversion{TInput, TOutput}"/> to convert <typeparamref name="TInput"/> into <typeparamref name="TMedium"/>.
            /// </param>
            /// <param name="mediumToOutput">
            /// <see cref="IConversion{TInput, TOutput}"/> to convert <typeparamref name="TMedium"/> into <typeparamref name="TOutput"/>.
            /// </param>
            /// <returns>
            /// <see cref="IConversion{TInput, TOutput}"/> to convert <typeparamref name="TInput"/> into <typeparamref name="TOutput"/>.
            /// </returns>
            /// <exception cref="ArgumentNullException">
            /// Thrown if <paramref name="inputToMedium"/> is null.
            /// </exception>
            /// <exception cref="ArgumentNullException">
            /// Thrown if <paramref name="mediumToOutput"/> is null.
            /// </exception>
            public static IConversion<TInput, TOutput> Via<TMedium>(IConversion<TInput, TMedium> inputToMedium, IConversion<TMedium, TOutput> mediumToOutput)
                where TMedium : ISignal
            {
                if (inputToMedium == null)
                {
                    throw new ArgumentNullException(nameof(inputToMedium));
                }
                if (mediumToOutput == null)
                {
                    throw new ArgumentNullException(nameof(mediumToOutput));
                }

                return new FromInputIntoOutputVia<TMedium>(inputToMedium, mediumToOutput);
            }
            private sealed class FromInputIntoOutputVia<TMedium> :
                IConversion<TInput, TOutput>
                where TMedium : ISignal
            {
                private readonly IConversion<TInput, TMedium> inputToMedium;

                private readonly IConversion<TMedium, TOutput> mediumToOutput;

                public FromInputIntoOutputVia(IConversion<TInput, TMedium> inputToMedium, IConversion<TMedium, TOutput> mediumToOutput)
                {
                    this.inputToMedium = inputToMedium;

                    this.mediumToOutput = mediumToOutput;
                }

                public TOutput Convert(TInput signal)
                {
                    var converted = inputToMedium.Convert(signal);

                    return mediumToOutput.Convert(converted);
                }
            }
        }
    }
}
