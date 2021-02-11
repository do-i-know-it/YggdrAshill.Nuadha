using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Units;

namespace YggdrAshill.Nuadha
{
    public sealed class ButtonDetectionModule :
        IButtonDetectionHardwareHandler,
        IButtonDetectionSoftwareHandler,
        IDisconnection
    {
        private readonly PulseDetectionModule touch = new PulseDetectionModule();

        private readonly PulseDetectionModule push = new PulseDetectionModule();

        #region IButtonDetectionHardwareHandler

        IDetectionHardwareHandler IButtonDetectionHardwareHandler.Touch => touch;

        IDetectionHardwareHandler IButtonDetectionHardwareHandler.Push => push;

        #endregion

        #region IButtonDetectionSoftwareHandler

        IDetectionSoftwareHandler IButtonDetectionSoftwareHandler.Touch => touch;

        IDetectionSoftwareHandler IButtonDetectionSoftwareHandler.Push => push;

        #endregion

        #region IDisconnection

        public void Disconnect()
        {
            touch.Disconnect();

            push.Disconnect();
        }

        #endregion
    }
}
