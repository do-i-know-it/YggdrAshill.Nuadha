using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Units;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Defines implementations of <see cref="IPulsatedTiltProtocol"/>.
    /// </summary>
    public sealed class PulsatedTilt :
        IPulsatedTiltHardware,
        IPulsatedTiltSoftware,
        IPulsatedTiltProtocol
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
            var generation = Generate.Signal(() => Pulse.IsDisabled);

            return new PulsatedTilt(
                Propagate.WithLatestCache(generation),
                Propagate.WithLatestCache(generation),
                Propagate.WithLatestCache(generation),
                Propagate.WithLatestCache(generation),
                Propagate.WithLatestCache(generation));
        }

        private PulsatedTilt(IPropagation<Pulse> distance, IPropagation<Pulse> left, IPropagation<Pulse> right, IPropagation<Pulse> forward, IPropagation<Pulse> backward)
        {
            Distance = distance;

            Left = left;

            Right = right;

            Forward = forward;

            Backward = backward;
        }

        /// <inheritdoc/>
        public IPropagation<Pulse> Distance { get; }

        /// <inheritdoc/>
        public IPropagation<Pulse> Left { get; }

        /// <inheritdoc/>
        public IPropagation<Pulse> Right { get; }

        /// <inheritdoc/>
        public IPropagation<Pulse> Forward { get; }

        /// <inheritdoc/>
        public IPropagation<Pulse> Backward { get; }

        /// <inheritdoc/>
        public IPulsatedTiltHardware Hardware => this;

        /// <inheritdoc/>
        public IPulsatedTiltSoftware Software => this;

        /// <inheritdoc/>
        IProduction<Pulse> IPulsatedTiltHardware.Distance => Distance;

        /// <inheritdoc/>
        IProduction<Pulse> IPulsatedTiltHardware.Left => Left;

        /// <inheritdoc/>
        IProduction<Pulse> IPulsatedTiltHardware.Right => Right;

        /// <inheritdoc/>
        IProduction<Pulse> IPulsatedTiltHardware.Forward => Forward;

        /// <inheritdoc/>
        IProduction<Pulse> IPulsatedTiltHardware.Backward => Backward;

        /// <inheritdoc/>
        IConsumption<Pulse> IPulsatedTiltSoftware.Distance => Distance;

        /// <inheritdoc/>
        IConsumption<Pulse> IPulsatedTiltSoftware.Left => Left;

        /// <inheritdoc/>
        IConsumption<Pulse> IPulsatedTiltSoftware.Right => Right;

        /// <inheritdoc/>
        IConsumption<Pulse> IPulsatedTiltSoftware.Forward => Forward;

        /// <inheritdoc/>
        IConsumption<Pulse> IPulsatedTiltSoftware.Backward => Backward;
    }
}
