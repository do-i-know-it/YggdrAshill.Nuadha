using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class StickEventSystem :
        ISoftware<IStickSoftwareHandler>,
        IDisconnection
    {
        private readonly TouchEventSystem touch;
        
        private readonly PushEventSystem push;

        private readonly TiltEventSystem tilt;

        public StickEventSystem(ITiltThreshold threshold, IStickEventInputHandler handler)
        {
            if (threshold == null)
            {
                throw new ArgumentNullException(nameof(threshold));
            }
            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }

            touch = new TouchEventSystem(handler.Touch);

            push = new PushEventSystem(handler.Push);
            
            tilt = new TiltEventSystem(threshold, handler.Tilt);
        }

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
