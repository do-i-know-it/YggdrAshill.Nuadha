using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Units;

namespace YggdrAshill.Nuadha
{
    public sealed class ThreePointTrackerModule :
        IThreePointTrackerHardwareHandler,
        IThreePointTrackerSoftwareHandler,
        IDisconnection
    {
        private readonly HeadsetModule head = new HeadsetModule();

        private readonly HandControllerModule leftHand = new HandControllerModule();

        private readonly HandControllerModule rightHand = new HandControllerModule();

        #region IThreePointTrackerHardwareHandler

        IHeadsetHardwareHandler IThreePointTrackerHardwareHandler.Head => head;

        IHandControllerHardwareHandler IThreePointTrackerHardwareHandler.LeftHand => leftHand;

        IHandControllerHardwareHandler IThreePointTrackerHardwareHandler.RightHand => rightHand;

        #endregion

        #region IThreePointTrackerHardwareHandler

        IHeadsetSoftwareHandler IThreePointTrackerSoftwareHandler.Head => head;

        IHandControllerSoftwareHandler IThreePointTrackerSoftwareHandler.LeftHand => leftHand;

        IHandControllerSoftwareHandler IThreePointTrackerSoftwareHandler.RightHand => rightHand;

        #endregion

        #region IDisconnection

        public void Disconnect()
        {
            head.Disconnect();

            leftHand.Disconnect();

            rightHand.Disconnect();
        }

        #endregion
    }
}
