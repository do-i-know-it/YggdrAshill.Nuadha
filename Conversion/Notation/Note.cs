using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha.Conversion
{
    public sealed class Note :
        ISignal,
        IEquatable<Note>
    {
        public string Content { get; }

        public Note(string content)
        {
            if (content == null)
            {
                throw new ArgumentNullException(nameof(content));
            }

            Content = content;
        }

        public bool Equals(Note other)
        {
            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return Content.Equals(other.Content);
        }
    }
}
