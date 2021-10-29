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
        IProtocol<IPulsatedStickSoftware, IPulsatedStickHardware>
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
            return new PulsatedStick(Propagate.WithLatestCache(Initialize.Pulse), PulsatedTilt.WithLatestCache());
        }

        private readonly IPropagation<Pulse> touch;

        private readonly PulsatedTilt tilt;

        private PulsatedStick(IPropagation<Pulse> touch, PulsatedTilt tilt)
        {
            this.touch = touch;

            this.tilt = tilt;
        }

        /// <inheritdoc/>
        public IPulsatedStickSoftware Hardware => this;

        /// <inheritdoc/>
        public IPulsatedStickHardware Software => this;

        /// <inheritdoc/>
        public void Dispose()
        {
            touch.Dispose();

            tilt.Dispose();
        }

        IProduction<Pulse> IPulsatedStickHardware.Touch => touch;

        IPulsatedTiltHardware IPulsatedStickHardware.Tilt => tilt.Software;

        IConsumption<Pulse> IPulsatedStickSoftware.Touch => touch;

        IPulsatedTiltSoftware IPulsatedStickSoftware.Tilt => tilt.Hardware;
    }
}
