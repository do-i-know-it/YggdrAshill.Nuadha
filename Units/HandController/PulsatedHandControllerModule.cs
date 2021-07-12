using YggdrAshill.Nuadha.Unitization;
using System;

namespace YggdrAshill.Nuadha.Units
{
    public sealed class PulsatedHandControllerModule :
        IPulsatedHandControllerHardwareHandler,
        IPulsatedHandControllerSoftwareHandler,
        IModule<IPulsatedHandControllerHardwareHandler, IPulsatedHandControllerSoftwareHandler>
    {
        private readonly PulsatedStickModule thumb;

        private readonly PulsatedTriggerModule indexFinger;

        private readonly PulsatedTriggerModule handGrip;

        public PulsatedHandControllerModule(PulsatedStickModule thumb, PulsatedTriggerModule indexFinger, PulsatedTriggerModule handGrip)
        {
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
