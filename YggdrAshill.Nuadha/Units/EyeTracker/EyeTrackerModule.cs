using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Signals;
using YggdrAshill.Nuadha.Units;

namespace YggdrAshill.Nuadha
{
    public sealed class EyeTrackerModule :
        IEyeTrackerSoftwareHandler,
        IEyeTrackerHardwareHandler,
        IDisconnection
    {
        private readonly Connector<Pupil> pupil = new Connector<Pupil>();

        private readonly Connector<Blink> blink = new Connector<Blink>();

        #region IEyeTrackerSoftwareHandler

        IOutputTerminal<Pupil> IEyeTrackerSoftwareHandler.Pupil => pupil;

        IOutputTerminal<Blink> IEyeTrackerSoftwareHandler.Blink => blink;

        #endregion

        #region IEyeTrackerHardwareHandler

        IInputTerminal<Pupil> IEyeTrackerHardwareHandler.Pupil => pupil;

        IInputTerminal<Blink> IEyeTrackerHardwareHandler.Blink => blink;
        
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
