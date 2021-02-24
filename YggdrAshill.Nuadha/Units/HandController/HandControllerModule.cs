using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Units;

namespace YggdrAshill.Nuadha
{
    public sealed class HandControllerModule :
        IHandControllerSoftware,
        IHandControllerHardware,
        IDisconnection
    {
        private readonly PoseTrackerModule poseTracker = new PoseTrackerModule();

        private readonly StickModule thumbStick = new StickModule();

        private readonly TriggerModule fingerTrigger = new TriggerModule();

        private readonly TriggerModule handTrigger = new TriggerModule();

        #region IHandControllerSoftware

        IPoseTrackerSoftware IHandControllerSoftware.PoseTracker => poseTracker;

        IStickSoftware IHandControllerSoftware.ThumbStick => thumbStick;

        ITriggerSoftware IHandControllerSoftware.FingerTrigger => fingerTrigger;

        ITriggerSoftware IHandControllerSoftware.HandTrigger => handTrigger;

        #endregion

        #region IHandControllerHardware

        IPoseTrackerHardware IHandControllerHardware.PoseTracker => poseTracker;

        IStickHardware IHandControllerHardware.ThumbStick => thumbStick;

        ITriggerHardware IHandControllerHardware.FingerTrigger => fingerTrigger;

        ITriggerHardware IHandControllerHardware.HandTrigger => handTrigger;

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
