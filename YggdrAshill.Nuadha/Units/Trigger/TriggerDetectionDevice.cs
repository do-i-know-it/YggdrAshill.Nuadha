using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class TriggerDetectionDevice :
        IDevice<ITriggerDetectionSoftware>
    {
        private readonly TouchDetectionDevice touch;

        private readonly PullDetectionDevice pull;

        public TriggerDetectionDevice(ITriggerHardware hardware, HysteresisThreshold threshold)
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

            pull = new PullDetectionDevice(hardware.Pull, threshold);
        }

        public IDisconnection Connect(ITriggerDetectionSoftware software)
        {
            if (software == null)
            {
                throw new ArgumentNullException(nameof(software));
            }

            var touch = this.touch.Connect(software.Touch);

            var pull = this.pull.Connect(software.Pull);

            return new Disconnection(() =>
            {
                touch.Disconnect();

                pull.Disconnect();
            });
        }
    }
}
