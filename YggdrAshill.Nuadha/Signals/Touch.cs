using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha.Signals
{
    public struct Touch :
        ISignal,
        IEquatable<Touch>
    {
        public static Touch Enabled { get; } = new Touch(true);

        public static Touch Disabled { get; } = new Touch(false);

        private readonly bool occured;

        private Touch(bool occured)
        {
            this.occured = occured;
        }

        #region IEquatable as value object

        public override int GetHashCode()
        {
            return occured.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj is Touch touch)
            {
                return Equals(touch);
            }

            return false;
        }

        public bool Equals(Touch other)
        {
            return occured.Equals(other.occured);
        }

        public static bool operator ==(Touch left, Touch right)
        {
            return left.Equals(right);
        }
        public static bool operator !=(Touch left, Touch right)
        {
            return !(left == right);
        }

        #endregion
    }
}
