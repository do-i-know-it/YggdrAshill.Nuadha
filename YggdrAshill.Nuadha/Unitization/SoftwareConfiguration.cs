using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class SoftwareConfiguration<TSoftwareHandler> :
        ISoftwareConfiguration<TSoftwareHandler>
        where TSoftwareHandler : ISoftwareHandler
    {
        private readonly Func<TSoftwareHandler, IEmission> onConnected;

        #region Constructor

        public SoftwareConfiguration(Func<TSoftwareHandler, IEmission> onConnected)
        {
            if (onConnected == null)
            {
                throw new ArgumentNullException(nameof(onConnected));
            }

            this.onConnected = onConnected;
        }

        public SoftwareConfiguration()
        {
            onConnected = (_) =>
            {
                return new Emission();
            };
        }

        #endregion

        #region ISoftwareConfiguration

        public IEmission Connect(TSoftwareHandler handler)
        {
            return onConnected.Invoke(handler);
        }

        #endregion
    }
}
