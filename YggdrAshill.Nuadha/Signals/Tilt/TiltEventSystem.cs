using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Signals;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class TiltEventSystem :
        ITiltEventSystem
    {
        private readonly PullEventSystem center;

        private readonly PullEventSystem left;
        
        private readonly PullEventSystem right;
        
        private readonly PullEventSystem up;
        
        private readonly PullEventSystem down;

        public TiltEventSystem(HysteresisThreshold threshold)
        {
            center = new PullEventSystem(threshold);
          
            left = new PullEventSystem(threshold);
            
            right = new PullEventSystem(threshold);
            
            up = new PullEventSystem(threshold);
            
            down = new PullEventSystem(threshold);
        }

        #region ITiltEventHandler

        public IPullEventHandler Center => center;

        public IPullEventHandler Left => left;

        public IPullEventHandler Right => right;

        public IPullEventHandler Up => up;

        public IPullEventHandler Down => down;

        #endregion

        #region IDivider

        public IDisconnection Connect(IOutputTerminal<Tilt> terminal)
        {
            if (terminal == null)
            {
                throw new ArgumentNullException(nameof(terminal));
            }

            var center = terminal.Convert(TiltToPull.Tilted).Connect(this.center);

            var left = terminal.Convert(TiltToPull.Left).Connect(this.left);
            
            var right = terminal.Convert(TiltToPull.Right).Connect(this.right);
            
            var up = terminal.Convert(TiltToPull.Up).Connect(this.up);
            
            var down = terminal.Convert(TiltToPull.Down).Connect(this.down);

            return new Disconnection(() =>
            {
                center.Disconnect();

                left.Disconnect();

                right.Disconnect();

                up.Disconnect();

                down.Disconnect();
            });
        }

        #endregion

        #region IDisconnection

        public void Disconnect()
        {
            center.Disconnect();

            left.Disconnect();

            right.Disconnect();

            up.Disconnect();
            
            down.Disconnect();
        }

        #endregion
    }
}
