using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha.Conversion
{
    /// <summary>
    /// Implementation of <see cref="ISignal"/>.
    /// Describes information of <see cref="ISignal"/>.
    /// </summary>
    public sealed class Note :
        ISignal,
        IEquatable<Note>
    {
        /// <summary>
        /// Description for <see cref="ISignal"/>.
        /// </summary>
        public string Content { get; }

        /// <summary>
        /// Constructs an instance.
        /// </summary>
        /// <param name="content">
        /// Description for <see cref="ISignal"/>.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="content"/> is null.
        /// </exception>
        public Note(string content)
        {
            if (content == null)
            {
                throw new ArgumentNullException(nameof(content));
            }

            Content = content;
        }

        /// <inheritdoc/>
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
