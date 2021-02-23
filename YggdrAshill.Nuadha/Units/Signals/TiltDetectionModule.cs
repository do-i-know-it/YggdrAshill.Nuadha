using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Units;

namespace YggdrAshill.Nuadha
{
    public sealed class TiltDetectionModule :
        ITiltDetectionHardwareHandler,
        ITiltDetectionSoftwareHandler,
        IDisconnection
    {
        private readonly PulseDetectionModule left = new PulseDetectionModule();
        
        private readonly PulseDetectionModule right = new PulseDetectionModule();
        
        private readonly PulseDetectionModule forward = new PulseDetectionModule();
        
        private readonly PulseDetectionModule backward = new PulseDetectionModule();

        #region ITiltDetectionInputHandler

        IDetectionHardwareHandler ITiltDetectionHardwareHandler.Left => left;

        IDetectionHardwareHandler ITiltDetectionHardwareHandler.Right => right;

        IDetectionHardwareHandler ITiltDetectionHardwareHandler.Forward => forward;

        IDetectionHardwareHandler ITiltDetectionHardwareHandler.Backward => backward;

        #endregion

        #region ITiltDetectionOutputHandler

        IDetectionSoftwareHandler ITiltDetectionSoftwareHandler.Left => left;

        IDetectionSoftwareHandler ITiltDetectionSoftwareHandler.Right => right;

        IDetectionSoftwareHandler ITiltDetectionSoftwareHandler.Forward => forward;

        IDetectionSoftwareHandler ITiltDetectionSoftwareHandler.Backward => backward;

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
