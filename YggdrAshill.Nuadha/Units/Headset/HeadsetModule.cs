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
        private readonly Connector<Direction> direction = new Connector<Direction>();

        private readonly PoseTrackerModule poseTracker = new PoseTrackerModule();
        
        private readonly EyeTrackerModule leftEye = new EyeTrackerModule();

        private readonly EyeTrackerModule rightEye = new EyeTrackerModule();

        #region IHeadsetSoftwareHandler

        IOutputTerminal<Direction> IHeadsetSoftwareHandler.Direction => direction;

        IPoseTrackerSoftwareHandler IHeadsetSoftwareHandler.PoseTracker => poseTracker;

        IEyeTrackerSoftwareHandler IHeadsetSoftwareHandler.LeftEye => leftEye;

        IEyeTrackerSoftwareHandler IHeadsetSoftwareHandler.RightEye => rightEye;

        #endregion

        #region IHeadsetHardwareHandler

        IInputTerminal<Direction> IHeadsetHardwareHandler.Direction => direction;

        IPoseTrackerHardwareHandler IHeadsetHardwareHandler.PoseTracker => poseTracker;

        IEyeTrackerHardwareHandler IHeadsetHardwareHandler.LeftEye => leftEye;

        IEyeTrackerHardwareHandler IHeadsetHardwareHandler.RightEye => rightEye;

        #endregion

        #region IDisconnection

        public void Disconnect()
        {
            direction.Disconnect();
            
            poseTracker.Disconnect();

            leftEye.Disconnect();

            rightEye.Disconnect();
        }

        #endregion
    }
}
