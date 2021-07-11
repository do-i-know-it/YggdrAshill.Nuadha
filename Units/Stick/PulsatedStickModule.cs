using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    internal sealed class PulsatedStickModule :
        IPulsatedStickHardwareHandler,
        IPulsatedStickSoftwareHandler,
        IModule<IPulsatedStickHardwareHandler, IPulsatedStickSoftwareHandler>
    {
        private readonly IPropagation<Pulse> touch;

        private readonly PulsatedTiltModule tilt;

        internal PulsatedStickModule(IPulsatedStickModule module)
        {
            touch = module.Touch;

            tilt = new PulsatedTiltModule(module.Tilt);
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
