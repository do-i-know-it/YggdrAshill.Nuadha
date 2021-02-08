using System;

namespace YggdrAshill.Nuadha
{
    public sealed class Disconnection :
        Signalization.IDisconnection,
        Conduction.IDisconnection
    {
        private readonly Action onDisconnected;

        #region Constructor

        public Disconnection(Action onDisconnected)
        {
            if (onDisconnected == null)
            {
                throw new ArgumentNullException(nameof(onDisconnected));
            }

            this.onDisconnected = onDisconnected;
        }

        public Disconnection()
        {
            onDisconnected = () =>
            {

            };
        }

        #endregion

        #region IDisconnection

        public void Disconnect()
        {
            onDisconnected.Invoke();
        }

        #endregion
    }
}
