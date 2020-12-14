using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Units;

namespace YggdrAshill.Nuadha
{
    public sealed class ThreePointTrackerEventModule :
        IThreePointTrackerEventInputHandler,
        IThreePointTrackerEventOutputHandler,
        IDisconnection
    {
        private readonly HeadsetEventModule head = new HeadsetEventModule();

        private readonly HandControllerEventModule leftHand = new HandControllerEventModule();

        private readonly HandControllerEventModule rightHand = new HandControllerEventModule();

        #region IThreePointTrackerEventInputHandler

        IHeadsetEventInputHandler IThreePointTrackerEventInputHandler.Head => head;

        IHandControllerEventInputHandler IThreePointTrackerEventInputHandler.LeftHand => leftHand;

        IHandControllerEventInputHandler IThreePointTrackerEventInputHandler.RightHand => rightHand;

        #endregion

        #region IThreePointTrackerEventOutputHandler

        IHeadsetEventOutputHandler IThreePointTrackerEventOutputHandler.Head => head;

        IHandControllerEventOutputHandler IThreePointTrackerEventOutputHandler.LeftHand => leftHand;

        IHandControllerEventOutputHandler IThreePointTrackerEventOutputHandler.RightHand => rightHand;

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
