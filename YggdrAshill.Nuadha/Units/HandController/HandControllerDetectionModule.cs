using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Units;

namespace YggdrAshill.Nuadha
{
    public sealed class HandControllerDetectionModule :
        IHandControllerDetectionSoftware,
        IHandControllerDetectionHardware,
        IDisconnection
    {
        private readonly StickDetectionModule thumbStick = new StickDetectionModule();

        private readonly TriggerDetectionModule fingerTrigger = new TriggerDetectionModule();

        private readonly TriggerDetectionModule handTrigger = new TriggerDetectionModule();

        #region IHandControllerDetectionSoftware

        IStickDetectionSoftware IHandControllerDetectionSoftware.ThumbStick => thumbStick;

        ITriggerDetectionSoftware IHandControllerDetectionSoftware.FingerTrigger => fingerTrigger;

        ITriggerDetectionSoftware IHandControllerDetectionSoftware.HandTrigger => handTrigger;

        #endregion

        #region IHandControllerDetectionHardware

        IStickDetectionHardware IHandControllerDetectionHardware.ThumbStick => thumbStick;

        ITriggerDetectionHardware IHandControllerDetectionHardware.FingerTrigger => fingerTrigger;

        ITriggerDetectionHardware IHandControllerDetectionHardware.HandTrigger => handTrigger;

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
