using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Signals;
using YggdrAshill.Nuadha.Units;

namespace YggdrAshill.Nuadha
{
    public sealed class HeadsetModule :
        IHeadsetSoftwareHandler,
        IHeadsetHardwareHandler,
        IDisconnection
    {
        private readonly Propagation<Direction> direction = new Propagation<Direction>();

        private readonly PoseTrackerModule poseTracker = new PoseTrackerModule();
        
        #region IHeadsetSoftwareHandler

        IConnection<Direction> IHeadsetSoftwareHandler.Direction => direction;

        IPoseTrackerSoftwareHandler IHeadsetSoftwareHandler.PoseTracker => poseTracker;

        #endregion

        #region IHeadsetHardwareHandler

        IConsumption<Direction> IHeadsetHardwareHandler.Direction => direction;

        IPoseTrackerHardwareHandler IHeadsetHardwareHandler.PoseTracker => poseTracker;

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
