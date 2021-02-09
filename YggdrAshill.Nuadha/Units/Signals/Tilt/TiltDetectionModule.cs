using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Units;

namespace YggdrAshill.Nuadha
{
    public sealed class TiltDetectionModule :
        ITiltDetectionInputHandler,
        ITiltDetectionOutputHandler,
        IDisconnection
    {
        private readonly PulseDetectionModule left = new PulseDetectionModule();
        
        private readonly PulseDetectionModule right = new PulseDetectionModule();
        
        private readonly PulseDetectionModule forward = new PulseDetectionModule();
        
        private readonly PulseDetectionModule backward = new PulseDetectionModule();

        #region ITiltDetectionInputHandler

        IPulseDetectionInputHandler ITiltDetectionInputHandler.Left => left;

        IPulseDetectionInputHandler ITiltDetectionInputHandler.Right => right;

        IPulseDetectionInputHandler ITiltDetectionInputHandler.Forward => forward;

        IPulseDetectionInputHandler ITiltDetectionInputHandler.Backward => backward;

        #endregion

        #region ITiltDetectionOutputHandler

        IPulseDetectionOutputHandler ITiltDetectionOutputHandler.Left => left;

        IPulseDetectionOutputHandler ITiltDetectionOutputHandler.Right => right;

        IPulseDetectionOutputHandler ITiltDetectionOutputHandler.Forward => forward;

        IPulseDetectionOutputHandler ITiltDetectionOutputHandler.Backward => backward;

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
