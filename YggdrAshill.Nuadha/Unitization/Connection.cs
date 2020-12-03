using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class Connection<THandler> :
        IConnection<THandler>
        where THandler : IHandler
    {
        private readonly Func<THandler, IDisconnection> onConnected;

        #region Constructor

        public Connection(Func<THandler, IDisconnection> onConnected)
        {
            if (onConnected == null)
            {
                throw new ArgumentNullException(nameof(onConnected));
            }

            this.onConnected = onConnected;
        }

        public Connection()
        {
            onConnected = (_) =>
            {
                return new Disconnection();
            };
        }

        #endregion

        #region IConnection

        public IDisconnection Connect(THandler handler)
        {
            return onConnected.Invoke(handler);
        }

        #endregion
    }
}
