using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Conduction;
using System;

namespace YggdrAshill.Nuadha.Signals
{
    /// <summary>
    /// Defines implementations of <see cref="IConversion{TInput, TOutput}"/> to convert <see cref="Note"/> into <see cref="Note"/>.
    /// </summary>
    public static class FromNoteIntoNote
    {
        /// <summary>
        /// Converts <see cref="Note"/> into <see cref="Note"/> like <paramref name="conversion"/>.
        /// </summary>
        /// <param name="conversion">
        /// <see cref="Func{T, TResult}"/> to convert <see cref="string"/> into <see cref="string"/>.
        /// </param>
        /// <returns>
        /// <see cref="IConversion{TInput, TOutput}"/> to convert <see cref="Note"/> into <see cref="Note"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="conversion"/> is null.
        /// </exception>
        public static IConversion<Note, Note> Like(Func<string, string> conversion)
        {
            if (conversion == null)
            {
                throw new ArgumentNullException(nameof(conversion));
            }

            return From<Note>.Into<Note>.Like(signal => (Note)conversion.Invoke((string)signal));
        }
    }
}
