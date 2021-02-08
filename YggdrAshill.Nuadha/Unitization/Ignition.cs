using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class Ignition :
        IIgnition
    {
        private readonly Func<IEmission> onIgnited;

        #region Constructor

        public Ignition(Func<IEmission> onIgnited)
        {
            if (onIgnited == null)
            {
                throw new ArgumentNullException(nameof(onIgnited));
            }

            this.onIgnited = onIgnited;
        }

        public Ignition()
        {
            onIgnited = () =>
            {
                return new Emission();
            };
        }

        #endregion

        #region IIgnition

        public IEmission Ignite()
        {
            return onIgnited.Invoke();
        }

        #endregion
    }
}
