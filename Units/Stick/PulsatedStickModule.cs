using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Unitization;
using System;

namespace YggdrAshill.Nuadha.Units
{
    public sealed class PulsatedStickModule :
        IPulsatedStickHardwareHandler,
        IPulsatedStickSoftwareHandler,
        IModule<IPulsatedStickHardwareHandler, IPulsatedStickSoftwareHandler>
    {
        private readonly IPropagation<Pulse> touch;

        private readonly PulsatedTiltModule tilt;

        public PulsatedStickModule(IPropagation<Pulse> touch, PulsatedTiltModule tilt)
        {
            if (touch == null)
            {
                throw new ArgumentNullException(nameof(touch));
            }
            if (tilt == null)
            {
                throw new ArgumentNullException(nameof(tilt));
            }

            this.touch = touch;

            this.tilt = tilt;
        }

        public IPulsatedStickHardwareHandler HardwareHandler => this;

        public IPulsatedStickSoftwareHandler SoftwareHandler => this;

        public void Dispose()
        {
            touch.Dispose();

            tilt.Dispose();
        }

        IConsumption<Pulse> IPulsatedStickHardwareHandler.Touch => touch;

        IPulsatedTiltHardwareHandler IPulsatedStickHardwareHandler.Tilt => tilt.HardwareHandler;

        IProduction<Pulse> IPulsatedStickSoftwareHandler.Touch => touch;

        IPulsatedTiltSoftwareHandler IPulsatedStickSoftwareHandler.Tilt => tilt.SoftwareHandler;
    }
}
