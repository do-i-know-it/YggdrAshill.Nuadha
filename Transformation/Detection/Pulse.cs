using YggdrAshill.Nuadha.Signalization;

namespace YggdrAshill.Nuadha.Transformation
{
    /// <summary>
    /// Implementation of <see cref="ISignal"/> for pulse.
    /// </summary>
    public sealed class Pulse :
        ISignal
    {
        /// <summary>
        /// <see cref="Pulse"/> that only exists.
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
