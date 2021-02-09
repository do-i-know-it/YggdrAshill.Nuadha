using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Units;

namespace YggdrAshill.Nuadha
{
    public sealed class TriggerDetectionModule :
        ITriggerDetectionInputHandler,
        ITriggerDetectionOutputHandler,
        IDisconnection
    {
        private readonly PulseDetectionModule touch = new PulseDetectionModule();

        private readonly PulseDetectionModule pull = new PulseDetectionModule();

        #region ITriggerDetectionInputHandler

        IPulseDetectionInputHandler ITriggerDetectionInputHandler.Touch => touch;

        IPulseDetectionInputHandler ITriggerDetectionInputHandler.Pull => pull;

        #endregion

        #region ITriggerDetectionOutputHandler

        IPulseDetectionOutputHandler ITriggerDetectionOutputHandler.Touch => touch;

        IPulseDetectionOutputHandler ITriggerDetectionOutputHandler.Pull => pull;

        #endregion

        #region IDisconnection

        public void Disconnect()
        {
            touch.Disconnect();

            pull.Disconnect();
        }

        #endregion
    }
}
