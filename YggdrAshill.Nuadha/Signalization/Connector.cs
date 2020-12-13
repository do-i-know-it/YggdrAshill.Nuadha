using YggdrAshill.Nuadha.Signalization;
using System;
using System.Collections.Generic;

namespace YggdrAshill.Nuadha
{
    public sealed class Connector<TSignal> :
        IConnector<TSignal>
        where TSignal : ISignal
    {
        private readonly OutputTerminal<TSignal> outputTerminal;

        private readonly InputTerminal<TSignal> inputTerminal;

        private readonly Disconnection disconnection;

        public Connector()
        {
            var terminalList = new List<IInputTerminal<TSignal>>();

            outputTerminal = new OutputTerminal<TSignal>(terminal =>
            {
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
            });

            inputTerminal = new InputTerminal<TSignal>(signal =>
            {
                foreach (var terminal in terminalList)
                {
                    terminal.Receive(signal);
                }
            });

            disconnection = new Disconnection(() =>
            {
                terminalList.Clear();
            });
        }

        #region IOutputTerminal

        public IDisconnection Connect(IInputTerminal<TSignal> terminal)
        {
            if (terminal == null)
            {
                throw new ArgumentNullException(nameof(terminal));
            }

            return outputTerminal.Connect(terminal);
        }

        #endregion

        #region IInputTerminal

        public void Receive(TSignal signal)
        {
            inputTerminal.Receive(signal);
        }

        #endregion

        #region IDisconnection

        public void Disconnect()
        {
            disconnection.Disconnect();
        }

        #endregion
    }
}
