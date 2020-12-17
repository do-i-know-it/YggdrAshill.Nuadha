using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Translation;
using YggdrAshill.Nuadha.Units;

namespace YggdrAshill.Nuadha
{
    public sealed class EyeTrackerEventModule :
        IEyeTrackerEventInputHandler,
        IEyeTrackerEventOutputHandler,
        IDisconnection
    {
        private readonly PulseEventModule pupil = new PulseEventModule();

        private readonly PulseEventModule blink = new PulseEventModule();

        #region IEyeTrackerEventInputHandler

        IPulseEventInputHandler IEyeTrackerEventInputHandler.Pupil => pupil;

        IPulseEventInputHandler IEyeTrackerEventInputHandler.Blink => blink;

        #endregion

        #region IEyeTrackerEventOutputHandler

        IPulseEventOutputHandler IEyeTrackerEventOutputHandler.Pupil => pupil;

        IPulseEventOutputHandler IEyeTrackerEventOutputHandler.Blink => blink;

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
