using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha.Transformation
{
    /// <summary>
    /// Defines implementations of <see cref="ITranslation{TInput, TOutput}"/>.
    /// </summary>
    public static class SignalInto
    {
        /// <summary>
        /// Executes <see cref="Func{T, TResult}"/>.
        /// </summary>
        /// <typeparam name="TInput">
        /// Type of <see cref="ISignal"/> to convert.
        /// </typeparam>
        /// <typeparam name="TOutput">
        /// Type of <see cref="ISignal"/> converted.
        /// </typeparam>
        /// <param name="translation">
        /// <see cref="Func{T, TResult}"/> to convert <typeparamref name="TInput"/> into <typeparamref name="TOutput"/>.
        /// </param>
        /// <returns>
        /// <see cref="ITranslation{TInput, TOutput}"/> created.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="translation"/> is null.
        /// </exception>
        public static ITranslation<TInput, TOutput> Signal<TInput, TOutput>(Func<TInput, TOutput> translation)
            where TInput : ISignal
            where TOutput : ISignal
        {
            if (translation == null)
            {
                throw new ArgumentNullException(nameof(translation));
            }

            return new Translation<TInput, TOutput>(translation);
        }
        private sealed class Translation<TInput, TOutput> :
            ITranslation<TInput, TOutput>
            where TInput : ISignal
            where TOutput : ISignal
        {
            private readonly Func<TInput, TOutput> onTranslated;

            internal Translation(Func<TInput, TOutput> onTranslated)
            {
                this.onTranslated = onTranslated;
            }

            public TOutput Translate(TInput signal)
            {
                return onTranslated.Invoke(signal);
            }
        }

        /// <summary>
        /// Executes none.
        /// </summary>
        /// <typeparam name="TSignal">
        /// Type of <see cref="ISignal"/> to convert.
        /// </typeparam>
        /// <returns>
        /// <see cref="ITranslation{TInput, TOutput}"/> created.
        /// </returns>
        public static ITranslation<TSignal, TSignal> None<TSignal>()
            where TSignal : ISignal
        {
            return Signal<TSignal, TSignal>(signal => signal);
        }
    }
}
