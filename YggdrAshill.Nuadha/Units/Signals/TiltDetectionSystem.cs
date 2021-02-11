using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Conversion;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class TiltDetectionSystem :
        IHardware<ITiltDetectionHardwareHandler>
    {
        private readonly PullDetectionSystem left;
        
        private readonly PullDetectionSystem right;
        
        private readonly PullDetectionSystem forward;
        
        private readonly PullDetectionSystem backward;

        public TiltDetectionSystem(IConnection<Tilt> connection, ITiltThreshold threshold)
        {
            if (connection == null)
            {
                throw new ArgumentNullException(nameof(connection));
            }
            if (threshold == null)
            {
                throw new ArgumentNullException(nameof(threshold));
            }

            left = new PullDetectionSystem(connection.Translate(TiltToPull.Left), threshold.Left);
            right = new PullDetectionSystem(connection.Translate(TiltToPull.Right), threshold.Right);
            forward = new PullDetectionSystem(connection.Translate(TiltToPull.Up), threshold.Forward);
            backward = new PullDetectionSystem(connection.Translate(TiltToPull.Down), threshold.Backward);
        }

        public IDisconnection Connect(ITiltDetectionHardwareHandler handler)
        {
            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }

            var left = this.left.Connect(handler.Left);
            var right = this.right.Connect(handler.Right);
            var forward = this.forward.Connect(handler.Forward);
            var backward = this.backward.Connect(handler.Backward);

            return new Disconnection(() =>
            {
                left.Disconnect();

                right.Disconnect();

                forward.Disconnect();

                backward.Disconnect();
            });
        }
    }
}
