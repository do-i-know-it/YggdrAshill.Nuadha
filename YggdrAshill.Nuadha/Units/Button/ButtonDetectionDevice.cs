using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class ButtonDetectionDevice :
        IHardware<IButtonDetectionSystem>
    {
        private readonly TouchDetectionDevice touch;

        private readonly PushDetectionDevice push;

        public ButtonDetectionDevice(IButtonDevice device)
        {
            if (device == null)
            {
                throw new ArgumentNullException(nameof(device));
            }

            touch = new TouchDetectionDevice(device.Touch);

            push = new PushDetectionDevice(device.Push);
        }

        public IDisconnection Connect(IButtonDetectionSystem system)
        {
            if (system == null)
            {
                throw new ArgumentNullException(nameof(system));
            }

            var touch = this.touch.Connect(system.Touch);

            var push = this.push.Connect(system.Push);

            return new Disconnection(() =>
            {
                touch.Disconnect();

                push.Disconnect();
            });
        }
    }
}
