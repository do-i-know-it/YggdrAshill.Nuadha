using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha.Conversion
{
    /// <summary>
    /// Implementation of <see cref="ISignal"/>.
    /// Notifies that <see cref="ISignal"/> has been satisfied with condition.
    /// </summary>
    /// <remarks>
    /// <see cref="Pulse"/> is singleton.
    /// </remarks>
    public sealed class Pulse :
        ISignal,
        IEquatable<Pulse>
    {
        #region Singleton

        /// <summary>
        /// Gets singleton instance.
        /// </summary>
        public static Pulse Instance { get; }
            = new Pulse();

        private Pulse()
        {

        }

        #endregion

        #region IEquatable

        /// <inheritdoc/>
        public bool Equals(Pulse other)
        {
            return ReferenceEquals(this, other);
        }

        #endregion
    }
}
