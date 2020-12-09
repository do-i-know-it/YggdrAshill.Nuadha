using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Signals;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class RotationSystem :
        IRotationSystem
    {
        private readonly IConnector<Rotation> connector = new Connector<Rotation>();

        private readonly Rotation offset;

        public RotationSystem(Rotation offset)
        {
            this.offset = offset;
        }

        #region IDivider

        public IDisconnection Connect(IOutputTerminal<Rotation> terminal)
        {
            if (terminal == null)
            {
                throw new ArgumentNullException(nameof(terminal));
            }

            return terminal.Calibrate(RotationToRotation.Add, offset).Connect(connector);
        }

        #endregion

        #region IOutputTerminal

        public IDisconnection Connect(IInputTerminal<Rotation> terminal)
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
