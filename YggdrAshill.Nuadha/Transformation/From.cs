using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using System;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Defines implementations of <see cref="ITranslation{TInput, TOutput}"/> for <typeparamref name="TInput"/>.
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
        /// <param name="translation">
        /// <see cref="Func{T, TResult}"/> to convert <typeparamref name="TInput"/> into <typeparamref name="TOutput"/>.
        /// </param>
        /// <returns>
        /// <see cref="ITranslation{TInput, TOutput}"/> to convert <typeparamref name="TInput"/> into <typeparamref name="TOutput"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="translation"/> is null.
        /// </exception>
        public static ITranslation<TInput, TOutput> Into<TOutput>(Func<TInput, TOutput> translation)
            where TOutput : ISignal
        {
            if (translation == null)
            {
                throw new ArgumentNullException(nameof(translation));
            }

            return new SignalInto<TOutput>(translation);
        }
        private sealed class SignalInto<TOutput> :
            ITranslation<TInput, TOutput>
            where TOutput : ISignal
        {
            private readonly Func<TInput, TOutput> onTranslated;

            internal SignalInto(Func<TInput, TOutput> onTranslated)
            {
                this.onTranslated = onTranslated;
            }

            public TOutput Translate(TInput signal)
            {
                return onTranslated.Invoke(signal);
            }
        }
    }
}
