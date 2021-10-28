using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Units;

namespace YggdrAshill.Nuadha
{
    /// <inheritdoc/>
    public sealed class PulsatedTilt :
        IPulsatedTiltSoftware,
        IPulsatedTiltHardware,
        IProtocol<IPulsatedTiltSoftware, IPulsatedTiltHardware>
    {
        /// <summary>
        /// <see cref="PulsatedTilt"/> without cache.
        /// </summary>
        /// <returns>
        /// <see cref="PulsatedTilt"/> without cache.
        /// </returns>
        public static PulsatedTilt WithoutCache()
        {
            return new PulsatedTilt(
                Propagation.WithoutCache.Of<Pulse>(),
                Propagation.WithoutCache.Of<Pulse>(),
                Propagation.WithoutCache.Of<Pulse>(),
                Propagation.WithoutCache.Of<Pulse>(),
                Propagation.WithoutCache.Of<Pulse>());
        }

        /// <summary>
        /// <see cref="PulsatedTilt"/> with latest cache.
        /// </summary>
        /// <returns>
        /// <see cref="PulsatedTilt"/> with latest cache.
        /// </returns>
        public static PulsatedTilt WithLatestCache()
        {
            return new PulsatedTilt(
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

        private PulsatedTilt(
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
        public IPulsatedTiltSoftware Hardware => this;

        /// <inheritdoc/>
        public IPulsatedTiltHardware Software => this;

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
        IConsumption<Pulse> IPulsatedTiltSoftware.Distance => distance;

        /// <inheritdoc/>
        IConsumption<Pulse> IPulsatedTiltSoftware.Left => left;

        /// <inheritdoc/>
        IConsumption<Pulse> IPulsatedTiltSoftware.Right => right;

        /// <inheritdoc/>
        IConsumption<Pulse> IPulsatedTiltSoftware.Forward => forward;

        /// <inheritdoc/>
        IConsumption<Pulse> IPulsatedTiltSoftware.Backward => backward;

        /// <inheritdoc/>
        IProduction<Pulse> IPulsatedTiltHardware.Distance => distance;

        /// <inheritdoc/>
        IProduction<Pulse> IPulsatedTiltHardware.Left => left;

        /// <inheritdoc/>
        IProduction<Pulse> IPulsatedTiltHardware.Right => right;

        /// <inheritdoc/>
        IProduction<Pulse> IPulsatedTiltHardware.Forward => forward;

        /// <inheritdoc/>
        IProduction<Pulse> IPulsatedTiltHardware.Backward => backward;
    }
}
