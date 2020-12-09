using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Signals;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class StickEventSystem :
        IStickEventSystem
    {
        private readonly ITouchEventSystem touch;
        
        private readonly IPushEventSystem push;

        private readonly ITiltEventSystem tilt;

        public StickEventSystem(ITouchEventSystem touch, IPushEventSystem push, ITiltEventSystem tilt)
        {
            if (touch == null)
            {
                throw new ArgumentNullException(nameof(touch));
            }
            if (push == null)
            {
                throw new ArgumentNullException(nameof(push));
            }
            if (tilt == null)
            {
                throw new ArgumentNullException(nameof(tilt));
            }
            
            this.touch = touch;

            this.push = push;
            
            this.tilt = tilt;
        }

        #region IButtonEventHandler

        public ITouchEventHandler Touch => touch;

        public IPushEventHandler Push => push;

        public ITiltEventHandler Tilt => tilt;

        #endregion

        #region ISoftware

        public IDisconnection Connect(IStickSoftwareHandler handler)
        {
            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }

            var touch = handler.Touch.Connect(this.touch);

            var push = handler.Push.Connect(this.push);
            
            var tilt = handler.Tilt.Connect(this.tilt);

            return new Disconnection(() =>
            {
                touch.Disconnect();

                push.Disconnect();

                tilt.Disconnect();
            });
        }

        #endregion

        #region IDisconnection

        public void Disconnect()
        {
            touch.Disconnect();

            push.Disconnect();

            tilt.Disconnect();
        }

        #endregion
    }
}
