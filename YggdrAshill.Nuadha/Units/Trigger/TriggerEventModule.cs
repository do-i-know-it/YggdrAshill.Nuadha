using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Signals;
using YggdrAshill.Nuadha.Units;

namespace YggdrAshill.Nuadha
{
    public sealed class TriggerEventModule :
        ITriggerEventInputHandler,
        ITriggerEventOutputHandler,
        IDisconnection
    {
        private readonly TouchEventModule touch = new TouchEventModule();

        private readonly PullEventModule pull = new PullEventModule();

        #region ITriggerEventInputHandler

        ITouchEventInputHandler ITriggerEventInputHandler.Touch => touch;

        IPullEventInputHandler ITriggerEventInputHandler.Pull => pull;

        #endregion

        #region ITriggerEventOutputHandler

        ITouchEventOutputHandler ITriggerEventOutputHandler.Touch => touch;

        IPullEventOutputHandler ITriggerEventOutputHandler.Pull => pull;

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
