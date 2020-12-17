using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha.Translation
{
    public sealed class Pulse :
        ISignal,
        IEquatable<Pulse>
    {
        #region Singleton

        public static Pulse Instance { get; }
            = new Pulse();

        private Pulse()
        {

        }

        #endregion

        #region IEquatable

        public bool Equals(Pulse other)
        {
            return ReferenceEquals(this, other);
        }

        #endregion
    }
}
