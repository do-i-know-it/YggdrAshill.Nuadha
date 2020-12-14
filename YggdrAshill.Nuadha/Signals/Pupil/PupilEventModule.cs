using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Signals;
using YggdrAshill.Nuadha.Operation;

namespace YggdrAshill.Nuadha
{
    public sealed class PupilEventModule :
        IPupilEventInputHandler,
        IPupilEventOutputHandler,
        IDisconnection
    {
        private readonly Connector<Pulse> hasOpened = new Connector<Pulse>();
        
        private readonly Connector<Pulse> isOpened = new Connector<Pulse>();
        
        private readonly Connector<Pulse> hasClosed = new Connector<Pulse>();
        
        private readonly Connector<Pulse> isClosed = new Connector<Pulse>();

        #region IPupilEventInputHandler

        IInputTerminal<Pulse> IPupilEventInputHandler.HasOpened => hasOpened;

        IInputTerminal<Pulse> IPupilEventInputHandler.IsOpened => isOpened;

        IInputTerminal<Pulse> IPupilEventInputHandler.HasClosed => hasClosed;

        IInputTerminal<Pulse> IPupilEventInputHandler.IsClosed => isClosed;

        #endregion

        #region IPupilEventOutputHandler

        IOutputTerminal<Pulse> IPupilEventOutputHandler.HasOpened => hasOpened;

        IOutputTerminal<Pulse> IPupilEventOutputHandler.IsOpened => isOpened;

        IOutputTerminal<Pulse> IPupilEventOutputHandler.HasClosed => hasClosed;

        IOutputTerminal<Pulse> IPupilEventOutputHandler.IsClosed => isClosed;

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
