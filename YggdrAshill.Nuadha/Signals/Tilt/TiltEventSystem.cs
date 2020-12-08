using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Signals;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class TiltEventSystem :
        ITiltEventSystem
    {
        private readonly PullEventSystem tilted;
        private readonly PullEventSystem left;
        private readonly PullEventSystem right;
        private readonly PullEventSystem up;
        private readonly PullEventSystem down;

        public TiltEventSystem(
            PullEventSystem tilted,
            PullEventSystem left,
            PullEventSystem right, 
            PullEventSystem up, 
            PullEventSystem down)
        {
            if (tilted == null)
            {
                throw new ArgumentNullException(nameof(tilted));
            }
            if (left == null)
            {
                throw new ArgumentNullException(nameof(left));
            }
            if (right == null)
            {
                throw new ArgumentNullException(nameof(right));
            }
            if (up == null)
            {
                throw new ArgumentNullException(nameof(up));
            }
            if (down == null)
            {
                throw new ArgumentNullException(nameof(down));
            }

            this.tilted = tilted;
            
            this.left = left;
            
            this.right = right;
            
            this.up = up;
            
            this.down = down;
        }

        #region ITiltEventHandler

        public IPullEventHandler Tilted => tilted;

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

            var tilted = terminal.Convert(TiltToPull.Tilted).Connect(this.tilted);

            var left = terminal.Convert(TiltToPull.Left).Connect(this.left);
            
            var right = terminal.Convert(TiltToPull.Right).Connect(this.right);
            
            var up = terminal.Convert(TiltToPull.Up).Connect(this.up);
            
            var down = terminal.Convert(TiltToPull.Down).Connect(this.down);

            return new Disconnection(() =>
            {
                tilted.Disconnect();

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
            tilted.Disconnect();

            left.Disconnect();

            right.Disconnect();

            up.Disconnect();
            
            down.Disconnect();
        }

        #endregion
    }
}
