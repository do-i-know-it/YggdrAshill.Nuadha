using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Translation;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class ButtonEventInputSystem :
        ISoftware<IButtonSoftwareHandler>,
        IButtonEventOutputHandler,
        IDisconnection
    {
        private readonly TouchEventInputSystem touch;

        private readonly PushEventInputSystem push;

        public ButtonEventInputSystem()
        {
            touch = new TouchEventInputSystem();

            push = new PushEventInputSystem();
        }

        #region IButtonEventOutputHandler

        public IPulseEventOutputHandler Touch => touch;

        public IPulseEventOutputHandler Push => push;

        #endregion

        #region ISoftware

        public IDisconnection Connect(IButtonSoftwareHandler handler)
        {
            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }

            var touch = handler.Touch.Connect(this.touch);

            var push = handler.Push.Connect(this.push);

            return new Disconnection(() =>
            {
                touch.Disconnect();

                push.Disconnect();
            });
        }

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
