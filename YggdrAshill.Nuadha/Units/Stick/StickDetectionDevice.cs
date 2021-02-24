using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class StickDetectionDevice :
        IDevice<IStickDetectionSoftware>
    {
        private readonly TouchDetectionDevice touch;

        private readonly TiltDetectionDevice tilt;

        public StickDetectionDevice(IStickHardware hardware, ITiltThreshold threshold)
        {
            if (hardware == null)
            {
                throw new ArgumentNullException(nameof(hardware));
            }
            if (threshold == null)
            {
                throw new ArgumentNullException(nameof(threshold));
            }

            touch = new TouchDetectionDevice(hardware.Touch);

            tilt = new TiltDetectionDevice(hardware.Tilt, threshold);
        }

        public IDisconnection Connect(IStickDetectionSoftware software)
        {
            if (software == null)
            {
                throw new ArgumentNullException(nameof(software));
            }

            var touch = this.touch.Connect(software.Touch);

            var tilt = this.tilt.Connect(software.Tilt);

            return new Disconnection(() =>
            {
                touch.Disconnect();

                tilt.Disconnect();
            });
        }
    }
}
