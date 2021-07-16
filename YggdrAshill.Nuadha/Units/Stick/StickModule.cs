using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;
using YggdrAshill.Nuadha.Units;

namespace YggdrAshill.Nuadha
{
    /// <inheritdoc/>
    public sealed class StickModule :
        IStickHardwareHandler,
        IStickSoftwareHandler,
        IModule<IStickHardwareHandler, IStickSoftwareHandler>
    {
        /// <summary>
        /// <see cref="StickModule"/> without cache.
        /// </summary>
        /// <returns>
        /// <see cref="StickModule"/> without cache.
        /// </returns>
        public static StickModule WithoutCache()
        {
            return new StickModule(Propagation.WithoutCache.Of<Touch>(), Propagation.WithoutCache.Of<Tilt>());
        }

        /// <summary>
        /// <see cref="StickModule"/> with latest cache.
        /// </summary>
        /// <returns>
        /// <see cref="StickModule"/> with latest cache.
        /// </returns>
        public static StickModule WithLatestCache()
        {
            return new StickModule(Propagation.WithLatestCache.Of(Initialize.Touch), Propagation.WithLatestCache.Of(Initialize.Tilt));
        }

        internal IPropagation<Touch> Touch { get; }

        internal IPropagation<Tilt> Tilt { get; }

        private StickModule(IPropagation<Touch> touch, IPropagation<Tilt> tilt)
        {
            Touch = touch;

            Tilt = tilt;
        }

        /// <inheritdoc/>
        public IStickHardwareHandler HardwareHandler => this;

        /// <inheritdoc/>
        public IStickSoftwareHandler SoftwareHandler => this;

        /// <inheritdoc/>
        public void Dispose()
        {
            Touch.Dispose();

            Tilt.Dispose();
        }

        /// <inheritdoc/>
        IConsumption<Touch> IStickHardwareHandler.Touch => Touch;

        /// <inheritdoc/>
        IConsumption<Tilt> IStickHardwareHandler.Tilt => Tilt;

        /// <inheritdoc/>
        IProduction<Touch> IStickSoftwareHandler.Touch => Touch;

        /// <inheritdoc/>
        IProduction<Tilt> IStickSoftwareHandler.Tilt => Tilt;
    }
}
