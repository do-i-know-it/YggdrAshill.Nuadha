using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class ButtonDetectionSystem :
        IHardware<IButtonDetectionHardwareHandler>
    {
        private readonly TouchDetectionSystem touch;

        private readonly PushDetectionSystem push;

        public ButtonDetectionSystem(IButtonSoftwareHandler handler)
        {
            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }

            touch = new TouchDetectionSystem(handler.Touch);

            push = new PushDetectionSystem(handler.Push);
        }

        public IDisconnection Connect(IButtonDetectionHardwareHandler handler)
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
    }
}
