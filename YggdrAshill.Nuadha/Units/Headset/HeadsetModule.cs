using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Signals;
using YggdrAshill.Nuadha.Units;

namespace YggdrAshill.Nuadha
{
    public sealed class HeadsetModule :
        IHeadsetSoftware,
        IHeadsetHardware,
        IDisconnection
    {
        private readonly Propagation<Direction> direction = new Propagation<Direction>();

        private readonly PoseTrackerModule poseTracker = new PoseTrackerModule();

        #region IHeadsetSoftware

        IConsumption<Direction> IHeadsetSoftware.Direction => direction;

        IPoseTrackerSoftware IHeadsetSoftware.PoseTracker => poseTracker;

        #endregion

        #region IHeadsetHardware

        IConnection<Direction> IHeadsetHardware.Direction => direction;

        IPoseTrackerHardware IHeadsetHardware.PoseTracker => poseTracker;

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
