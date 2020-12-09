using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Signals;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class PositionSystem :
        IPositionSystem
    {
        private readonly IConnector<Position> connector = new Connector<Position>();

        private readonly Position offset;

        public PositionSystem(Position offset)
        {
            this.offset = offset;
        }

        #region IDivider

        public IDisconnection Connect(IOutputTerminal<Position> terminal)
        {
            if (terminal == null)
            {
                throw new ArgumentNullException(nameof(terminal));
            }

            return terminal.Calibrate(PositionToPosition.Add, offset).Connect(connector);
        }

        #endregion

        #region IOutputTerminal

        public IDisconnection Connect(IInputTerminal<Position> terminal)
        {
            if (terminal == null)
            {
                throw new ArgumentNullException(nameof(terminal));
            }

            return connector.Connect(terminal);
        }

        #endregion

        #region IDisconnection

        public void Disconnect()
        {
            connector.Disconnect();
        }

        #endregion
    }
}
