using YggdrAshill.Nuadha.Unitization;
using System;

namespace YggdrAshill.Nuadha.Units
{
    public sealed class PulsatedHandControllerModule :
        IModule<IPulsatedHandControllerHardwareHandler, IPulsatedHandControllerSoftwareHandler>,
        IPulsatedHandControllerHardwareHandler,
        IPulsatedHandControllerSoftwareHandler,
        IDisposable
    {
        private PulsatedStickModule Thumb { get; }

        private PulsatedTriggerModule IndexFinger { get; }

        private PulsatedTriggerModule HandGrip { get; }

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

            Thumb = thumb;

            IndexFinger = indexFinger;

            HandGrip = handGrip;
        }

        public IPulsatedHandControllerHardwareHandler HardwareHandler => this;

        public IPulsatedHandControllerSoftwareHandler SoftwareHandler => this;

        public void Dispose()
        {
            Thumb.Dispose();

            IndexFinger.Dispose();

            HandGrip.Dispose();
        }

        IPulsatedStickHardwareHandler IPulsatedHandControllerHardwareHandler.Thumb => Thumb.HardwareHandler;

        IPulsatedTriggerHardwareHandler IPulsatedHandControllerHardwareHandler.IndexFinger => IndexFinger.HardwareHandler;

        IPulsatedTriggerHardwareHandler IPulsatedHandControllerHardwareHandler.HandGrip => HandGrip.HardwareHandler;

        IPulsatedStickSoftwareHandler IPulsatedHandControllerSoftwareHandler.Thumb => Thumb.SoftwareHandler;

        IPulsatedTriggerSoftwareHandler IPulsatedHandControllerSoftwareHandler.IndexFinger => IndexFinger.SoftwareHandler;

        IPulsatedTriggerSoftwareHandler IPulsatedHandControllerSoftwareHandler.HandGrip => HandGrip.SoftwareHandler;
    }
}
