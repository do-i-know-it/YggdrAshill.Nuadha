using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha.Signals
{
    public struct Push :
        ISignal,
        IEquatable<Push>
    {
        public static Push Enabled { get; } = new Push(true);

        public static Push Disabled { get; } = new Push(false);

        private readonly bool signal;

        private Push(bool signal)
        {
            this.signal = signal;
        }

        public override string ToString()
        {
            return $"{signal}";
        }

        #region IEquatable as value object

        public override int GetHashCode()
        {
            return signal.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj is Push touch)
            {
                return Equals(touch);
            }

            return false;
        }

        public bool Equals(Push other)
        {
            return signal.Equals(other.signal);
        }

        public static bool operator ==(Push left, Push right)
        {
            return left.Equals(right);
        }
        public static bool operator !=(Push left, Push right)
        {
            return !(left == right);
        }

        #endregion
    }
}