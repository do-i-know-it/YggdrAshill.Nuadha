using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Conduction;
using System;

namespace YggdrAshill.Nuadha.Monitorization
{
    /// <summary>
    /// Defines implementations of <see cref="IConversion{TInput, TOutput}"/> for <see cref="Note"/>.
    /// </summary>
    /// <typeparam name="TSignal">
    /// Type of <see cref="ISignal"/> to convert.
    /// </typeparam>
    public static class IntoNoteFrom<TSignal>
        where TSignal : ISignal
    {
        /// <summary>
        /// Converts <typeparamref name="TSignal"/> into <see cref="Note"/> like <paramref name="conversion"/>.
        /// </summary>
        /// <param name="conversion">
        /// <see cref="Func{T, TResult}"/> to convert <typeparamref name="TSignal"/> into <see cref="string"/>.
        /// </param>
        /// <returns>
        /// <see cref="IConversion{TInput, TOutput}"/> to convert <typeparamref name="TSignal"/> into <see cref="Note"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="conversion"/> is null.
        /// </exception>
        public static IConversion<TSignal, Note> Like(Func<TSignal, string> conversion)
        {
            if (conversion == null)
            {
                throw new ArgumentNullException(nameof(conversion));
            }

            return From<TSignal>.Into<Note>.Like(signal => (Note)conversion.Invoke(signal));
        }
    }
}
