using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Units;

namespace YggdrAshill.Nuadha
{
    public sealed class ButtonDetectionModule :
        IButtonDetectionInputHandler,
        IButtonDetectionOutputHandler,
        IDisconnection
    {
        private readonly PulseDetectionModule touch = new PulseDetectionModule();

        private readonly PulseDetectionModule push = new PulseDetectionModule();

        #region IButtonDetectionInputHandler

        IPulseDetectionInputHandler IButtonDetectionInputHandler.Touch => touch;

        IPulseDetectionInputHandler IButtonDetectionInputHandler.Push => push;

        #endregion

        #region IButtonDetectionOutputHandler

        IPulseDetectionOutputHandler IButtonDetectionOutputHandler.Touch => touch;

        IPulseDetectionOutputHandler IButtonDetectionOutputHandler.Push => push;

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
