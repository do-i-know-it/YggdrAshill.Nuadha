using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using System;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Defines implementations of <see cref="ITranslation{TInput, TOutput}"/> for <see cref="Note"/>.
    /// </summary>
    public static class IntoNote
    {
        /// <summary>
        /// Converts <typeparamref name="TSignal"/> into <see cref="Note"/>.
        /// </summary>
        /// <typeparam name="TInput">
        /// Type of <see cref="ISignal"/> to convert.
        /// </typeparam>
        /// <param name="notation">
        /// <see cref="Func{T, TResult}"/> to convert <typeparamref name="TSignal"/> into <see cref="string"/>.
        /// </param>
        /// <returns>
        /// <see cref="ITranslation{TInput, TOutput}"/> to notate.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="notation"/> is null.
        /// </exception>
        public static ITranslation<TSignal, Note> From<TSignal>(Func<TSignal, string> notation)
            where TSignal : ISignal
        {
            if (notation == null)
            {
                throw new ArgumentNullException(nameof(notation));
            }

            return new NoteFrom<TSignal>(notation);
        }
        private sealed class NoteFrom<TSignal> :
            ITranslation<TSignal, Note>
            where TSignal : ISignal
        {
            private readonly Func<TSignal, string> onTranslated;

            internal NoteFrom(Func<TSignal, string> onTranslated)
            {
                this.onTranslated = onTranslated;
            }

            public Note Translate(TSignal signal)
            {
                return onTranslated.Invoke(signal).ToNote();
            }
        }

        /// <summary>
        /// Converts <see cref="Note"/> into <see cref="Note"/>.
        /// </summary>
        /// <param name="notation">
        /// <see cref="Func{T, TResult}"/> to convert <see cref="string"/> into <see cref="string"/>.
        /// </param>
        /// <returns>
        /// <see cref="ITranslation{TInput, TOutput}"/> to notate.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="notation"/> is null.
        /// </exception>
        public static ITranslation<Note, Note> FromNote(Func<string, string> notation)
        {
            if (notation == null)
            {
                throw new ArgumentNullException(nameof(notation));
            }

            return new NoteToNote(notation);
        }
        private sealed class NoteToNote :
            ITranslation<Note, Note>
        {
            private readonly Func<string, string> onTranslated;

            internal NoteToNote(Func<string, string> onTranslated)
            {
                this.onTranslated = onTranslated;
            }

            public Note Translate(Note signal)
            {
                return onTranslated.Invoke(signal.ToString()).ToNote();
            }
        }
    }
}
