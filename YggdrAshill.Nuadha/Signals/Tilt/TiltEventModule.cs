using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Translation;
using YggdrAshill.Nuadha.Units;

namespace YggdrAshill.Nuadha
{
    public sealed class TiltEventModule :
        ITiltEventInputHandler,
        ITiltEventOutputHandler,
        IDisconnection
    {
        private readonly PulseEventModule left = new PulseEventModule();
        
        private readonly PulseEventModule right = new PulseEventModule();
        
        private readonly PulseEventModule forward = new PulseEventModule();
        
        private readonly PulseEventModule backward = new PulseEventModule();

        #region ITiltEventInputHandler

        IPulseEventInputHandler ITiltEventInputHandler.Left => left;

        IPulseEventInputHandler ITiltEventInputHandler.Right => right;

        IPulseEventInputHandler ITiltEventInputHandler.Forward => forward;

        IPulseEventInputHandler ITiltEventInputHandler.Backward => backward;

        #endregion

        #region ITiltEventOutputHandler

        IPulseEventOutputHandler ITiltEventOutputHandler.Left => left;

        IPulseEventOutputHandler ITiltEventOutputHandler.Right => right;

        IPulseEventOutputHandler ITiltEventOutputHandler.Forward => forward;

        IPulseEventOutputHandler ITiltEventOutputHandler.Backward => backward;

        #endregion

        #region IDisconnection

        public void Disconnect()
        {
            left.Disconnect();

            right.Disconnect();

            forward.Disconnect();
         
            backward.Disconnect();
        }

        #endregion
    }
}
