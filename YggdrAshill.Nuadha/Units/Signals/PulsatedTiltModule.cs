using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Units;

namespace YggdrAshill.Nuadha
{
    /// <inheritdoc/>
    public sealed class PulsatedTiltModule :
        IPulsatedTiltHardwareHandler,
        IPulsatedTiltSoftwareHandler,
        IModule<IPulsatedTiltHardwareHandler, IPulsatedTiltSoftwareHandler>
    {
        /// <summary>
        /// <see cref="PulsatedTiltModule"/> without cache.
        /// </summary>
        /// <returns>
        /// <see cref="PulsatedTiltModule"/> without cache.
        /// </returns>
        public static PulsatedTiltModule WithoutCache()
        {
            return new PulsatedTiltModule(
                Propagation.WithoutCache.Of<Pulse>(),
                Propagation.WithoutCache.Of<Pulse>(),
                Propagation.WithoutCache.Of<Pulse>(),
                Propagation.WithoutCache.Of<Pulse>(),
                Propagation.WithoutCache.Of<Pulse>());
        }

        /// <summary>
        /// <see cref="PulsatedTiltModule"/> with latest cache.
        /// </summary>
        /// <returns>
        /// <see cref="PulsatedTiltModule"/> with latest cache.
        /// </returns>
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

        /// <inheritdoc/>
        public IPulsatedTiltHardwareHandler HardwareHandler => this;

        /// <inheritdoc/>
        public IPulsatedTiltSoftwareHandler SoftwareHandler => this;

        /// <inheritdoc/>
        public void Dispose()
        {
            distance.Dispose();

            left.Dispose();

            right.Dispose();

            forward.Dispose();

            backward.Dispose();
        }

        /// <inheritdoc/>
        IConsumption<Pulse> IPulsatedTiltHardwareHandler.Distance => distance;

        /// <inheritdoc/>
        IConsumption<Pulse> IPulsatedTiltHardwareHandler.Left => left;

        /// <inheritdoc/>
        IConsumption<Pulse> IPulsatedTiltHardwareHandler.Right => right;

        /// <inheritdoc/>
        IConsumption<Pulse> IPulsatedTiltHardwareHandler.Forward => forward;

        /// <inheritdoc/>
        IConsumption<Pulse> IPulsatedTiltHardwareHandler.Backward => backward;

        /// <inheritdoc/>
        IProduction<Pulse> IPulsatedTiltSoftwareHandler.Distance => distance;

        /// <inheritdoc/>
        IProduction<Pulse> IPulsatedTiltSoftwareHandler.Left => left;

        /// <inheritdoc/>
        IProduction<Pulse> IPulsatedTiltSoftwareHandler.Right => right;

        /// <inheritdoc/>
        IProduction<Pulse> IPulsatedTiltSoftwareHandler.Forward => forward;

        /// <inheritdoc/>
        IProduction<Pulse> IPulsatedTiltSoftwareHandler.Backward => backward;
    }
}
