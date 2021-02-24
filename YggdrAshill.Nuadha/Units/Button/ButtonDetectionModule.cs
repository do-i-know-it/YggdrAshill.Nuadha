using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Units;

namespace YggdrAshill.Nuadha
{
    public sealed class ButtonDetectionModule :
        IButtonDetectionSoftware,
        IButtonDetectionHardware,
        IDisconnection
    {
        private readonly PulseDetectionModule touch = new PulseDetectionModule();

        private readonly PulseDetectionModule push = new PulseDetectionModule();

        #region IButtonDetectionSoftware

        IDetectionSoftware IButtonDetectionSoftware.Touch => touch;

        IDetectionSoftware IButtonDetectionSoftware.Push => push;

        #endregion

        #region IButtonDetectionHardware

        IDetectionHardware IButtonDetectionHardware.Touch => touch;

        IDetectionHardware IButtonDetectionHardware.Push => push;

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
