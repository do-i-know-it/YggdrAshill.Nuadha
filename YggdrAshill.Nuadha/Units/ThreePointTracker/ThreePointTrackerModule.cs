using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Units;

namespace YggdrAshill.Nuadha
{
    public sealed class ThreePointTrackerModule :
        IThreePointTrackerSoftware,
        IThreePointTrackerHardware,
        IDisconnection
    {
        private readonly PoseTrackerModule head = new PoseTrackerModule();
        
        private readonly PoseTrackerModule leftHand = new PoseTrackerModule();
        
        private readonly PoseTrackerModule rightHand = new PoseTrackerModule();

        #region IThreePointTrackerSoftware

        IPoseTrackerSoftware IThreePointTrackerSoftware.Head => head;

        IPoseTrackerSoftware IThreePointTrackerSoftware.LeftHand => leftHand;

        IPoseTrackerSoftware IThreePointTrackerSoftware.RightHand => rightHand;

        #endregion

        #region IThreePointTrackerHardware

        IPoseTrackerHardware IThreePointTrackerHardware.Head => head;

        IPoseTrackerHardware IThreePointTrackerHardware.LeftHand => leftHand;

        IPoseTrackerHardware IThreePointTrackerHardware.RightHand => rightHand;

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
