using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Units;

namespace YggdrAshill.Nuadha
{
    public sealed class StickDetectionModule :
        IStickDetectionHardwareHandler,
        IStickDetectionSoftwareHandler,
        IDisconnection
    {
        private readonly PulseDetectionModule touch = new PulseDetectionModule();

        private readonly PulseDetectionModule push = new PulseDetectionModule();

        private readonly TiltDetectionModule tilt = new TiltDetectionModule();

        #region IStickDetectionHardwareHandler

        IDetectionHardwareHandler IButtonDetectionHardwareHandler.Touch => touch;

        IDetectionHardwareHandler IButtonDetectionHardwareHandler.Push => push;

        ITiltDetectionHardwareHandler IStickDetectionHardwareHandler.Tilt => tilt;

        #endregion

        #region IStickDetectionSoftwareHandler

        IDetectionSoftwareHandler IButtonDetectionSoftwareHandler.Touch => touch;

        IDetectionSoftwareHandler IButtonDetectionSoftwareHandler.Push => push;

        ITiltDetectionSoftwareHandler IStickDetectionSoftwareHandler.Tilt => tilt;

        #endregion

        #region IDisconnection

        public void Disconnect()
        {
            touch.Disconnect();

            push.Disconnect();

            tilt.Disconnect();
        }

        #endregion
    }
}
