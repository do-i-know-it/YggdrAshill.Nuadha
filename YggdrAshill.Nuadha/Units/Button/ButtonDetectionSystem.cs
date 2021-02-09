using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class ButtonDetectionSystem :
        ISoftware<IButtonSoftwareHandler>,
        IHardware<IButtonDetectionInputHandler>,
        IDisconnection
    {
        private readonly TouchDetectionSystem touch = new TouchDetectionSystem();

        private readonly PushDetectionSystem push = new PushDetectionSystem();

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

        #region IHardware

        public IDisconnection Connect(IButtonDetectionInputHandler handler)
        {
            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }

            var touch = this.touch.Connect(handler.Touch);

            var push = this.push.Connect(handler.Push);

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
