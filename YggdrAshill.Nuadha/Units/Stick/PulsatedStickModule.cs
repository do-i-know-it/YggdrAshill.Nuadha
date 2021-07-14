using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Units;

namespace YggdrAshill.Nuadha
{
    public sealed class PulsatedStickModule :
        IPulsatedStickHardwareHandler,
        IPulsatedStickSoftwareHandler,
        IModule<IPulsatedStickHardwareHandler, IPulsatedStickSoftwareHandler>
    {
        public static PulsatedStickModule WithoutCache()
        {
            return new PulsatedStickModule(Propagation.WithoutCache.Create<Pulse>(), PulsatedTiltModule.WithoutCache());
        }

        private readonly IPropagation<Pulse> touch;

        private readonly PulsatedTiltModule tilt;

        private PulsatedStickModule(IPropagation<Pulse> touch, PulsatedTiltModule tilt)
        {
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
