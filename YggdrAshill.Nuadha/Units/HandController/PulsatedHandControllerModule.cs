using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class PulsatedHandControllerModule :
        IModule<IPulsatedHandControllerHardwareHandler, IPulsatedHandControllerSoftwareHandler>,
        IPulsatedHandControllerHardwareHandler,
        IPulsatedHandControllerSoftwareHandler
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

        IPulsatedStickHardwareHandler IPulsatedHandControllerHardwareHandler.Thumb => thumb;

        IPulsatedTriggerHardwareHandler IPulsatedHandControllerHardwareHandler.IndexFinger => indexFinger;

        IPulsatedTriggerHardwareHandler IPulsatedHandControllerHardwareHandler.HandGrip => handGrip;

        IPulsatedStickSoftwareHandler IPulsatedHandControllerSoftwareHandler.Thumb => thumb;

        IPulsatedTriggerSoftwareHandler IPulsatedHandControllerSoftwareHandler.IndexFinger => indexFinger;

        IPulsatedTriggerSoftwareHandler IPulsatedHandControllerSoftwareHandler.HandGrip => handGrip;
    }
}
