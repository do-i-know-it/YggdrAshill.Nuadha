using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Units;

namespace YggdrAshill.Nuadha
{
    public sealed class HandControllerDetectionModule :
        IHandControllerDetectionHardwareHandler,
        IHandControllerDetectionSoftwareHandler,
        IDisconnection
    {
        private readonly StickDetectionModule thumbStick = new StickDetectionModule();

        private readonly TriggerDetectionModule fingerTrigger = new TriggerDetectionModule();

        private readonly TriggerDetectionModule handTrigger = new TriggerDetectionModule();

        #region IHandControllerDetectionHardwareHandler

        IStickDetectionHardwareHandler IHandControllerDetectionHardwareHandler.ThumbStick => thumbStick;

        ITriggerDetectionHardwareHandler IHandControllerDetectionHardwareHandler.FingerTrigger => fingerTrigger;

        ITriggerDetectionHardwareHandler IHandControllerDetectionHardwareHandler.HandTrigger => handTrigger;

        #endregion

        #region IHandControllerDetectionSoftwareHandler

        IStickDetectionSoftwareHandler IHandControllerDetectionSoftwareHandler.ThumbStick => thumbStick;

        ITriggerDetectionSoftwareHandler IHandControllerDetectionSoftwareHandler.FingerTrigger => fingerTrigger;

        ITriggerDetectionSoftwareHandler IHandControllerDetectionSoftwareHandler.HandTrigger => handTrigger;

        #endregion

        #region IDisconnection

        public void Disconnect()
        {
            thumbStick.Disconnect();

            fingerTrigger.Disconnect();

            handTrigger.Disconnect();
        }

        #endregion
    }
}
