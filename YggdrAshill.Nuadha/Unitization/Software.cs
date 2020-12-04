using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class Software<TSoftwareHandler> :
        ISoftware<TSoftwareHandler>
        where TSoftwareHandler : ISoftwareHandler
    {
        private readonly Func<TSoftwareHandler, IDisconnection> onConnected;

        #region Constructor

        public Software(Func<TSoftwareHandler, IDisconnection> onConnected)
        {
            if (onConnected == null)
            {
                throw new ArgumentNullException(nameof(onConnected));
            }

            this.onConnected = onConnected;
        }

        public Software()
        {
            onConnected = (_) =>
            {
                return new Disconnection();
            };
        }

        #endregion

        #region ISoftware

        public IDisconnection Connect(TSoftwareHandler handler)
        {
            return onConnected.Invoke(handler);
        }

        #endregion
    }
}
