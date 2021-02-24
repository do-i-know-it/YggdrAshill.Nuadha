using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Units;

namespace YggdrAshill.Nuadha
{
    public sealed class TriggerDetectionModule :
        ITriggerDetectionSoftware,
        ITriggerDetectionHardware,
        IDisconnection
    {
        private readonly PulseDetectionModule touch = new PulseDetectionModule();

        private readonly PulseDetectionModule pull = new PulseDetectionModule();

        #region ITriggerDetectionSoftware

        IDetectionSoftware ITriggerDetectionSoftware.Touch => touch;

        IDetectionSoftware ITriggerDetectionSoftware.Pull => pull;

        #endregion

        #region ITriggerDetectionHardware

        IDetectionHardware ITriggerDetectionHardware.Touch => touch;

        IDetectionHardware ITriggerDetectionHardware.Pull => pull;

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
