using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class Ignitor :
        IIgnitor
    {
        private readonly Func<IEmission> onIgnited;

        #region Constructor

        public Ignitor(Func<IEmission> onIgnited)
        {
            if (onIgnited == null)
            {
                throw new ArgumentNullException(nameof(onIgnited));
            }

            this.onIgnited = onIgnited;
        }

        public Ignitor()
        {
            onIgnited = () =>
            {
                return new Emission();
            };
        }

        #endregion

        #region IIgnitor

        public IEmission Ignite()
        {
            return onIgnited.Invoke();
        }

        #endregion
    }
}
