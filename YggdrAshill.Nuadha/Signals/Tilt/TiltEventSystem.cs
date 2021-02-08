using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Translation;
using YggdrAshill.Nuadha.Signals;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class TiltEventSystem :
        IInputTerminal<Tilt>,
        IDisconnection
    {
        private readonly Connector<Tilt> connector;

        private readonly PullEventSystem left;
        
        private readonly PullEventSystem right;
        
        private readonly PullEventSystem forward;
        
        private readonly PullEventSystem backward;

        public TiltEventSystem(ITiltThreshold threshold, ITiltEventInputHandler handler)
        {
            if (threshold == null)
            {
                throw new ArgumentNullException(nameof(threshold));
            }
            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }

            connector = new Connector<Tilt>();

            left = new PullEventSystem(threshold.Left, handler.Left);
            right = new PullEventSystem(threshold.Right, handler.Right);
            forward = new PullEventSystem(threshold.Forward, handler.Forward);
            backward = new PullEventSystem(threshold.Backward, handler.Backward);

            connector.Convert(TiltToPull.Left).Connect(left);
            connector.Convert(TiltToPull.Right).Connect(right);
            connector.Convert(TiltToPull.Up).Connect(forward);
            connector.Convert(TiltToPull.Down).Connect(backward);
        }

        public void Receive(Tilt signal)
        {
            connector.Receive(signal);
        }

        public void Disconnect()
        {
            connector.Disconnect();

            left.Disconnect();

            right.Disconnect();

            forward.Disconnect();
            
            backward.Disconnect();
        }
    }
}
