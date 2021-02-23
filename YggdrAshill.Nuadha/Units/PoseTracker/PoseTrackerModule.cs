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
        private readonly Propagation<Position> position = new Propagation<Position>();

        private readonly Propagation<Rotation> rotation = new Propagation<Rotation>();

        #region IPoseTrackerSoftwareHandler

        IConnection<Position> IPoseTrackerSoftwareHandler.Position => position;

        IConnection<Rotation> IPoseTrackerSoftwareHandler.Rotation => rotation;

        #endregion

        #region IPoseTrackerHardwareHandler

        IConsumption<Position> IPoseTrackerHardwareHandler.Position => position;

        IConsumption<Rotation> IPoseTrackerHardwareHandler.Rotation => rotation;

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
