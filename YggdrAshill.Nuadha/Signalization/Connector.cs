using YggdrAshill.Nuadha.Signalization;
using System;
using System.Collections.Generic;

namespace YggdrAshill.Nuadha
{
    public sealed class Connector<TSignal> :
        IConnector<TSignal>
        where TSignal : ISignal
    {
        private readonly List<IInputTerminal<TSignal>> terminalList
            = new List<IInputTerminal<TSignal>>();

        #region IOutputTerminal

        public IDisconnection Connect(IInputTerminal<TSignal> terminal)
        {
            if (terminal == null)
            {
                throw new ArgumentNullException(nameof(terminal));
            }

            if (!terminalList.Contains(terminal))
            {
                terminalList.Add(terminal);
            }

            return new Disconnection(() =>
            {
                if (terminalList.Contains(terminal))
                {
                    terminalList.Remove(terminal);
                }
            });
        }

        #endregion

        #region IInputTerminal

        public void Receive(TSignal signal)
        {
            foreach (var terminal in terminalList)
            {
                terminal.Receive(signal);
            }
        }

        #endregion

        #region IDisconnection

        public void Disconnect()
        {
            terminalList.Clear();
        }

        #endregion
    }
}
