using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Implementation of <see cref="IDisconnection"/>.
    /// </summary>
    public sealed class Disconnection :
        IDisconnection
    {
        private readonly Action onDisconnected;

        #region Constructor

        /// <summary>
        /// Constructs an instance.
        /// </summary>
        /// <param name="onDisconnected">
        /// <see cref="Action"/> to execute when this has disconnected.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="onDisconnected"/> is null.
        /// </exception>
        public Disconnection(Action onDisconnected)
        {
            if (onDisconnected == null)
            {
                throw new ArgumentNullException(nameof(onDisconnected));
            }

            this.onDisconnected = onDisconnected;
        }

        /// <summary>
        /// Constructs an instance to do nothing when this has disconnected.
        /// </summary>
        public Disconnection()
        {
            onDisconnected = () =>
            {

            };
        }

        #endregion

        #region IDisconnection

        /// <inheritdoc/>
        public void Disconnect()
        {
            onDisconnected.Invoke();
        }

        #endregion
    }
}
