using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Units;

namespace YggdrAshill.Nuadha
{
    /// <inheritdoc/>
    public sealed class PulsatedStick :
        IPulsatedStickSoftware,
        IPulsatedStickHardware,
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

        /// <inheritdoc/>
        IConsumption<Pulse> IPulsatedStickSoftware.Touch => touch;

        /// <inheritdoc/>
        IPulsatedTiltSoftware IPulsatedStickSoftware.Tilt => tilt.Hardware;

        /// <inheritdoc/>
        IProduction<Pulse> IPulsatedStickHardware.Touch => touch;

        /// <inheritdoc/>
        IPulsatedTiltHardware IPulsatedStickHardware.Tilt => tilt.Software;
    }
}
