using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Units;

namespace YggdrAshill.Nuadha
{
    public sealed class TiltDetectionModule :
        ITiltDetectionSoftware,
        ITiltDetectionHardware,
        IDisconnection
    {
        private readonly PulseDetectionModule left = new PulseDetectionModule();
        
        private readonly PulseDetectionModule right = new PulseDetectionModule();
        
        private readonly PulseDetectionModule forward = new PulseDetectionModule();
        
        private readonly PulseDetectionModule backward = new PulseDetectionModule();

        #region ITiltDetectionSoftware

        IDetectionSoftware ITiltDetectionSoftware.Left => left;

        IDetectionSoftware ITiltDetectionSoftware.Right => right;

        IDetectionSoftware ITiltDetectionSoftware.Forward => forward;

        IDetectionSoftware ITiltDetectionSoftware.Backward => backward;

        #endregion

        #region ITiltDetectionHardware

        IDetectionHardware ITiltDetectionHardware.Left => left;

        IDetectionHardware ITiltDetectionHardware.Right => right;

        IDetectionHardware ITiltDetectionHardware.Forward => forward;

        IDetectionHardware ITiltDetectionHardware.Backward => backward;

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
