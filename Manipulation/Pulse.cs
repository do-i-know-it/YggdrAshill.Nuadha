using System;
using YggdrAshill.Nuadha.Signalization;

namespace YggdrAshill.Nuadha.Manipulation
{
    /// <summary>
    /// Implementation of <see cref="ISignal"/> for pulse.
    /// </summary>
    public readonly struct Pulse : ISignal, IEquatable<Pulse>
    {
        /// <summary>
        /// Default value of <see cref="Pulse"/>.
        /// </summary>
        public static Pulse Default { get; } = new();

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

        /// <inheritdoc/>
        public bool Equals(Pulse other)
        {
            return true;
        }
    }
}
