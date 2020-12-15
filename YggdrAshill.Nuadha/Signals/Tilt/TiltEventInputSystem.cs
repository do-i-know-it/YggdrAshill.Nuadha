using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Signals;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class TiltEventInputSystem :
        IInputTerminal<Tilt>,
        ITiltEventOutputHandler,
        IDisconnection
    {
        private readonly Connector<Tilt> connector;

        private readonly PullEventInputSystem center;

        private readonly PullEventInputSystem left;
        
        private readonly PullEventInputSystem right;
        
        private readonly PullEventInputSystem forward;
        
        private readonly PullEventInputSystem backward;

        public TiltEventInputSystem(ITiltThreshold threshold)
        {
            if (threshold == null)
            {
                throw new ArgumentNullException(nameof(threshold));
            }

            connector = new Connector<Tilt>();

            center = new PullEventInputSystem(threshold.Center);
            left = new PullEventInputSystem(threshold.Left);
            right = new PullEventInputSystem(threshold.Right);
            forward = new PullEventInputSystem(threshold.Forward);
            backward = new PullEventInputSystem(threshold.Backward);

            connector.Convert(TiltToPull.Tilted).Connect(center);
            connector.Convert(TiltToPull.Left).Connect(left);
            connector.Convert(TiltToPull.Right).Connect(right);
            connector.Convert(TiltToPull.Up).Connect(forward);
            connector.Convert(TiltToPull.Down).Connect(backward);
        }

        #region ITiltEventOutputHandler

        public IPullEventOutputHandler Center => center;

        public IPullEventOutputHandler Left => left;

        public IPullEventOutputHandler Right => right;

        public IPullEventOutputHandler Forward => forward;

        public IPullEventOutputHandler Backward => backward;

        #endregion

        #region IInputTerminal

        public void Receive(Tilt signal)
        {
            connector.Receive(signal);
        }

        #endregion

        #region IDisconnection

        public void Disconnect()
        {
            connector.Disconnect();

            center.Disconnect();

            left.Disconnect();

            right.Disconnect();

            forward.Disconnect();
            
            backward.Disconnect();
        }

        #endregion
    }
}
