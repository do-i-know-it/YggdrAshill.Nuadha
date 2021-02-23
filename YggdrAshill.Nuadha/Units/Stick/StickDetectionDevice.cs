using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class StickDetectionDevice :
        IHardware<IStickDetectionSystem>
    {
        private readonly TouchDetectionDevice touch;

        private readonly TiltDetectionDevice tilt;

        public StickDetectionDevice(IStickDevice device, ITiltThreshold threshold)
        {
            if (device == null)
            {
                throw new ArgumentNullException(nameof(device));
            }
            if (threshold == null)
            {
                throw new ArgumentNullException(nameof(threshold));
            }

            touch = new TouchDetectionDevice(device.Touch);

            tilt = new TiltDetectionDevice(device.Tilt, threshold);
        }

        public IDisconnection Connect(IStickDetectionSystem system)
        {
            if (system == null)
            {
                throw new ArgumentNullException(nameof(system));
            }

            var touch = this.touch.Connect(system.Touch);

            var tilt = this.tilt.Connect(system.Tilt);

            return new Disconnection(() =>
            {
                touch.Disconnect();

                tilt.Disconnect();
            });
        }
    }
}
