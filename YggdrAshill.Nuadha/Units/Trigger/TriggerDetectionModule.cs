using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Units;

namespace YggdrAshill.Nuadha
{
    public sealed class TriggerDetectionModule :
        ITriggerDetectionHardwareHandler,
        ITriggerDetectionSoftwareHandler,
        IDisconnection
    {
        private readonly PulseDetectionModule touch = new PulseDetectionModule();

        private readonly PulseDetectionModule pull = new PulseDetectionModule();

        #region ITriggerDetectionHardwareHandler

        IDetectionHardwareHandler ITriggerDetectionHardwareHandler.Touch => touch;

        IDetectionHardwareHandler ITriggerDetectionHardwareHandler.Pull => pull;

        #endregion

        #region ITriggerDetectionSoftwareHandler

        IDetectionSoftwareHandler ITriggerDetectionSoftwareHandler.Touch => touch;

        IDetectionSoftwareHandler ITriggerDetectionSoftwareHandler.Pull => pull;

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
