using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Conversion;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class TiltDetectionSystem :
        IConsumption<Tilt>,
        IHardware<ITiltDetectionInputHandler>,
        IDisconnection
    {
        private readonly Propagation<Tilt> propagation;

        private readonly PullDetectionSystem left;
        
        private readonly PullDetectionSystem right;
        
        private readonly PullDetectionSystem forward;
        
        private readonly PullDetectionSystem backward;

        public TiltDetectionSystem(ITiltThreshold threshold)
        {
            if (threshold == null)
            {
                throw new ArgumentNullException(nameof(threshold));
            }

            propagation = new Propagation<Tilt>();

            left = new PullDetectionSystem(threshold.Left);
            right = new PullDetectionSystem(threshold.Right);
            forward = new PullDetectionSystem(threshold.Forward);
            backward = new PullDetectionSystem(threshold.Backward);

            propagation.Translate(TiltToPull.Left).Connect(left);
            propagation.Translate(TiltToPull.Right).Connect(right);
            propagation.Translate(TiltToPull.Up).Connect(forward);
            propagation.Translate(TiltToPull.Down).Connect(backward);
        }

        #region IHardware

        public IDisconnection Connect(ITiltDetectionInputHandler handler)
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

        #endregion

        #region IConsumption

        public void Consume(Tilt signal)
        {
            propagation.Consume(signal);
        }

        #endregion

        #region IDisconnection

        public void Disconnect()
        {
            propagation.Disconnect();

            left.Disconnect();

            right.Disconnect();

            forward.Disconnect();
            
            backward.Disconnect();
        }

        #endregion
    }
}
