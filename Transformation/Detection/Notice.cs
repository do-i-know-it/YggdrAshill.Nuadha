using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha.Transformation
{
    /// <summary>
    /// Implementation of <see cref="ISignal"/>.
    /// </summary>
    public sealed class Notice :
        ISignal,
        IEquatable<Notice>
    {
        /// <summary>
        /// Singleton instance of <see cref="Notice"/>.
        /// </summary>
        public static Notice Instance { get; } = new Notice();

        private Notice()
        {

        }

        /// <inheritdoc/>
        public bool Equals(Notice other)
        {
            return ReferenceEquals(this, other);
        }
    }
}
