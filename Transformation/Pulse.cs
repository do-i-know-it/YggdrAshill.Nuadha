using YggdrAshill.Nuadha.Signalization;

namespace YggdrAshill.Nuadha.Transformation
{
    /// <summary>
    /// Implementation of <see cref="ISignal"/> for <see cref="Pulse"/>.
    /// </summary>
    public sealed class Pulse :
        ISignal
    {
        /// <summary>
        /// Only <see cref="Pulse"/> that exists.
        /// </summary>
        public static Pulse Instance { get; } = new Pulse();

        private Pulse()
        {

        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"{nameof(Pulse)}";
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return 0;
        }
    }
}
