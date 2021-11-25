using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using System;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Defines implementations of <see cref="ITranslation{TInput, TOutput}"/>.
    /// </summary>
    public static class SignalInto
    {
        /// <summary>
        /// Converts <typeparamref name="TInput"/> into <typeparamref name="TOutput"/>.
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
        /// <see cref="ITranslation{TInput, TOutput}"/> to convert.
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

        public static ITranslation<TSignal, Note> Note<TSignal>(Func<TSignal, string> notation)
            where TSignal : ISignal
        {
            if (notation == null)
            {
                throw new ArgumentNullException(nameof(notation));
            }

            return new SignalToNote<TSignal>(notation);
        }
        private sealed class SignalToNote<TSignal> :
            ITranslation<TSignal, Note>
            where TSignal : ISignal
        {
            private readonly Func<TSignal, string> onTranslated;

            internal SignalToNote(Func<TSignal, string> onTranslated)
            {
                this.onTranslated = onTranslated;
            }

            public Note Translate(TSignal signal)
            {
                return onTranslated.Invoke(signal).ToNote();
            }
        }

        public static ITranslation<Note, Note> Note(Func<string, string> notation)
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
