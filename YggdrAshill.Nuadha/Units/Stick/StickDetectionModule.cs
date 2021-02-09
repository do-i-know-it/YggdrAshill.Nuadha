using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Units;

namespace YggdrAshill.Nuadha
{
    public sealed class StickDetectionModule :
        IStickDetectionInputHandler,
        IStickDetectionOutputHandler,
        IDisconnection
    {
        private readonly PulseDetectionModule touch = new PulseDetectionModule();

        private readonly PulseDetectionModule push = new PulseDetectionModule();

        private readonly TiltDetectionModule tilt = new TiltDetectionModule();

        #region IStickDetectionInputHandler

        IPulseDetectionInputHandler IButtonDetectionInputHandler.Touch => touch;

        IPulseDetectionInputHandler IButtonDetectionInputHandler.Push => push;

        ITiltDetectionInputHandler IStickDetectionInputHandler.Tilt => tilt;

        #endregion

        #region IStickDetectionOutputHandler

        IPulseDetectionOutputHandler IButtonDetectionOutputHandler.Touch => touch;

        IPulseDetectionOutputHandler IButtonDetectionOutputHandler.Push => push;

        ITiltDetectionOutputHandler IStickDetectionOutputHandler.Tilt => tilt;

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
