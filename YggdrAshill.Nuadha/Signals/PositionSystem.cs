using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Translation;
using YggdrAshill.Nuadha.Signals;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class PositionSystem :
        IConnector<Position>
    {
        private readonly IConnector<Position> connector;

        private readonly IConnector<Position> position;

        public PositionSystem(Position offset)
        {
            connector = new Connector<Position>();

            position = new Connector<Position>();

            connector.Correct(Calibration.Position(() => offset)).Connect(position);
        }

        #region IInputTerminal

        public void Receive(Position signal)
        {
            connector.Receive(signal);
        }

        #endregion

        #region IOutputTerminal

        public IDisconnection Connect(IInputTerminal<Position> terminal)
        {
            if (terminal == null)
            {
                throw new ArgumentNullException(nameof(terminal));
            }

            return position.Connect(terminal);
        }

        #endregion

        #region IDisconnection

        public void Disconnect()
        {
            connector.Disconnect();

            position.Disconnect();
        }

        #endregion
    }
}
