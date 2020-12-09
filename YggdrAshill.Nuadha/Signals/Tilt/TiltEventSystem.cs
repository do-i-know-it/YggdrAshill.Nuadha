using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha
{
    public sealed class TiltEventSystem :
        ITiltEventSystem
    {
        private readonly IConnector<Tilt> connector;

        private readonly PullEventSystem center;

        private readonly PullEventSystem left;
        
        private readonly PullEventSystem right;
        
        private readonly PullEventSystem up;
        
        private readonly PullEventSystem down;

        public TiltEventSystem(HysteresisThreshold threshold)
        {
            connector = new Connector<Tilt>();

            center = new PullEventSystem(threshold);
            left = new PullEventSystem(threshold);
            right = new PullEventSystem(threshold);
            up = new PullEventSystem(threshold);
            down = new PullEventSystem(threshold);

            connector.Convert(TiltToPull.Tilted).Connect(center);
            connector.Convert(TiltToPull.Left).Connect(left);
            connector.Convert(TiltToPull.Right).Connect(right);
            connector.Convert(TiltToPull.Up).Connect(up);
            connector.Convert(TiltToPull.Down).Connect(down);
        }

        #region ITiltEventHandler

        public IPullEventHandler Center => center;

        public IPullEventHandler Left => left;

        public IPullEventHandler Right => right;

        public IPullEventHandler Up => up;

        public IPullEventHandler Down => down;

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

            up.Disconnect();
            
            down.Disconnect();
        }

        #endregion
    }
}
