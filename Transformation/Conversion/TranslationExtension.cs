using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha.Transformation
{
    /// <summary>
    /// Defines extensions for <see cref="ITranslation{TInput, TOutput}"/>.
    /// </summary>
    public static class TranslationExtension
    {
        /// <summary>
        /// Creates <see cref="ITranslation{TInput, TOutput}"/>.
        /// </summary>
        /// <typeparam name="TInput">
        /// Type of <see cref="ISignal"/> to convert.
        /// </typeparam>
        /// <typeparam name="TMedium">
        /// Type of <see cref="ISignal"/> converted from <typeparamref name="TInput"/> in order to convert <typeparamref name="TOutput"/>.
        /// </typeparam>
        /// <typeparam name="TOutput">
        /// Type of <see cref="ISignal"/> converted.
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
        public static ITranslation<TInput, TOutput> Then<TInput, TMedium, TOutput>(this ITranslation<TInput, TMedium> inputToMedium, ITranslation<TMedium, TOutput> mediumToOutput)
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

            return new Translation<TInput, TMedium, TOutput>(inputToMedium, mediumToOutput);
        }
        private sealed class Translation<TInput, TMedium, TOutput> :
            ITranslation<TInput, TOutput>
            where TInput : ISignal
            where TMedium : ISignal
            where TOutput : ISignal
        {
            private readonly ITranslation<TInput, TMedium> inputToMedium;

            private readonly ITranslation<TMedium, TOutput> mediumToOutput;

            internal Translation(ITranslation<TInput, TMedium> inputToMedium, ITranslation<TMedium, TOutput> mediumToOutput)
            {
                this.inputToMedium = inputToMedium;

                this.mediumToOutput = mediumToOutput;
            }

            /// <inheritdoc/>
            public TOutput Translate(TInput signal)
            {
                var translated = inputToMedium.Translate(signal);

                return mediumToOutput.Translate(translated);
            }
        }
    }
}
