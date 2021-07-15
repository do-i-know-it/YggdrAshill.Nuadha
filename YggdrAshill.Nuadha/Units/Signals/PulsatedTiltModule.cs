using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Units;

namespace YggdrAshill.Nuadha
{
    public sealed class PulsatedTiltModule :
        IPulsatedTiltHardwareHandler,
        IPulsatedTiltSoftwareHandler,
        IModule<IPulsatedTiltHardwareHandler, IPulsatedTiltSoftwareHandler>
    {
        public static PulsatedTiltModule WithoutCache()
        {
            return new PulsatedTiltModule(
                Propagation.WithoutCache.Of<Pulse>(),
                Propagation.WithoutCache.Of<Pulse>(),
                Propagation.WithoutCache.Of<Pulse>(),
                Propagation.WithoutCache.Of<Pulse>(),
                Propagation.WithoutCache.Of<Pulse>());
        }

        public static PulsatedTiltModule WithLatestCache()
        {
            return new PulsatedTiltModule(
                Propagation.WithLatestCache.Of(Initialize.Pulse),
                Propagation.WithLatestCache.Of(Initialize.Pulse),
                Propagation.WithLatestCache.Of(Initialize.Pulse),
                Propagation.WithLatestCache.Of(Initialize.Pulse),
                Propagation.WithLatestCache.Of(Initialize.Pulse));
        }

        private readonly IPropagation<Pulse> distance;

        private readonly IPropagation<Pulse> left;

        private readonly IPropagation<Pulse> right;

        private readonly IPropagation<Pulse> forward;

        private readonly IPropagation<Pulse> backward;

        private PulsatedTiltModule(
            IPropagation<Pulse> distance,
            IPropagation<Pulse> left, IPropagation<Pulse> right,
            IPropagation<Pulse> forward, IPropagation<Pulse> backward)
        {
            this.distance = distance;

            this.left = left;

            this.right = right;

            this.forward = forward;

            this.backward = backward;
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
