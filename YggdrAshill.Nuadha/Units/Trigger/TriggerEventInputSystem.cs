using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class TriggerEventInputSystem :
        ISoftware<ITriggerSoftwareHandler>,
        ITriggerEventOutputHandler,
        IDisconnection
    {
        private readonly TouchEventInputSystem touch;

        private readonly PullEventInputSystem pull;

        public TriggerEventInputSystem(HysteresisThreshold threshold)
        {
            touch = new TouchEventInputSystem();

            pull = new PullEventInputSystem(threshold);
        }

        #region ITriggerEventOutputHandler

        public ITouchEventOutputHandler Touch => touch;

        public IPullEventOutputHandler Pull => pull;

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
