using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Units;

namespace YggdrAshill.Nuadha
{
    public sealed class HandControllerModule :
        IHandControllerHardwareHandler,
        IHandControllerSoftwareHandler,
        IModule<IHandControllerHardwareHandler, IHandControllerSoftwareHandler>
    {
        public static HandControllerModule WithoutCache()
        {
            return new HandControllerModule(
                PoseTrackerModule.WithoutCache(),
                StickModule.WithoutCache(),
                TriggerModule.WithoutCache(),
                TriggerModule.WithoutCache());
        }

        internal PoseTrackerModule Pose { get; }

        internal StickModule Thumb { get; }

        internal TriggerModule IndexFinger { get; }

        internal TriggerModule HandGrip { get; }

        private HandControllerModule(PoseTrackerModule pose, StickModule thumb, TriggerModule indexFinger, TriggerModule handGrip)
        {
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
