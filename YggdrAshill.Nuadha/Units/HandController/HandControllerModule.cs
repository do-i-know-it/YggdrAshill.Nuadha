using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Units;

namespace YggdrAshill.Nuadha
{
    public sealed class HandControllerModule :
        IHandControllerSoftwareHandler,
        IHandControllerHardwareHandler,
        IDisconnection
    {
        private readonly PoseTrackerModule poseTracker = new PoseTrackerModule();

        private readonly StickModule thumbStick = new StickModule();

        private readonly TriggerModule fingerTrigger = new TriggerModule();

        private readonly TriggerModule handTrigger = new TriggerModule();

        #region IHandControllerSoftwareHandler

        IPoseTrackerSoftwareHandler IHandControllerSoftwareHandler.PoseTracker => poseTracker;

        IStickSoftwareHandler IHandControllerSoftwareHandler.ThumbStick => thumbStick;

        ITriggerSoftwareHandler IHandControllerSoftwareHandler.FingerTrigger => fingerTrigger;

        ITriggerSoftwareHandler IHandControllerSoftwareHandler.HandTrigger => handTrigger;

        #endregion

        #region IHandControllerHardwareHandler
        
        IPoseTrackerHardwareHandler IHandControllerHardwareHandler.PoseTracker => poseTracker;

        IStickHardwareHandler IHandControllerHardwareHandler.ThumbStick => thumbStick;

        ITriggerHardwareHandler IHandControllerHardwareHandler.FingerTrigger => fingerTrigger;

        ITriggerHardwareHandler IHandControllerHardwareHandler.HandTrigger => handTrigger;

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
