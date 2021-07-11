using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class PulsatedStickModule :
        IModule<IPulsatedStickHardwareHandler, IPulsatedStickSoftwareHandler>,
        IPulsatedStickHardwareHandler,
        IPulsatedStickSoftwareHandler,
        IDisposable
    {
        private IPropagation<Pulse> Touch { get; }

        private PulsatedTiltModule Tilt { get; }

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

            Touch = touch;

            Tilt = tilt;
        }

        public IPulsatedStickHardwareHandler HardwareHandler => this;

        public IPulsatedStickSoftwareHandler SoftwareHandler => this;

        public void Dispose()
        {
            Touch.Dispose();

            Tilt.Dispose();
        }

        IConsumption<Pulse> IPulsatedStickHardwareHandler.Touch => Touch;

        IPulsatedTiltHardwareHandler IPulsatedStickHardwareHandler.Tilt => Tilt.HardwareHandler;

        IProduction<Pulse> IPulsatedStickSoftwareHandler.Touch => Touch;

        IPulsatedTiltSoftwareHandler IPulsatedStickSoftwareHandler.Tilt => Tilt.SoftwareHandler;
    }
}
