using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using System;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Defines extensions for <see cref="ITranslation{TInput, TOutput}"/>.
    /// </summary>
    public static class TranslationExtension
    {
        /// <summary>
        /// Converts <typeparamref name="TInput"/> into <typeparamref name="TMedium"/> before converting <typeparamref name="TMedium"/> into <typeparamref name="TOutput"/>.
        /// </summary>
        /// <typeparam name="TInput">
        /// Type of <see cref="ISignal"/> converted into <typeparamref name="TMedium"/>.
        /// </typeparam>
        /// <typeparam name="TMedium">
        /// Type of <see cref="ISignal"/> converted into <typeparamref name="TOutput"/>.
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

            return SignalTo.Transit(inputToMedium, mediumToOutput);
        }

        /// <summary>
        /// Converts <typeparamref name="TInput"/> into <typeparamref name="TMedium"/> before converting <typeparamref name="TMedium"/> into <typeparamref name="TOutput"/>.
        /// </summary>
        /// <typeparam name="TInput">
        /// Type of <see cref="ISignal"/> to convert.
        /// </typeparam>
        /// <typeparam name="TMedium">
        /// Type of <see cref="ISignal"/> converted from <typeparamref name="TInput"/> to be converted into <typeparamref name="TOutput"/>.
        /// </typeparam>
        /// <typeparam name="TOutput">
        /// Type of <see cref="ISignal"/> converted.
        /// </typeparam>
        /// <param name="inputToMedium">
        /// <see cref="ITranslation{TInput, TOutput}"/> to convert <typeparamref name="TInput"/> into <typeparamref name="TMedium"/>.
        /// </param>
        /// <param name="mediumToOutput">
        /// <see cref="Func{T, TResult}"/> to convert <typeparamref name="TMedium"/> into <typeparamref name="TOutput"/>.
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
        public static ITranslation<TInput, TOutput> Then<TInput, TMedium, TOutput>(this ITranslation<TInput, TMedium> inputToMedium, Func<TMedium, TOutput> mediumToOutput)
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

            return inputToMedium.Then(SignalInto.Signal(mediumToOutput));
        }
    }
}
