using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Units;

namespace YggdrAshill.Nuadha
{
    public sealed class ButtonDetectionModule :
        IButtonDetectionSystem,
        IButtonDetectionDevice,
        IDisconnection
    {
        private readonly PulseDetectionModule touch = new PulseDetectionModule();

        private readonly PulseDetectionModule push = new PulseDetectionModule();

        #region IButtonDetectionSystem

        IDetectionSystem IButtonDetectionSystem.Touch => touch;

        IDetectionSystem IButtonDetectionSystem.Push => push;

        #endregion

        #region IButtonDetectionDevice

        IDetectionDevice IButtonDetectionDevice.Touch => touch;

        IDetectionDevice IButtonDetectionDevice.Push => push;

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
