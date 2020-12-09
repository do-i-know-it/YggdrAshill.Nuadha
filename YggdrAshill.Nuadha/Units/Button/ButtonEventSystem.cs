using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Signals;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class ButtonEventSystem :
        IButtonEventSystem
    {
        private readonly ITouchEventSystem touch;

        private readonly IPushEventSystem push;

        public ButtonEventSystem(ITouchEventSystem touch, IPushEventSystem push)
        {
            if (touch == null)
            {
                throw new ArgumentNullException(nameof(touch));
            }
            if (push == null)
            {
                throw new ArgumentNullException(nameof(push));
            }

            this.touch = touch;

            this.push = push;
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
