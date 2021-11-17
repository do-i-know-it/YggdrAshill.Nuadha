using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha.Transformation
{
    /// <summary>
    /// Defines implementation of <see cref="ITranslation{TInput, TOutput}"/> for <see cref="Transformation.Note"/>.
    /// </summary>
    public static class NoteOf
    {
        /// <summary>
        /// Notates <typeparamref name="TSignal"/>.
        /// </summary>
        /// <typeparam name="TSignal">
        /// Type of <see cref="ISignal"/> to notate.
        /// </typeparam>
        /// <param name="notation">
        /// <see cref="Func{T, TResult}"/> to notate <typeparamref name="TSignal"/>.
        /// </param>
        /// <returns>
        /// <see cref="ITranslation{TInput, TOutput}"/> to notate <typeparamref name="TSignal"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="notation"/> is null.
        /// </exception>
        public static ITranslation<TSignal, Note> Signal<TSignal>(Func<TSignal, string> notation)
            where TSignal : ISignal
        {
            if (notation == null)
            {
                throw new ArgumentNullException(nameof(notation));
            }

            return SignalInto.Signal<TSignal, Note>(signal =>
            {
                return (Note)notation.Invoke(signal);
            });
        }

        /// <summary>
        /// Notates <typeparamref name="TSignal"/> as <see cref="Transformation.Note.None"/>.
        /// </summary>
        /// <typeparam name="TSignal">
        /// Type of <see cref="ISignal"/> to notate.
        /// </typeparam>
        /// <returns>
        /// <see cref="ITranslation{TInput, TOutput}"/> to notate <typeparamref name="TSignal"/>.
        /// </returns>
        public static ITranslation<TSignal, Note> None<TSignal>()
            where TSignal : ISignal
        {
            return SignalInto.Signal<TSignal, Note>(_ => Transformation.Note.None);
        }

        /// <summary>
        /// Notates <see cref="Transformation.Note"/>.
        /// </summary>
        /// <param name="notation">
        /// <see cref="Func{T, TResult}"/> to notate <see cref="Transformation.Note"/>.
        /// </param>
        /// <returns>
        /// <see cref="ITranslation{TInput, TOutput}"/> to notate <see cref="Transformation.Note"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="notation"/> is null.
        /// </exception>
        public static ITranslation<Note, Note> Note(Func<string, string> notation)
        {
            if (notation == null)
            {
                throw new ArgumentNullException(nameof(notation));
            }

            return SignalInto.Signal<Note, Note>(signal =>
            {
                return notation.Invoke(signal.ToString()).ToNote();
            });
        }
    }
}
