using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Translation;
using YggdrAshill.Nuadha.Units;

namespace YggdrAshill.Nuadha
{
    public sealed class TriggerEventModule :
        ITriggerEventInputHandler,
        ITriggerEventOutputHandler,
        IDisconnection
    {
        private readonly PulseEventModule touch = new PulseEventModule();

        private readonly PulseEventModule pull = new PulseEventModule();

        #region ITriggerEventInputHandler

        IPulseEventInputHandler ITriggerEventInputHandler.Touch => touch;

        IPulseEventInputHandler ITriggerEventInputHandler.Pull => pull;

        #endregion

        #region ITriggerEventOutputHandler

        IPulseEventOutputHandler ITriggerEventOutputHandler.Touch => touch;

        IPulseEventOutputHandler ITriggerEventOutputHandler.Pull => pull;

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
