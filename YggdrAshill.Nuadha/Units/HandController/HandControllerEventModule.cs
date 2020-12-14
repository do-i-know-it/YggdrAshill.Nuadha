using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Units;

namespace YggdrAshill.Nuadha
{
    public sealed class HandControllerEventModule :
        IHandControllerEventInputHandler,
        IHandControllerEventOutputHandler,
        IDisconnection
    {
        private readonly StickEventModule thumbStick = new StickEventModule();

        private readonly TriggerEventModule fingerTrigger = new TriggerEventModule();

        private readonly TriggerEventModule handTrigger = new TriggerEventModule();

        #region IHandControllerEventInputHandler

        IStickEventInputHandler IHandControllerEventInputHandler.ThumbStick => thumbStick;

        ITriggerEventInputHandler IHandControllerEventInputHandler.FingerTrigger => fingerTrigger;

        ITriggerEventInputHandler IHandControllerEventInputHandler.HandTrigger => handTrigger;

        #endregion

        #region IHandControllerEventOutputHandler

        IStickEventOutputHandler IHandControllerEventOutputHandler.ThumbStick => thumbStick;

        ITriggerEventOutputHandler IHandControllerEventOutputHandler.FingerTrigger => fingerTrigger;

        ITriggerEventOutputHandler IHandControllerEventOutputHandler.HandTrigger => handTrigger;

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
