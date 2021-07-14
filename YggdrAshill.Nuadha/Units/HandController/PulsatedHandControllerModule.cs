using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Units;

namespace YggdrAshill.Nuadha
{
    public sealed class PulsatedHandControllerModule :
        IPulsatedHandControllerHardwareHandler,
        IPulsatedHandControllerSoftwareHandler,
        IModule<IPulsatedHandControllerHardwareHandler, IPulsatedHandControllerSoftwareHandler>
    {
        public static PulsatedHandControllerModule WithoutCache()
        {
            return new PulsatedHandControllerModule(
                PulsatedStickModule.WithoutCache(),
                PulsatedTriggerModule.WithoutCache(),
                PulsatedTriggerModule.WithoutCache());
        }

        private readonly PulsatedStickModule thumb;

        private readonly PulsatedTriggerModule indexFinger;

        private readonly PulsatedTriggerModule handGrip;

        private PulsatedHandControllerModule(PulsatedStickModule thumb, PulsatedTriggerModule indexFinger, PulsatedTriggerModule handGrip)
        {
            this.thumb = thumb;

            this.indexFinger = indexFinger;

            this.handGrip = handGrip;
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
