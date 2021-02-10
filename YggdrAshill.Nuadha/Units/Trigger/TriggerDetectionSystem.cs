using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class TriggerDetectionSystem :
        ISoftware<ITriggerSoftwareHandler>,
        IHardware<ITriggerDetectionHardwareHandler>,
        IDisconnection
    {
        private readonly TouchDetectionSystem touch = new TouchDetectionSystem();

        private readonly PullDetectionSystem pull;

        public TriggerDetectionSystem(HysteresisThreshold threshold)
        {
            if (threshold == null)
            {
                throw new ArgumentNullException(nameof(threshold));
            }

            pull = new PullDetectionSystem(threshold);
        }

        #region ISoftware

        public IDisconnection Connect(ITriggerSoftwareHandler handler)
        {
            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }

            var touch = handler.Touch.Connect(this.touch);

            var pull = handler.Pull.Connect(this.pull);

            return new Disconnection(() =>
            {
                touch.Disconnect();

                pull.Disconnect();
            });
        }

        #endregion

        #region IHardware

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

        #endregion

        #region IDisconnection

        public void Disconnect()
        {
            touch.Disconnect();

            pull.Disconnect();
        }

        #endregion
    }
}
