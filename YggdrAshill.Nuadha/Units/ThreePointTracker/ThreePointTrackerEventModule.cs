using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Units;

namespace YggdrAshill.Nuadha
{
    public sealed class ThreePointTrackerEventModule :
        IThreePointTrackerDetectionInputHandler,
        IThreePointTrackerDetectionOutputHandler,
        IDisconnection
    {
        private readonly HandControllerDetectionModule leftHand = new HandControllerDetectionModule();

        private readonly HandControllerDetectionModule rightHand = new HandControllerDetectionModule();

        #region IThreePointTrackerDetectionInputHandler

        IHandControllerDetectionInputHandler IThreePointTrackerDetectionInputHandler.LeftHand => leftHand;

        IHandControllerDetectionInputHandler IThreePointTrackerDetectionInputHandler.RightHand => rightHand;

        #endregion

        #region IThreePointTrackerDetectionOutputHandler

        IHandControllerDetectionOutputHandler IThreePointTrackerDetectionOutputHandler.LeftHand => leftHand;

        IHandControllerDetectionOutputHandler IThreePointTrackerDetectionOutputHandler.RightHand => rightHand;

        #endregion

        #region IDisconnection

        public void Disconnect()
        {
            leftHand.Disconnect();

            rightHand.Disconnect();
        }

        #endregion
    }
}
