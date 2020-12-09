using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Signals;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class RotationSystem :
        IConnector<Rotation>
    {
        private readonly IConnector<Rotation> connector;

        private readonly IConnector<Rotation> rotation;

        public RotationSystem(Rotation offset)
        {
            connector = new Connector<Rotation>();

            rotation = new Connector<Rotation>();

            connector.Calibrate(RotationToRotation.Add, offset).Connect(rotation);
        }

        #region IInputTerminal

        public void Receive(Rotation signal)
        {
            connector.Receive(signal);
        }

        #endregion

        #region IOutputTerminal

        public IDisconnection Connect(IInputTerminal<Rotation> terminal)
        {
            if (terminal == null)
            {
                throw new ArgumentNullException(nameof(terminal));
            }

            return rotation.Connect(terminal);
        }

        #endregion

        #region IDisconnection

        public void Disconnect()
        {
            connector.Disconnect();

            rotation.Disconnect();
        }

        #endregion
    }
}
