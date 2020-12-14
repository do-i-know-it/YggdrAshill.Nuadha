using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class StickEventInputSystem :
        ISoftware<IStickSoftwareHandler>,
        IStickEventOutputHandler,
        IDisconnection
    {
        private readonly TouchEventInputSystem touch;
        
        private readonly PushEventInputSystem push;

        private readonly TiltEventInputSystem tilt;

        public StickEventInputSystem(HysteresisThreshold threshold)
        {
            touch = new TouchEventInputSystem();

            push = new PushEventInputSystem();
            
            tilt = new TiltEventInputSystem(threshold);
        }

        #region IStickEventOutputHandler

        public ITouchEventOutputHandler Touch => touch;

        public IPushEventOutputHandler Push => push;

        public ITiltEventOutputHandler Tilt => tilt;

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
