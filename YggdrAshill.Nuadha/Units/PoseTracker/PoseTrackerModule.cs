using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Signals;
using YggdrAshill.Nuadha.Units;

namespace YggdrAshill.Nuadha
{
    public sealed class PoseTrackerModule :
        IPoseTrackerDevice,
        IPoseTrackerSystem,
        IDisconnection
    {
        private readonly Propagation<Position> position = new Propagation<Position>();

        private readonly Propagation<Rotation> rotation = new Propagation<Rotation>();

        #region IPoseTrackerSystem

        IConsumption<Position> IPoseTrackerSystem.Position => position;

        IConsumption<Rotation> IPoseTrackerSystem.Rotation => rotation;

        #endregion

        #region IPoseTrackerDevice

        IConnection<Position> IPoseTrackerDevice.Position => position;

        IConnection<Rotation> IPoseTrackerDevice.Rotation => rotation;

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
