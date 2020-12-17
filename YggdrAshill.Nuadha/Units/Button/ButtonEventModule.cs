using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Translation;
using YggdrAshill.Nuadha.Units;

namespace YggdrAshill.Nuadha
{
    public sealed class ButtonEventModule :
        IButtonEventInputHandler,
        IButtonEventOutputHandler,
        IDisconnection
    {
        private readonly PulseEventModule touch = new PulseEventModule();

        private readonly PulseEventModule push = new PulseEventModule();

        #region IButtonEventInputHandler

        IPulseEventInputHandler IButtonEventInputHandler.Touch => touch;

        IPulseEventInputHandler IButtonEventInputHandler.Push => push;

        #endregion

        #region IButtonEventOutputHandler

        IPulseEventOutputHandler IButtonEventOutputHandler.Touch => touch;

        IPulseEventOutputHandler IButtonEventOutputHandler.Push => push;

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
