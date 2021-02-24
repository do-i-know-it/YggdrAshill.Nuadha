using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Signals;
using YggdrAshill.Nuadha.Units;

namespace YggdrAshill.Nuadha
{
    public sealed class PoseTrackerModule :
        IPoseTrackerSoftware,
        IPoseTrackerHardware,
        IDisconnection
    {
        private readonly Propagation<Position> position = new Propagation<Position>();

        private readonly Propagation<Rotation> rotation = new Propagation<Rotation>();

        #region IPoseTrackerSoftware

        IConsumption<Position> IPoseTrackerSoftware.Position => position;

        IConsumption<Rotation> IPoseTrackerSoftware.Rotation => rotation;

        #endregion

        #region IPoseTrackerHardware

        IConnection<Position> IPoseTrackerHardware.Position => position;

        IConnection<Rotation> IPoseTrackerHardware.Rotation => rotation;

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
