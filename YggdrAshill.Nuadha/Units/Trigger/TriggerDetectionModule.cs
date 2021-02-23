using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Units;

namespace YggdrAshill.Nuadha
{
    public sealed class TriggerDetectionModule :
        ITriggerDetectionSystem,
        ITriggerDetectionDevice,
        IDisconnection
    {
        private readonly PulseDetectionModule touch = new PulseDetectionModule();

        private readonly PulseDetectionModule pull = new PulseDetectionModule();

        #region ITriggerDetectionSystem

        IDetectionSystem ITriggerDetectionSystem.Touch => touch;

        IDetectionSystem ITriggerDetectionSystem.Pull => pull;

        #endregion

        #region ITriggerDetectionDevice

        IDetectionDevice ITriggerDetectionDevice.Touch => touch;

        IDetectionDevice ITriggerDetectionDevice.Pull => pull;

        #endregion

        #region IDisconnection

        public void Disconnect()
        {
            touch.Disconnect();

            pull.Disconnect();
        }

        #endregion
    }
}
