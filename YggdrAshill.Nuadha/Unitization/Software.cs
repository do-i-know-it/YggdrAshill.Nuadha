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

        public Software(Func<TSoftwareHandler, IDisconnection> onConnected)
        {
            if (onConnected == null)
            {
                throw new ArgumentNullException(nameof(onConnected));
            }

            this.onConnected = onConnected;
        }

        public IDisconnection Connect(TSoftwareHandler handler)
        {
            return onConnected.Invoke(handler);
        }
    }
}
