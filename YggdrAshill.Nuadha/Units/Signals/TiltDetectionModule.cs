using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Units;

namespace YggdrAshill.Nuadha
{
    public sealed class TiltDetectionModule :
        ITiltDetectionSystem,
        ITiltDetectionDevice,
        IDisconnection
    {
        private readonly PulseDetectionModule left = new PulseDetectionModule();
        
        private readonly PulseDetectionModule right = new PulseDetectionModule();
        
        private readonly PulseDetectionModule forward = new PulseDetectionModule();
        
        private readonly PulseDetectionModule backward = new PulseDetectionModule();

        #region ITiltDetectionSystem

        IDetectionSystem ITiltDetectionSystem.Left => left;

        IDetectionSystem ITiltDetectionSystem.Right => right;

        IDetectionSystem ITiltDetectionSystem.Forward => forward;

        IDetectionSystem ITiltDetectionSystem.Backward => backward;

        #endregion

        #region ITiltDetectionDevice

        IDetectionDevice ITiltDetectionDevice.Left => left;

        IDetectionDevice ITiltDetectionDevice.Right => right;

        IDetectionDevice ITiltDetectionDevice.Forward => forward;

        IDetectionDevice ITiltDetectionDevice.Backward => backward;

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
