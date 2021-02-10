using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Units;

namespace YggdrAshill.Nuadha
{
    public sealed class ThreePointTrackerModule :
        IThreePointTrackerHardwareHandler,
        IThreePointTrackerSoftwareHandler,
        IDisconnection
    {
        private readonly PoseTrackerModule origin = new PoseTrackerModule();

        private readonly PoseTrackerModule head = new PoseTrackerModule();
        
        private readonly PoseTrackerModule leftHand = new PoseTrackerModule();
        
        private readonly PoseTrackerModule rightHand = new PoseTrackerModule();

        #region IThreePointTrackerHardwareHandler

        IPoseTrackerHardwareHandler IThreePointTrackerHardwareHandler.Origin => origin;

        IPoseTrackerHardwareHandler IThreePointTrackerHardwareHandler.Head => head;

        IPoseTrackerHardwareHandler IThreePointTrackerHardwareHandler.LeftHand => leftHand;

        IPoseTrackerHardwareHandler IThreePointTrackerHardwareHandler.RightHand => rightHand;

        #endregion

        #region IThreePointTrackerSoftwareHandler

        IPoseTrackerSoftwareHandler IThreePointTrackerSoftwareHandler.Origin => origin;

        IPoseTrackerSoftwareHandler IThreePointTrackerSoftwareHandler.Head => head;

        IPoseTrackerSoftwareHandler IThreePointTrackerSoftwareHandler.LeftHand => leftHand;

        IPoseTrackerSoftwareHandler IThreePointTrackerSoftwareHandler.RightHand => rightHand;

        #endregion

        #region IDisconnection

        public void Disconnect()
        {
            origin.Disconnect();

            head.Disconnect();
            
            leftHand.Disconnect();
            
            rightHand.Disconnect();
        }

        #endregion
    }
}
