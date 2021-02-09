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

            propagation.Convert(TiltToPull.Left).Connect(left);
            propagation.Convert(TiltToPull.Right).Connect(right);
            propagation.Convert(TiltToPull.Up).Connect(forward);
            propagation.Convert(TiltToPull.Down).Connect(backward);
        }

        public IDisconnection Connect(ITiltDetectionInputHandler handler)
        {
            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }

            throw new NotImplementedException();
        }

        public void Consume(Tilt signal)
        {
            propagation.Consume(signal);
        }

        public void Disconnect()
        {
            propagation.Disconnect();

            left.Disconnect();

            right.Disconnect();

            forward.Disconnect();
            
            backward.Disconnect();
        }
    }
}
