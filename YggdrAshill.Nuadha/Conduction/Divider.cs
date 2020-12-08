using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Conduction;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class Divider<TSignal> :
        IDivider<TSignal>
        where TSignal : ISignal
    {
        private readonly Func<IOutputTerminal<TSignal>, IDisconnection> onConnected;

        #region Constructor

        public Divider(Func<IOutputTerminal<TSignal>, IDisconnection> onConnected)
        {
            if (onConnected == null)
            {
                throw new ArgumentNullException(nameof(onConnected));
            }

            this.onConnected = onConnected;
        }

        public Divider(Action<TSignal> onReceived)
        {
            if (onReceived == null)
            {
                throw new ArgumentNullException(nameof(onReceived));
            }

            onConnected = (terminal) =>
            {
                return terminal.Connect(new InputTerminal<TSignal>(onReceived));
            };
        }

        public Divider()
        {
            onConnected = (_) =>
            {
                return new Disconnection();
            };
        }

        #endregion

        #region IDivider

        public IDisconnection Connect(IOutputTerminal<TSignal> terminal)
        {
            if (terminal == null)
            {
                throw new ArgumentNullException(nameof(terminal));
            }

            return onConnected.Invoke(terminal);
        }

        #endregion
    }
}
