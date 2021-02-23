using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Signals;
using YggdrAshill.Nuadha.Units;

namespace YggdrAshill.Nuadha
{
    public sealed class HeadsetModule :
        IHeadsetDevice,
        IHeadsetSystem,
        IDisconnection
    {
        private readonly Propagation<Direction> direction = new Propagation<Direction>();

        private readonly PoseTrackerModule poseTracker = new PoseTrackerModule();

        #region IHeadsetSystem

        IConsumption<Direction> IHeadsetSystem.Direction => direction;

        IPoseTrackerSystem IHeadsetSystem.PoseTracker => poseTracker;

        #endregion

        #region IHeadsetDevice

        IConnection<Direction> IHeadsetDevice.Direction => direction;

        IPoseTrackerDevice IHeadsetDevice.PoseTracker => poseTracker;

        #endregion

        #region IDisconnection

        public void Disconnect()
        {
            direction.Disconnect();
            
            poseTracker.Disconnect();
        }

        #endregion
    }
}
