using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha
{
    public sealed class TiltEventModule :
        ITiltEventInputHandler,
        IDisconnection
    {
        private readonly PullEventModule center = new PullEventModule();
        
        private readonly PullEventModule left = new PullEventModule();
        
        private readonly PullEventModule right = new PullEventModule();
        
        private readonly PullEventModule up = new PullEventModule();
        
        private readonly PullEventModule down = new PullEventModule();

        #region ITiltEventInputHandler

        IPullEventInputHandler ITiltEventInputHandler.Center => center;

        IPullEventInputHandler ITiltEventInputHandler.Left => left;

        IPullEventInputHandler ITiltEventInputHandler.Right => right;

        IPullEventInputHandler ITiltEventInputHandler.Up => up;

        IPullEventInputHandler ITiltEventInputHandler.Down => down;

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
