using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha.Monitorization
{
    /// <summary>
    /// Implementation of <see cref="ISignal"/> for note.
    /// </summary>
    public sealed class Note :
        ISignal,
        IEquatable<Note>
    {
        /// <summary>
        /// Default <see cref="Note"/>.
        /// </summary>
        public static Note None { get; } = new Note(string.Empty);

        private readonly string content;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="content">
        /// <see cref="string"/> for <see cref="Note"/>.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="content"/> is null.
        /// </exception>
        public Note(string content)
        {
            if (content is null)
            {
                throw new ArgumentNullException(nameof(content));
            }

            this.content = content;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return content;
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return content.GetHashCode();
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null))
            {
                return false;
            }

            if (obj is Note value)
            {
                return Equals(value);
            }

            return false;
        }

        /// <inheritdoc/>
        public bool Equals(Note other)
        {
            return content.Equals(other.content);
        }

        /// <summary>
        /// Converts explicitly <see cref="string"/> to <see cref="Note"/>.
        /// </summary>
        /// <param name="signal">
        /// <see cref="string"/> to covert.
        /// </param>
        /// <returns>
        /// <see cref="Note"/> converted.
        /// </returns>
        public static explicit operator Note(string signal)
        {
            if (string.IsNullOrEmpty(signal))
            {
                return None;
            }

            return new Note(signal);
        }

        /// <summary>
        /// Converts explicitly <see cref="Note"/> to <see cref="string"/>.
        /// </summary>
        /// <param name="signal">
        /// <see cref="Note"/> to covert.
        /// </param>
        /// <returns>
        /// <see cref="string"/> converted.
        /// </returns>
        public static explicit operator string(Note signal)
        {
            return signal.content;
        }

        /// <summary>
        /// Checks if <paramref name="left"/> and <paramref name="right"/> are equal.
        /// </summary>
        /// <param name="left">
        /// <see cref="Note"/> to check.
        /// </param>
        /// <param name="right">
        /// <see cref="Note"/> to check.
        /// </param>
        /// <returns>
        /// True if <paramref name="left"/> and <paramref name="right"/> are equal.
        /// </returns>
        public static bool operator ==(Note left, Note right)
        {
            if (ReferenceEquals(left, null))
            {
                return ReferenceEquals(right, null);
            }

            if (ReferenceEquals(right, null))
            {
                return false;
            }

            return left.Equals(right);
        }

        /// <summary>
        /// Checks if <paramref name="left"/> and <paramref name="right"/> are equal.
        /// </summary>
        /// <param name="left">
        /// <see cref="Note"/> to check.
        /// </param>
        /// <param name="right">
        /// <see cref="Note"/> to check.
        /// </param>
        /// <returns>
        /// True if <paramref name="left"/> and <paramref name="right"/> are not equal.
        /// </returns>
        public static bool operator !=(Note left, Note right)
        {
            return !(left == right);
        }
    }
}
