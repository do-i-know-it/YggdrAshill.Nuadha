using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Units;

namespace YggdrAshill.Nuadha
{
    public sealed class HandControllerDetectionModule :
        IHandControllerDetectionSystem,
        IHandControllerDetectionDevice,
        IDisconnection
    {
        private readonly StickDetectionModule thumbStick = new StickDetectionModule();

        private readonly TriggerDetectionModule fingerTrigger = new TriggerDetectionModule();

        private readonly TriggerDetectionModule handTrigger = new TriggerDetectionModule();

        #region IHandControllerDetectionSystem

        IStickDetectionSystem IHandControllerDetectionSystem.ThumbStick => thumbStick;

        ITriggerDetectionSystem IHandControllerDetectionSystem.FingerTrigger => fingerTrigger;

        ITriggerDetectionSystem IHandControllerDetectionSystem.HandTrigger => handTrigger;

        #endregion

        #region IHandControllerDetectionDevice

        IStickDetectionDevice IHandControllerDetectionDevice.ThumbStick => thumbStick;

        ITriggerDetectionDevice IHandControllerDetectionDevice.FingerTrigger => fingerTrigger;

        ITriggerDetectionDevice IHandControllerDetectionDevice.HandTrigger => handTrigger;

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
