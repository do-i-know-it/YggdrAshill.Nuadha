using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Units;

namespace YggdrAshill.Nuadha
{
    public sealed class HeadsetEventModule :
        IHeadsetEventInputHandler,
        IHeadsetEventOutputHandler,
        IDisconnection
    {
        private readonly EyeTrackerEventModule leftEye = new EyeTrackerEventModule();

        private readonly EyeTrackerEventModule rightEye = new EyeTrackerEventModule();

        #region IHeadsetEventInputHandler

        IEyeTrackerEventInputHandler IHeadsetEventInputHandler.LeftEye => leftEye;

        IEyeTrackerEventInputHandler IHeadsetEventInputHandler.RightEye => rightEye;

        #endregion

        #region IHeadsetEventOutputHandler

        IEyeTrackerEventOutputHandler IHeadsetEventOutputHandler.LeftEye => leftEye;

        IEyeTrackerEventOutputHandler IHeadsetEventOutputHandler.RightEye => rightEye;

        #endregion

        #region IDisconnection

        public void Disconnect()
        {
            leftEye.Disconnect();

            rightEye.Disconnect();
        }

        #endregion
    }
}
