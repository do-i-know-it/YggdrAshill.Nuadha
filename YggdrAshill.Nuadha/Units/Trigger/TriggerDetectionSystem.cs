using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class TriggerDetectionSystem :
        IHardware<ITriggerDetectionHardwareHandler>
    {
        private readonly TouchDetectionSystem touch;

        private readonly PullDetectionSystem pull;

        public TriggerDetectionSystem(ITriggerSoftwareHandler handler, HysteresisThreshold threshold)
        {
            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }
            if (threshold == null)
            {
                throw new ArgumentNullException(nameof(threshold));
            }

            touch = new TouchDetectionSystem(handler.Touch);

            pull = new PullDetectionSystem(handler.Pull, threshold);
        }

        public IDisconnection Connect(ITriggerDetectionHardwareHandler handler)
        {
            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }

            var touch = this.touch.Connect(handler.Touch);

            var pull = this.pull.Connect(handler.Pull);

            return new Disconnection(() =>
            {
                touch.Disconnect();

                pull.Disconnect();
            });
        }
    }
}
