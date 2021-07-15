using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Units;

namespace YggdrAshill.Nuadha
{
    /// <inheritdoc/>
    public sealed class PulsatedStickModule :
        IPulsatedStickHardwareHandler,
        IPulsatedStickSoftwareHandler,
        IModule<IPulsatedStickHardwareHandler, IPulsatedStickSoftwareHandler>
    {
        /// <summary>
        /// <see cref="PulsatedStickModule"/> without cache.
        /// </summary>
        /// <returns>
        /// <see cref="PulsatedStickModule"/> without cache.
        /// </returns>
        public static PulsatedStickModule WithoutCache()
        {
            return new PulsatedStickModule(Propagation.WithoutCache.Of<Pulse>(), PulsatedTiltModule.WithoutCache());
        }

        /// <summary>
        /// <see cref="PulsatedStickModule"/> with latest cache.
        /// </summary>
        /// <returns>
        /// <see cref="PulsatedStickModule"/> with latest cache.
        /// </returns>
        public static PulsatedStickModule WithLatestCache()
        {
            return new PulsatedStickModule(Propagation.WithLatestCache.Of(Initialize.Pulse), PulsatedTiltModule.WithLatestCache());
        }

        private readonly IPropagation<Pulse> touch;

        private readonly PulsatedTiltModule tilt;

        private PulsatedStickModule(IPropagation<Pulse> touch, PulsatedTiltModule tilt)
        {
            this.touch = touch;

            this.tilt = tilt;
        }

        /// <inheritdoc/>
        public IPulsatedStickHardwareHandler HardwareHandler => this;

        /// <inheritdoc/>
        public IPulsatedStickSoftwareHandler SoftwareHandler => this;

        /// <inheritdoc/>
        public void Dispose()
        {
            touch.Dispose();

            tilt.Dispose();
        }

        /// <inheritdoc/>
        IConsumption<Pulse> IPulsatedStickHardwareHandler.Touch => touch;

        /// <inheritdoc/>
        IPulsatedTiltHardwareHandler IPulsatedStickHardwareHandler.Tilt => tilt.HardwareHandler;

        /// <inheritdoc/>
        IProduction<Pulse> IPulsatedStickSoftwareHandler.Touch => touch;

        /// <inheritdoc/>
        IPulsatedTiltSoftwareHandler IPulsatedStickSoftwareHandler.Tilt => tilt.SoftwareHandler;
    }
}
