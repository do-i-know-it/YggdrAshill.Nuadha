using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Units;

namespace YggdrAshill.Nuadha
{
    public sealed class ThreePointTrackerModule :
        IThreePointTrackerHardwareHandler,
        IThreePointTrackerSoftwareHandler,
        IDisconnection
    {
        private readonly PoseTrackerModule poseTracker = new PoseTrackerModule();

        private readonly HeadsetModule head = new HeadsetModule();

        private readonly HandControllerModule leftHand = new HandControllerModule();

        private readonly HandControllerModule rightHand = new HandControllerModule();

        #region IThreePointTrackerHardwareHandler

        IPoseTrackerHardwareHandler IThreePointTrackerHardwareHandler.PoseTracker => poseTracker;

        IHeadsetHardwareHandler IThreePointTrackerHardwareHandler.Head => head;

        IHandControllerHardwareHandler IThreePointTrackerHardwareHandler.LeftHand => leftHand;

        IHandControllerHardwareHandler IThreePointTrackerHardwareHandler.RightHand => rightHand;

        #endregion

        #region IThreePointTrackerSoftwareHandler

        IPoseTrackerSoftwareHandler IThreePointTrackerSoftwareHandler.PoseTracker => poseTracker;

        IHeadsetSoftwareHandler IThreePointTrackerSoftwareHandler.Head => head;

        IHandControllerSoftwareHandler IThreePointTrackerSoftwareHandler.LeftHand => leftHand;

        IHandControllerSoftwareHandler IThreePointTrackerSoftwareHandler.RightHand => rightHand;

        #endregion

        #region IDisconnection

        public void Disconnect()
        {
            poseTracker.Disconnect();

            head.Disconnect();

            leftHand.Disconnect();

            rightHand.Disconnect();
        }

        #endregion
    }
}
