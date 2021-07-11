using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    internal sealed class PulsatedHandControllerModule :
        IPulsatedHandControllerHardwareHandler,
        IPulsatedHandControllerSoftwareHandler,
        IModule<IPulsatedHandControllerHardwareHandler, IPulsatedHandControllerSoftwareHandler>
    {
        private readonly PulsatedStickModule thumb;

        private readonly PulsatedTriggerModule indexFinger;

        private readonly PulsatedTriggerModule handGrip;

        internal PulsatedHandControllerModule(IPulsatedHandControllerModule module)
        {
            thumb = new PulsatedStickModule(module.Thumb);

            indexFinger = new PulsatedTriggerModule(module.IndexFinger);

            handGrip = new PulsatedTriggerModule(module.HandGrip);
        }

        public IPulsatedHandControllerHardwareHandler HardwareHandler => this;

        public IPulsatedHandControllerSoftwareHandler SoftwareHandler => this;

        public void Dispose()
        {
            thumb.Dispose();

            indexFinger.Dispose();

            handGrip.Dispose();
        }

        IPulsatedStickHardwareHandler IPulsatedHandControllerHardwareHandler.Thumb => thumb.HardwareHandler;

        IPulsatedTriggerHardwareHandler IPulsatedHandControllerHardwareHandler.IndexFinger => indexFinger.HardwareHandler;

        IPulsatedTriggerHardwareHandler IPulsatedHandControllerHardwareHandler.HandGrip => handGrip.HardwareHandler;

        IPulsatedStickSoftwareHandler IPulsatedHandControllerSoftwareHandler.Thumb => thumb.SoftwareHandler;

        IPulsatedTriggerSoftwareHandler IPulsatedHandControllerSoftwareHandler.IndexFinger => indexFinger.SoftwareHandler;

        IPulsatedTriggerSoftwareHandler IPulsatedHandControllerSoftwareHandler.HandGrip => handGrip.SoftwareHandler;
    }
}
