using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha.Transformation
{
    /// <summary>
    /// Implementation of <see cref="ISignal"/> for pulse.
    /// </summary>
    public struct Pulse :
        ISignal,
        IEquatable<Pulse>
    {
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
