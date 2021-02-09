using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Signals;
using YggdrAshill.Nuadha.Units;

namespace YggdrAshill.Nuadha
{
    public sealed class EyeTrackerModule :
        IEyeTrackerSoftwareHandler,
        IEyeTrackerHardwareHandler,
        IDisconnection
    {
        private readonly Propagation<Pupil> pupil = new Propagation<Pupil>();

        private readonly Propagation<Blink> blink = new Propagation<Blink>();

        #region IEyeTrackerSoftwareHandler

        IConnection<Pupil> IEyeTrackerSoftwareHandler.Pupil => pupil;

        IConnection<Blink> IEyeTrackerSoftwareHandler.Blink => blink;

        #endregion

        #region IEyeTrackerHardwareHandler

        IConsumption<Pupil> IEyeTrackerHardwareHandler.Pupil => pupil;

        IConsumption<Blink> IEyeTrackerHardwareHandler.Blink => blink;
        
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
