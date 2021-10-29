using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Units;

namespace YggdrAshill.Nuadha
{
    /// Implementation of <see cref="IProtocol{THardware, TSoftware}"/> for <see cref="IPulsatedTiltHardware"/> and <see cref="IPulsatedTiltSoftware"/>.
    public sealed class PulsatedTilt :
        IPulsatedTiltHardware,
        IPulsatedTiltSoftware,
        IProtocol<IPulsatedTiltHardware, IPulsatedTiltSoftware>
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
                Propagate.WithoutCache<Pulse>(),
                Propagate.WithoutCache<Pulse>(),
                Propagate.WithoutCache<Pulse>(),
                Propagate.WithoutCache<Pulse>(),
                Propagate.WithoutCache<Pulse>());
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
                Propagate.WithLatestCache(Initialize.Pulse),
                Propagate.WithLatestCache(Initialize.Pulse),
                Propagate.WithLatestCache(Initialize.Pulse),
                Propagate.WithLatestCache(Initialize.Pulse),
                Propagate.WithLatestCache(Initialize.Pulse));
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
        public IPulsatedTiltHardware Hardware => this;

        /// <inheritdoc/>
        public IPulsatedTiltSoftware Software => this;

        /// <inheritdoc/>
        public void Dispose()
        {
            distance.Dispose();

            left.Dispose();

            right.Dispose();

            forward.Dispose();

            backward.Dispose();
        }

        IProduction<Pulse> IPulsatedTiltHardware.Distance => distance;

        IProduction<Pulse> IPulsatedTiltHardware.Left => left;

        IProduction<Pulse> IPulsatedTiltHardware.Right => right;

        IProduction<Pulse> IPulsatedTiltHardware.Forward => forward;

        IProduction<Pulse> IPulsatedTiltHardware.Backward => backward;

        IConsumption<Pulse> IPulsatedTiltSoftware.Distance => distance;

        IConsumption<Pulse> IPulsatedTiltSoftware.Left => left;

        IConsumption<Pulse> IPulsatedTiltSoftware.Right => right;

        IConsumption<Pulse> IPulsatedTiltSoftware.Forward => forward;

        IConsumption<Pulse> IPulsatedTiltSoftware.Backward => backward;
    }
}
