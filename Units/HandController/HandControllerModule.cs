using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    internal sealed class HandControllerModule :
        IHandControllerHardwareHandler,
        IHandControllerSoftwareHandler,
        IModule<IHandControllerHardwareHandler, IHandControllerSoftwareHandler>
    {
        private readonly PoseTrackerModule pose;

        private readonly StickModule thumb;

        private readonly TriggerModule indexFinger;

        private readonly TriggerModule handGrip;

        internal HandControllerModule(IHandControllerModule module)
        {
            pose = new PoseTrackerModule(module.Pose);

            thumb = new StickModule(module.Thumb);

            indexFinger = new TriggerModule(module.IndexFinger);

            handGrip = new TriggerModule(module.HandGrip);
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

        IPoseTrackerHardwareHandler IHandControllerHardwareHandler.Pose => pose.HardwareHandler;

        IStickHardwareHandler IHandControllerHardwareHandler.Thumb => thumb.HardwareHandler;

        ITriggerHardwareHandler IHandControllerHardwareHandler.IndexFinger => indexFinger.HardwareHandler;

        ITriggerHardwareHandler IHandControllerHardwareHandler.HandGrip => handGrip.HardwareHandler;

        IPoseTrackerSoftwareHandler IHandControllerSoftwareHandler.Pose => pose.SoftwareHandler;

        IStickSoftwareHandler IHandControllerSoftwareHandler.Thumb => thumb.SoftwareHandler;

        ITriggerSoftwareHandler IHandControllerSoftwareHandler.IndexFinger => indexFinger.SoftwareHandler;

        ITriggerSoftwareHandler IHandControllerSoftwareHandler.HandGrip => handGrip.SoftwareHandler;
    }
}
