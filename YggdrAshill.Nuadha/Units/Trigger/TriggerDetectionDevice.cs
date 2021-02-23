using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class TriggerDetectionDevice :
        IHardware<ITriggerDetectionSystem>
    {
        private readonly TouchDetectionDevice touch;

        private readonly PullDetectionDevice pull;

        public TriggerDetectionDevice(ITriggerDevice device, HysteresisThreshold threshold)
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

            pull = new PullDetectionDevice(device.Pull, threshold);
        }

        public IDisconnection Connect(ITriggerDetectionSystem system)
        {
            if (system == null)
            {
                throw new ArgumentNullException(nameof(system));
            }

            var touch = this.touch.Connect(system.Touch);

            var pull = this.pull.Connect(system.Pull);

            return new Disconnection(() =>
            {
                touch.Disconnect();

                pull.Disconnect();
            });
        }
    }
}
