using YggdrAshill.Nuadha.Signalization;

namespace YggdrAshill.Nuadha.Transformation
{
    /// <summary>
    /// Implementation of <see cref="ISignal"/> <see cref="Notice"/>.
    /// </summary>
    public sealed class Notice :
        ISignal
    {
        /// <summary>
        /// Only <see cref="Notice"/> that exists.
        /// </summary>
        public static Notice Instance { get; } = new Notice();

        private Notice()
        {

        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"{nameof(Notice)}";
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return 0;
        }
    }
}
