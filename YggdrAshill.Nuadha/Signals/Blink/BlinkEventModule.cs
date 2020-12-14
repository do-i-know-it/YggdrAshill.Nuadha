using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Signals;
using YggdrAshill.Nuadha.Operation;

namespace YggdrAshill.Nuadha
{
    public sealed class BlinkEventModule :
        IBlinkEventInputHandler,
        IBlinkEventOutputHandler,
        IDisconnection
    {
        private readonly Connector<Pulse> hasOpened = new Connector<Pulse>();

        private readonly Connector<Pulse> isOpened = new Connector<Pulse>();

        private readonly Connector<Pulse> hasClosed = new Connector<Pulse>();

        private readonly Connector<Pulse> isClosed = new Connector<Pulse>();

        #region IBlinkEventInputHandler

        IInputTerminal<Pulse> IBlinkEventInputHandler.HasOpened => hasOpened;

        IInputTerminal<Pulse> IBlinkEventInputHandler.IsOpened => isOpened;

        IInputTerminal<Pulse> IBlinkEventInputHandler.HasClosed => hasClosed;

        IInputTerminal<Pulse> IBlinkEventInputHandler.IsClosed => isClosed;

        #endregion

        #region IBlinkEventOutputHandler

        IOutputTerminal<Pulse> IBlinkEventOutputHandler.HasOpened => hasOpened;

        IOutputTerminal<Pulse> IBlinkEventOutputHandler.IsOpened => isOpened;

        IOutputTerminal<Pulse> IBlinkEventOutputHandler.HasClosed => hasClosed;

        IOutputTerminal<Pulse> IBlinkEventOutputHandler.IsClosed => isClosed;

        #endregion

        #region IDisconnection

        public void Disconnect()
        {
            hasOpened.Disconnect();

            isOpened.Disconnect();

            hasClosed.Disconnect();

            isClosed.Disconnect();
        }

        #endregion
    }
}
