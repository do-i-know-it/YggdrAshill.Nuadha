using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class StickDetectionSystem :
        IHardware<IStickDetectionHardwareHandler>
    {
        private readonly TouchDetectionSystem touch;

        private readonly PushDetectionSystem push;

        private readonly TiltDetectionSystem tilt;

        public StickDetectionSystem(IStickSoftwareHandler handler, ITiltThreshold threshold)
        {
            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }
            if (threshold == null)
            {
                throw new ArgumentNullException(nameof(threshold));
            }

            touch = new TouchDetectionSystem(handler.Touch);

            push = new PushDetectionSystem(handler.Push);

            tilt = new TiltDetectionSystem(handler.Tilt, threshold);
        }

        public IDisconnection Connect(IStickDetectionHardwareHandler handler)
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
    }
}
