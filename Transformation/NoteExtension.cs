namespace YggdrAshill.Nuadha.Transformation
{
    /// <summary>
    /// Defines extensions for <see cref="Note"/>.
    /// </summary>
    public static class NoteExtension
    {
        public static Note ToNote(this string signal)
        {
            if (signal is null)
            {
                signal = string.Empty;
            }

            return (Note)signal;
        }
    }
}
