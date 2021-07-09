using YggdrAshill.Nuadha.Unitization;
using System;

namespace YggdrAshill.Nuadha.Units
{
    public sealed class HandControllerModule :
        IModule<IHandControllerHardwareHandler, IHandControllerSoftwareHandler>,
        IHandControllerSoftwareHandler,
        IHandControllerHardwareHandler
    {
        private readonly PoseTrackerModule pose;

        private readonly StickModule thumb;

        private readonly TriggerModule indexFinger;

        private readonly TriggerModule handGrip;

        public HandControllerModule(PoseTrackerModule pose, StickModule thumb, TriggerModule indexFinger, TriggerModule handGrip)
        {
            if (pose == null)
            {
                throw new ArgumentNullException(nameof(pose));
            }
            if (thumb == null)
            {
                throw new ArgumentNullException(nameof(thumb));
            }
            if (indexFinger == null)
            {
                throw new ArgumentNullException(nameof(indexFinger));
            }
            if (handGrip == null)
            {
                throw new ArgumentNullException(nameof(handGrip));
            }

            this.pose = pose;

            this.thumb = thumb;

            this.indexFinger = indexFinger;

            this.handGrip = handGrip;
        }

        public IHandControllerHardwareHandler HardwareHandler => this;

        public IHandControllerSoftwareHandler SoftwareHandler => this;

        public void Dispose()
        {
            pose.Dispose();

            thumb.Dispose();

            indexFinger.Dispose();

            handGrip.Dispose();
        }

        IPoseTrackerHardwareHandler IHandControllerHardwareHandler.Pose => pose;

        IStickHardwareHandler IHandControllerHardwareHandler.Thumb => thumb;

        ITriggerHardwareHandler IHandControllerHardwareHandler.IndexFinger => indexFinger;

        ITriggerHardwareHandler IHandControllerHardwareHandler.HandGrip => handGrip;

        IPoseTrackerSoftwareHandler IHandControllerSoftwareHandler.Pose => pose;

        IStickSoftwareHandler IHandControllerSoftwareHandler.Thumb => thumb;

        ITriggerSoftwareHandler IHandControllerSoftwareHandler.IndexFinger => indexFinger;

        ITriggerSoftwareHandler IHandControllerSoftwareHandler.HandGrip => handGrip;
    }
}
