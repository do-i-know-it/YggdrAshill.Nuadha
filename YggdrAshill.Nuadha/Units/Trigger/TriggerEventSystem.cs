using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class TriggerEventSystem :
        ISoftware<ITriggerSoftwareHandler>,
        IDisconnection
    {
        private readonly TouchEventSystem touch;

        private readonly PullEventSystem pull;

        public TriggerEventSystem(HysteresisThreshold threshold, ITriggerEventInputHandler handler)
        {
            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }

            touch = new TouchEventSystem(handler.Touch);

            pull = new PullEventSystem(threshold, handler.Pull);
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

        #region IDisconnection

        public void Disconnect()
        {
            touch.Disconnect();

            pull.Disconnect();
        }

        #endregion
    }
}
