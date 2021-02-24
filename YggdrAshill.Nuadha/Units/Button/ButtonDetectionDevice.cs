using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class ButtonDetectionDevice :
        IDevice<IButtonDetectionSoftware>
    {
        private readonly TouchDetectionDevice touch;

        private readonly PushDetectionDevice push;

        public ButtonDetectionDevice(IButtonHardware hardware)
        {
            if (hardware == null)
            {
                throw new ArgumentNullException(nameof(hardware));
            }

            touch = new TouchDetectionDevice(hardware.Touch);

            push = new PushDetectionDevice(hardware.Push);
        }

        public IDisconnection Connect(IButtonDetectionSoftware software)
        {
            if (software == null)
            {
                throw new ArgumentNullException(nameof(software));
            }

            var touch = this.touch.Connect(software.Touch);

            var push = this.push.Connect(software.Push);

            return new Disconnection(() =>
            {
                touch.Disconnect();

                push.Disconnect();
            });
        }
    }
}
