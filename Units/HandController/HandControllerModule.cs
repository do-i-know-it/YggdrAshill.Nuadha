using YggdrAshill.Nuadha.Unitization;
using System;

namespace YggdrAshill.Nuadha.Units
{
    public sealed class HandControllerModule :
        IHandControllerHardwareHandler,
        IHandControllerSoftwareHandler,
        IModule<IHandControllerHardwareHandler, IHandControllerSoftwareHandler>
    {
        internal PoseTrackerModule Pose { get; }

        internal StickModule Thumb { get; }

        internal TriggerModule IndexFinger { get; }

        internal TriggerModule HandGrip { get; }

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

            Pose = pose;

            Thumb = thumb;

            IndexFinger = indexFinger;

            HandGrip = handGrip;
        }

        public IHandControllerHardwareHandler HardwareHandler => this;

        public IHandControllerSoftwareHandler SoftwareHandler => this;

        public void Dispose()
        {
            Pose.Dispose();

            Thumb.Dispose();

            IndexFinger.Dispose();

            HandGrip.Dispose();
        }

        IPoseTrackerHardwareHandler IHandControllerHardwareHandler.Pose => Pose.HardwareHandler;

        IStickHardwareHandler IHandControllerHardwareHandler.Thumb => Thumb.HardwareHandler;

        ITriggerHardwareHandler IHandControllerHardwareHandler.IndexFinger => IndexFinger.HardwareHandler;

        ITriggerHardwareHandler IHandControllerHardwareHandler.HandGrip => HandGrip.HardwareHandler;

        IPoseTrackerSoftwareHandler IHandControllerSoftwareHandler.Pose => Pose.SoftwareHandler;

        IStickSoftwareHandler IHandControllerSoftwareHandler.Thumb => Thumb.SoftwareHandler;

        ITriggerSoftwareHandler IHandControllerSoftwareHandler.IndexFinger => IndexFinger.SoftwareHandler;

        ITriggerSoftwareHandler IHandControllerSoftwareHandler.HandGrip => HandGrip.SoftwareHandler;
    }
}
