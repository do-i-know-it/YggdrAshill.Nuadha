using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Units;

namespace YggdrAshill.Nuadha
{
    /// Implementation of <see cref="IProtocol{THardware, TSoftware}"/> for <see cref="IPulsatedStickHardware"/> and <see cref="IPulsatedStickSoftware"/>.
    public sealed class PulsatedStick :
        IPulsatedStickHardware,
        IPulsatedStickSoftware,
        IProtocol<IPulsatedStickHardware, IPulsatedStickSoftware>
    {
        /// <summary>
        /// <see cref="PulsatedStick"/> without cache.
        /// </summary>
        /// <returns>
        /// <see cref="PulsatedStick"/> without cache.
        /// </returns>
        public static PulsatedStick WithoutCache()
        {
            return new PulsatedStick(Propagate.WithoutCache<Pulse>(), PulsatedTilt.WithoutCache());
        }

        /// <summary>
        /// <see cref="PulsatedStick"/> with latest cache.
        /// </summary>
        /// <returns>
        /// <see cref="PulsatedStick"/> with latest cache.
        /// </returns>
        public static PulsatedStick WithLatestCache()
        {
            var generation = Generate.Signal(() => Pulse.IsDisabled);

            return new PulsatedStick(Propagate.WithLatestCache(generation), PulsatedTilt.WithLatestCache());
        }

        private readonly IPropagation<Pulse> touch;

        private readonly PulsatedTilt tilt;

        private PulsatedStick(IPropagation<Pulse> touch, PulsatedTilt tilt)
        {
            this.touch = touch;

            this.tilt = tilt;
        }

        /// <inheritdoc/>
        public IPulsatedStickHardware Hardware => this;

        /// <inheritdoc/>
        public IPulsatedStickSoftware Software => this;

        /// <inheritdoc/>
        public void Dispose()
        {
            touch.Dispose();

            tilt.Dispose();
        }

        IProduction<Pulse> IPulsatedStickHardware.Touch => touch;

        IPulsatedTiltHardware IPulsatedStickHardware.Tilt => tilt.Hardware;

        IConsumption<Pulse> IPulsatedStickSoftware.Touch => touch;

        IPulsatedTiltSoftware IPulsatedStickSoftware.Tilt => tilt.Software;
    }
}
