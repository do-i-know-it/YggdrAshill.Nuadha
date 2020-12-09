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

        public StickEventSystem(HysteresisThreshold threshold)
        {
            touch = new TouchEventSystem();

            push = new PushEventSystem();
            
            tilt = new TiltEventSystem(threshold);
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
