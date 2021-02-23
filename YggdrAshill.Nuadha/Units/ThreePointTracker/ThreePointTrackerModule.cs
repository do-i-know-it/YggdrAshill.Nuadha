using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Units;

namespace YggdrAshill.Nuadha
{
    public sealed class ThreePointTrackerModule :
        IThreePointTrackerSystem,
        IThreePointTrackerDevice,
        IDisconnection
    {
        private readonly PoseTrackerModule head = new PoseTrackerModule();
        
        private readonly PoseTrackerModule leftHand = new PoseTrackerModule();
        
        private readonly PoseTrackerModule rightHand = new PoseTrackerModule();

        #region IThreePointTrackerSystem

        IPoseTrackerSystem IThreePointTrackerSystem.Head => head;

        IPoseTrackerSystem IThreePointTrackerSystem.LeftHand => leftHand;

        IPoseTrackerSystem IThreePointTrackerSystem.RightHand => rightHand;

        #endregion

        #region IThreePointTrackerDevice

        IPoseTrackerDevice IThreePointTrackerDevice.Head => head;

        IPoseTrackerDevice IThreePointTrackerDevice.LeftHand => leftHand;

        IPoseTrackerDevice IThreePointTrackerDevice.RightHand => rightHand;

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
