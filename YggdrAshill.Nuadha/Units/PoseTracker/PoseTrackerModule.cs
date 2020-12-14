using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Signals;
using YggdrAshill.Nuadha.Units;

namespace YggdrAshill.Nuadha
{
    public sealed class PoseTrackerModule :
        IPoseTrackerSoftwareHandler,
        IPoseTrackerHardwareHandler,
        IDisconnection
    {
        private readonly Connector<Position> position = new Connector<Position>();

        private readonly Connector<Rotation> rotation = new Connector<Rotation>();

        #region IPoseTrackerSoftwareHandler

        IOutputTerminal<Position> IPoseTrackerSoftwareHandler.Position => position;

        IOutputTerminal<Rotation> IPoseTrackerSoftwareHandler.Rotation => rotation;

        #endregion

        #region IPoseTrackerHardwareHandler

        IInputTerminal<Position> IPoseTrackerHardwareHandler.Position => position;

        IInputTerminal<Rotation> IPoseTrackerHardwareHandler.Rotation => rotation;

        #endregion

        #region IDisconnection

        public void Disconnect()
        {
            position.Disconnect();

            rotation.Disconnect();
        }

        #endregion
    }
}
