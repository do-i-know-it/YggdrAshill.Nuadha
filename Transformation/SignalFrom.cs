using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha.Transformation
{
    /// <summary>
    /// Defines implementation of <see cref="ITranslation{TInput, TOutput}"/> for operation.
    /// </summary>
    public static class SignalFrom
    {
        /// <summary>
        /// Converts <typeparamref name="TInput"/> into <typeparamref name="TOutput"/> through <typeparamref name="TMedium"/>.
        /// </summary>
        /// <typeparam name="TInput">
        /// Type of <see cref="ISignal"/> to convert.
        /// </typeparam>
        /// <typeparam name="TMedium">
        /// Type of <see cref="ISignal"/> converted from <typeparamref name="TInput"/> to convert.
        /// </typeparam>
        /// <typeparam name="TOutput">
        /// Type of <see cref="ISignal"/> converted from <typeparamref name="TMedium"/>.
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
        public static ITranslation<TInput, TOutput> Transited<TInput, TMedium, TOutput>(ITranslation<TInput, TMedium> inputToMedium, ITranslation<TMedium, TOutput> mediumToOutput)
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

            return new TranslateToTransit<TInput, TMedium, TOutput>(inputToMedium, mediumToOutput);
        }
        private sealed class TranslateToTransit<TInput, TMedium, TOutput> :
            ITranslation<TInput, TOutput>
            where TInput : ISignal
            where TMedium : ISignal
            where TOutput : ISignal
        {
            private readonly ITranslation<TInput, TMedium> inputToMedium;

            private readonly ITranslation<TMedium, TOutput> mediumToOutput;

            internal TranslateToTransit(ITranslation<TInput, TMedium> inputToMedium, ITranslation<TMedium, TOutput> mediumToOutput)
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
