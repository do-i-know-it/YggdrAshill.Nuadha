using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Units;

namespace YggdrAshill.Nuadha
{
    public sealed class HandControllerModule :
        IHandControllerDevice,
        IHandControllerSystem,
        IDisconnection
    {
        private readonly PoseTrackerModule poseTracker = new PoseTrackerModule();

        private readonly StickModule thumbStick = new StickModule();

        private readonly TriggerModule fingerTrigger = new TriggerModule();

        private readonly TriggerModule handTrigger = new TriggerModule();

        #region IHandControllerDevice

        IPoseTrackerDevice IHandControllerDevice.PoseTracker => poseTracker;

        IStickDevice IHandControllerDevice.ThumbStick => thumbStick;

        ITriggerDevice IHandControllerDevice.FingerTrigger => fingerTrigger;

        ITriggerDevice IHandControllerDevice.HandTrigger => handTrigger;

        #endregion

        #region IHandControllerSystem

        IPoseTrackerSystem IHandControllerSystem.PoseTracker => poseTracker;

        IStickSystem IHandControllerSystem.ThumbStick => thumbStick;

        ITriggerSystem IHandControllerSystem.FingerTrigger => fingerTrigger;

        ITriggerSystem IHandControllerSystem.HandTrigger => handTrigger;

        #endregion

        #region IDisconnection

        public void Disconnect()
        {
            poseTracker.Disconnect();

            thumbStick.Disconnect();

            fingerTrigger.Disconnect();

            handTrigger.Disconnect();
        }

        #endregion
    }
}
