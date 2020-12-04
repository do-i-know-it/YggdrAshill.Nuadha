using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class Hardware<THardwareHandler> :
        IHardware<THardwareHandler>
        where THardwareHandler : IHardwareHandler
    {
        private readonly Func<THardwareHandler, IDisconnection> onConnected;

        #region Constructor

        public Hardware(Func<THardwareHandler, IDisconnection> onConnected)
        {
            if (onConnected == null)
            {
                throw new ArgumentNullException(nameof(onConnected));
            }

            this.onConnected = onConnected;
        }

        public Hardware()
        {
            onConnected = (_) =>
            {
                return new Disconnection();
            };
        }

        #endregion

        #region IHardware

        public IDisconnection Connect(THardwareHandler handler)
        {
            return onConnected.Invoke(handler);
        }

        #endregion
    }
}
