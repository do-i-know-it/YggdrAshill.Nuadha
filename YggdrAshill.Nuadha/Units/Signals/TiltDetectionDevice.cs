using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Conversion;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class TiltDetectionDevice :
        IHardware<ITiltDetectionSystem>
    {
        private readonly PullDetectionDevice left;
        
        private readonly PullDetectionDevice right;
        
        private readonly PullDetectionDevice forward;
        
        private readonly PullDetectionDevice backward;

        public TiltDetectionDevice(IConnection<Tilt> connection, ITiltThreshold threshold)
        {
            if (connection == null)
            {
                throw new ArgumentNullException(nameof(connection));
            }
            if (threshold == null)
            {
                throw new ArgumentNullException(nameof(threshold));
            }

            left = new PullDetectionDevice(connection.Translate(TiltToPull.Left), threshold.Left);
            right = new PullDetectionDevice(connection.Translate(TiltToPull.Right), threshold.Right);
            forward = new PullDetectionDevice(connection.Translate(TiltToPull.Forward), threshold.Forward);
            backward = new PullDetectionDevice(connection.Translate(TiltToPull.Backward), threshold.Backward);
        }

        public IDisconnection Connect(ITiltDetectionSystem system)
        {
            if (system == null)
            {
                throw new ArgumentNullException(nameof(system));
            }

            var left = this.left.Connect(system.Left);
            var right = this.right.Connect(system.Right);
            var forward = this.forward.Connect(system.Forward);
            var backward = this.backward.Connect(system.Backward);

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
