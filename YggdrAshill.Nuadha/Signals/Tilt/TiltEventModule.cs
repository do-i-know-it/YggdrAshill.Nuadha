using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha
{
    public sealed class TiltEventModule :
        ITiltEventInputHandler,
        ITiltEventOutputHandler,
        IDisconnection
    {
        private readonly PullEventModule center = new PullEventModule();
        
        private readonly PullEventModule left = new PullEventModule();
        
        private readonly PullEventModule right = new PullEventModule();
        
        private readonly PullEventModule forward = new PullEventModule();
        
        private readonly PullEventModule backward = new PullEventModule();

        #region ITiltEventInputHandler

        IPullEventInputHandler ITiltEventInputHandler.Center => center;

        IPullEventInputHandler ITiltEventInputHandler.Left => left;

        IPullEventInputHandler ITiltEventInputHandler.Right => right;

        IPullEventInputHandler ITiltEventInputHandler.Forward => forward;

        IPullEventInputHandler ITiltEventInputHandler.Backward => backward;

        #endregion

        #region ITiltEventOutputHandler

        IPullEventOutputHandler ITiltEventOutputHandler.Center => center;

        IPullEventOutputHandler ITiltEventOutputHandler.Left => left;

        IPullEventOutputHandler ITiltEventOutputHandler.Right => right;

        IPullEventOutputHandler ITiltEventOutputHandler.Forward => forward;

        IPullEventOutputHandler ITiltEventOutputHandler.Backward => backward;

        #endregion

        #region IDisconnection

        public void Disconnect()
        {
            center.Disconnect();

            left.Disconnect();

            right.Disconnect();

            forward.Disconnect();
         
            backward.Disconnect();
        }

        #endregion
    }
}
