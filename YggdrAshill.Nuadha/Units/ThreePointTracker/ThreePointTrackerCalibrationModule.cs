using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Units;

namespace YggdrAshill.Nuadha
{
    public sealed class ThreePointTrackerCalibrationModule :
        IThreePointTrackerCalibrationInputHandler,
        IThreePointTrackerCalibrationOutputHandler,
        IDisconnection
    {
        private readonly PoseTrackerModule head = new PoseTrackerModule();

        private readonly PoseTrackerModule leftHand = new PoseTrackerModule();

        private readonly PoseTrackerModule rightHand = new PoseTrackerModule();

        #region IThreePointTrackerCalibrationInputHandler

        IPoseTrackerHardwareHandler IThreePointTrackerCalibrationInputHandler.Head => head;

        IPoseTrackerHardwareHandler IThreePointTrackerCalibrationInputHandler.LeftHand => leftHand;

        IPoseTrackerHardwareHandler IThreePointTrackerCalibrationInputHandler.RightHand => rightHand;

        #endregion

        #region IThreePointTrackerCalibrationOutputHandler

        IPoseTrackerSoftwareHandler IThreePointTrackerCalibrationOutputHandler.Head => head;

        IPoseTrackerSoftwareHandler IThreePointTrackerCalibrationOutputHandler.LeftHand => leftHand;

        IPoseTrackerSoftwareHandler IThreePointTrackerCalibrationOutputHandler.RightHand => rightHand;

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
