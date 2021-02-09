using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class StickDetectionSystem :
        ISoftware<IStickSoftwareHandler>,
        IHardware<IStickDetectionInputHandler>,
        IDisconnection
    {
        private readonly TouchDetectionSystem touch = new TouchDetectionSystem();
        
        private readonly PushDetectionSystem push = new PushDetectionSystem();

        private readonly TiltDetectionSystem tilt;

        public StickDetectionSystem(ITiltThreshold threshold)
        {
            if (threshold == null)
            {
                throw new ArgumentNullException(nameof(threshold));
            }

            tilt = new TiltDetectionSystem(threshold);
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

        #region IHardware

        public IDisconnection Connect(IStickDetectionInputHandler handler)
        {
            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }

            var touch = this.touch.Connect(handler.Touch);

            var push = this.push.Connect(handler.Push);

            return new Disconnection(() =>
            {
                touch.Disconnect();

                push.Disconnect();
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
