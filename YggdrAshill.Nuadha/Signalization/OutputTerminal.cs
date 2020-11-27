using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class OutputTerminal<TSignal> :
        IOutputTerminal<TSignal>
        where TSignal : ISignal
    {
        private readonly Func<IInputTerminal<TSignal>, IDisconnection> onConnected;

        #region Constructor

        public OutputTerminal(Func<IInputTerminal<TSignal>, IDisconnection> onConnected)
        {
            if (onConnected == null)
            {
                throw new ArgumentNullException(nameof(onConnected));
            }

            this.onConnected = onConnected;
        }

        public OutputTerminal()
        {
            onConnected = (_) =>
            {
                return new Disconnection();
            };
        }

        #endregion

        #region IOutputTerminal

        public IDisconnection Connect(IInputTerminal<TSignal> terminal)
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
