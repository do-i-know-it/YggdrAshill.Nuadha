using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Signals;
using YggdrAshill.Nuadha.Units;

namespace YggdrAshill.Nuadha
{
    public sealed class EyeTrackerEventModule :
        IEyeTrackerEventInputHandler,
        IEyeTrackerEventOutputHandler,
        IDisconnection
    {
        private readonly PupilEventModule pupil = new PupilEventModule();

        private readonly BlinkEventModule blink = new BlinkEventModule();

        #region IEyeTrackerEventInputHandler

        IPupilEventInputHandler IEyeTrackerEventInputHandler.Pupil => pupil;

        IBlinkEventInputHandler IEyeTrackerEventInputHandler.Blink => blink;

        #endregion

        #region IEyeTrackerEventOutputHandler

        IPupilEventOutputHandler IEyeTrackerEventOutputHandler.Pupil => pupil;

        IBlinkEventOutputHandler IEyeTrackerEventOutputHandler.Blink => blink;

        #endregion

        #region IDisconnection

        public void Disconnect()
        {
            pupil.Disconnect();

            blink.Disconnect();
        }

        #endregion
    }
}
