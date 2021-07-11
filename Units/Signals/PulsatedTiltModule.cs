using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Unitization;

namespace YggdrAshill.Nuadha.Units
{
    internal sealed class PulsatedTiltModule :
        IPulsatedTiltHardwareHandler,
        IPulsatedTiltSoftwareHandler,
        IModule<IPulsatedTiltHardwareHandler, IPulsatedTiltSoftwareHandler>
    {
        private readonly IPropagation<Pulse> distance;

        private readonly IPropagation<Pulse> left;

        private readonly IPropagation<Pulse> right;

        private readonly IPropagation<Pulse> forward;

        private readonly IPropagation<Pulse> backward;

        internal PulsatedTiltModule(IPulsatedTiltModule module)
        {
            distance = module.Distance;

            left = module.Left;

            right = module.Right;

            forward = module.Forward;

            backward = module.Backward;
        }

        public IPulsatedTiltHardwareHandler HardwareHandler => this;

        public IPulsatedTiltSoftwareHandler SoftwareHandler => this;

        public void Dispose()
        {
            distance.Dispose();

            left.Dispose();

            right.Dispose();

            forward.Dispose();

            backward.Dispose();
        }

        IConsumption<Pulse> IPulsatedTiltHardwareHandler.Distance => distance;

        IConsumption<Pulse> IPulsatedTiltHardwareHandler.Left => left;

        IConsumption<Pulse> IPulsatedTiltHardwareHandler.Right => right;

        IConsumption<Pulse> IPulsatedTiltHardwareHandler.Forward => forward;

        IConsumption<Pulse> IPulsatedTiltHardwareHandler.Backward => backward;

        IProduction<Pulse> IPulsatedTiltSoftwareHandler.Distance => distance;

        IProduction<Pulse> IPulsatedTiltSoftwareHandler.Left => left;

        IProduction<Pulse> IPulsatedTiltSoftwareHandler.Right => right;

        IProduction<Pulse> IPulsatedTiltSoftwareHandler.Forward => forward;

        IProduction<Pulse> IPulsatedTiltSoftwareHandler.Backward => backward;
    }
}
