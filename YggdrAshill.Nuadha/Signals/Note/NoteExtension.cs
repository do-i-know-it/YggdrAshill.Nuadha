using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Defines extensions for <see cref="Note"/>.
    /// </summary>
    public static class NoteExtension
    {
        /// <summary>
        /// Converts <see cref="string"/> to <see cref="Note"/>.
        /// </summary>
        /// <param name="string">
        /// <see cref="bool"/> to covert.
        /// </param>
        /// <returns>
        /// <see cref="Note"/> converted.
        /// </returns>
        public static Note ToNote(this string signal)
        {
            return (Note)signal;
        }
    }
}
