using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha.Operation
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

        #region Overrided function

        public override bool Equals(object obj)
        {
            if (obj is Pulse pulse)
            {
                return Equals(pulse);
            }

            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        #endregion

        #region Operator

        public static bool operator ==(Pulse left, Pulse right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Pulse left, Pulse right)
        {
            return !left.Equals(right);
        }

        #endregion
    }
}
