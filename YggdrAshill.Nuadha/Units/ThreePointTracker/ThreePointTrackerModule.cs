using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Units;

namespace YggdrAshill.Nuadha
{
    public sealed class ThreePointTrackerModule :
        IThreePointTrackerHardwareHandler,
        IThreePointTrackerSoftwareHandler,
        IDisconnection
    {
        private readonly PoseTrackerModule head = new PoseTrackerModule();
        
        private readonly PoseTrackerModule leftHand = new PoseTrackerModule();
        
        private readonly PoseTrackerModule rightHand = new PoseTrackerModule();

        #region IThreePointTrackerHardwareHandler

        IPoseTrackerHardwareHandler IThreePointTrackerHardwareHandler.Head => head;

        IPoseTrackerHardwareHandler IThreePointTrackerHardwareHandler.LeftHand => leftHand;

        IPoseTrackerHardwareHandler IThreePointTrackerHardwareHandler.RightHand => rightHand;

        #endregion

        #region IThreePointTrackerSoftwareHandler

        IPoseTrackerSoftwareHandler IThreePointTrackerSoftwareHandler.Head => head;

        IPoseTrackerSoftwareHandler IThreePointTrackerSoftwareHandler.LeftHand => leftHand;

        IPoseTrackerSoftwareHandler IThreePointTrackerSoftwareHandler.RightHand => rightHand;

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
