using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Signals;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class TriggerEventSystem :
        ITriggerEventSystem
    {
        private readonly ITouchEventSystem touch;

        private readonly IPullEventSystem pull;

        public TriggerEventSystem(ITouchEventSystem touch, IPullEventSystem pull)
        {
            if (touch == null)
            {
                throw new ArgumentNullException(nameof(touch));
            }
            if (pull == null)
            {
                throw new ArgumentNullException(nameof(pull));
            }

            this.touch = touch;

            this.pull = pull;
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
