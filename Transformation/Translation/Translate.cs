using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha.Transformation
{
    /// <summary>
    /// Defines implementations of <see cref="ITranslation{TInput, TOutput}"/> to operate <see cref="ITranslation{TInput, TOutput}"/>.
    /// </summary>
    /// <typeparam name="TInput">
    /// Type of <see cref="ISignal"/> to convert.
    /// </typeparam>
    /// <typeparam name="TOutput">
    /// Type of <see cref="ISignal"/> converted.
    /// </typeparam>
    public static class Translate<TInput, TOutput>
        where TInput : ISignal
        where TOutput : ISignal
    {
        /// <summary>
        /// Converts <typeparamref name="TInput"/> into <typeparamref name="TOutput"/> through <typeparamref name="TMedium"/>.
        /// </summary>
        /// <typeparam name="TMedium">
        /// Type of <see cref="ISignal"/> converted from <typeparamref name="TInput"/> to convert into <typeparamref name="TOutput"/>.
        /// </typeparam>
        /// <param name="inputToMedium">
        /// <see cref="ITranslation{TInput, TOutput}"/> to convert <typeparamref name="TInput"/> into <typeparamref name="TMedium"/>.
        /// </param>
        /// <param name="mediumToOutput">
        /// <see cref="ITranslation{TInput, TOutput}"/> to convert <typeparamref name="TMedium"/> into <typeparamref name="TOutput"/>.
        /// </param>
        /// <returns>
        /// <see cref="ITranslation{TInput, TOutput}"/> to convert <typeparamref name="TInput"/> into <typeparamref name="TOutput"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="inputToMedium"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="mediumToOutput"/> is null.
        /// </exception>
        public static ITranslation<TInput, TOutput> Via<TMedium>(ITranslation<TInput, TMedium> inputToMedium, ITranslation<TMedium, TOutput> mediumToOutput)
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

            return new TranslateThrough<TMedium>(inputToMedium, mediumToOutput);
        }
        private sealed class TranslateThrough<TMedium> :
            ITranslation<TInput, TOutput>
            where TMedium : ISignal
        {
            private readonly ITranslation<TInput, TMedium> inputToMedium;

            private readonly ITranslation<TMedium, TOutput> mediumToOutput;

            internal TranslateThrough(ITranslation<TInput, TMedium> inputToMedium, ITranslation<TMedium, TOutput> mediumToOutput)
            {
                this.inputToMedium = inputToMedium;

                this.mediumToOutput = mediumToOutput;
            }

            public TOutput Translate(TInput signal)
            {
                var translated = inputToMedium.Translate(signal);

                return mediumToOutput.Translate(translated);
            }
        }
    }
}
