using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class ButtonEventSystem :
        ISoftware<IButtonSoftwareHandler>,
        IButtonEventHandler,
        IDisconnection
    {
        private readonly TouchEventSystem touch;

        private readonly PushEventSystem push;

        public ButtonEventSystem()
        {
            touch = new TouchEventSystem();

            push = new PushEventSystem();
        }

        #region IButtonEventHandler

        public ITouchEventHandler Touch => touch;

        public IPushEventHandler Push => push;

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
