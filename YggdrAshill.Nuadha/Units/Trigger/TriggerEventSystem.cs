using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class TriggerEventSystem :
        ISoftware<ITriggerSoftwareHandler>,
        ITriggerEventHandler,
        IDisconnection
    {
        private readonly TouchEventSystem touch;

        private readonly PullEventSystem pull;

        public TriggerEventSystem(HysteresisThreshold threshold)
        {
            touch = new TouchEventSystem();

            pull = new PullEventSystem(threshold);
        }

        #region ITriggerEventHandler

        public ITouchEventHandler Touch => touch;

        public IPullEventHandler Pull => pull;

        #endregion

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
