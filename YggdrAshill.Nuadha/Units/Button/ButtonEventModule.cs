using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Signals;
using YggdrAshill.Nuadha.Units;

namespace YggdrAshill.Nuadha
{
    public sealed class ButtonEventModule :
        IButtonEventInputHandler,
        IButtonEventOutputHandler,
        IDisconnection
    {
        private readonly TouchEventModule touch = new TouchEventModule();

        private readonly PushEventModule push = new PushEventModule();

        #region IButtonEventInputHandler

        ITouchEventInputHandler IButtonEventInputHandler.Touch => touch;

        IPushEventInputHandler IButtonEventInputHandler.Push => push;

        #endregion

        #region IButtonEventOutputHandler

        ITouchEventOutputHandler IButtonEventOutputHandler.Touch => touch;

        IPushEventOutputHandler IButtonEventOutputHandler.Push => push;

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
