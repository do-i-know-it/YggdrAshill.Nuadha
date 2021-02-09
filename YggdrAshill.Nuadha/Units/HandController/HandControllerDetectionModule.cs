using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Units;

namespace YggdrAshill.Nuadha
{
    public sealed class HandControllerDetectionModule :
        IHandControllerDetectionInputHandler,
        IHandControllerDetectionOutputHandler,
        IDisconnection
    {
        private readonly StickDetectionModule thumbStick = new StickDetectionModule();

        private readonly TriggerDetectionModule fingerTrigger = new TriggerDetectionModule();

        private readonly TriggerDetectionModule handTrigger = new TriggerDetectionModule();

        #region IHandControllerDetectionInputHandler

        IStickDetectionInputHandler IHandControllerDetectionInputHandler.ThumbStick => thumbStick;

        ITriggerDetectionInputHandler IHandControllerDetectionInputHandler.FingerTrigger => fingerTrigger;

        ITriggerDetectionInputHandler IHandControllerDetectionInputHandler.HandTrigger => handTrigger;

        #endregion

        #region IHandControllerDetectionOutputHandler

        IStickDetectionOutputHandler IHandControllerDetectionOutputHandler.ThumbStick => thumbStick;

        ITriggerDetectionOutputHandler IHandControllerDetectionOutputHandler.FingerTrigger => fingerTrigger;

        ITriggerDetectionOutputHandler IHandControllerDetectionOutputHandler.HandTrigger => handTrigger;

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
