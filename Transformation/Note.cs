using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha.Transformation
{
    /// <summary>
    /// Implementation of <see cref="ISignal"/> for <see cref="Note"/>.
    /// </summary>
    public sealed class Note :
        ISignal,
        IEquatable<Note>
    {
        /// <summary>
        /// <see cref="None"/> of <see cref="Note"/>.
        /// </summary>
        public static Note None { get; } = new Note(string.Empty);

        private readonly string content;

        /// <summary>
        /// Constructs instance.
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
            if (ReferenceEquals(this, obj))
            {
                return true;
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
        /// Checks if one <see cref="Note"/> and another <see cref="Note"/> are equal.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(Note left, Note right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Checks if one <see cref="Note"/> and another <see cref="Note"/> are not equal.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(Note left, Note right)
        {
            return !(left == right);
        }
    }
}
