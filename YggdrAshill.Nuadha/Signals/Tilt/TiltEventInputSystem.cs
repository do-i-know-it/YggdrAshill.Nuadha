using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Translation;
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

            left = new PullEventInputSystem(threshold.Left);
            right = new PullEventInputSystem(threshold.Right);
            forward = new PullEventInputSystem(threshold.Forward);
            backward = new PullEventInputSystem(threshold.Backward);

            connector.Convert(TiltToPull.Left).Connect(left);
            connector.Convert(TiltToPull.Right).Connect(right);
            connector.Convert(TiltToPull.Up).Connect(forward);
            connector.Convert(TiltToPull.Down).Connect(backward);
        }

        #region ITiltEventOutputHandler

        public IPulseEventOutputHandler Left => left;

        public IPulseEventOutputHandler Right => right;

        public IPulseEventOutputHandler Forward => forward;

        public IPulseEventOutputHandler Backward => backward;

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

            left.Disconnect();

            right.Disconnect();

            forward.Disconnect();
            
            backward.Disconnect();
        }

        #endregion
    }
}
