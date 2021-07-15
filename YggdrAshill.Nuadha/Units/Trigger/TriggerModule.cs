using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;
using YggdrAshill.Nuadha.Units;

namespace YggdrAshill.Nuadha
{
    /// <inheritdoc/>
    public sealed class TriggerModule :
        ITriggerHardwareHandler,
        ITriggerSoftwareHandler,
        IModule<ITriggerHardwareHandler, ITriggerSoftwareHandler>
    {
        /// <summary>
        /// <see cref="TriggerModule"/> without cache.
        /// </summary>
        /// <returns>
        /// <see cref="TriggerModule"/> without cache.
        /// </returns>
        public static TriggerModule WithoutCache()
        {
            return new TriggerModule(Propagation.WithoutCache.Of<Touch>(), Propagation.WithoutCache.Of<Pull>());
        }

        /// <summary>
        /// <see cref="TriggerModule"/> with latest cache.
        /// </summary>
        /// <returns>
        /// <see cref="TriggerModule"/> with latest cache.
        /// </returns>
        public static TriggerModule WithLatestCache()
        {
            return new TriggerModule(Propagation.WithLatestCache.Of(Initialize.Touch), Propagation.WithLatestCache.Of(Initialize.Pull));
        }

        internal IPropagation<Touch> Touch { get; }

        internal IPropagation<Pull> Pull { get; }

        private TriggerModule(IPropagation<Touch> touch, IPropagation<Pull> pull)
        {
            Touch = touch;

            Pull = pull;
        }

        /// <inheritdoc/>
        public ITriggerHardwareHandler HardwareHandler => this;

        /// <inheritdoc/>
        public ITriggerSoftwareHandler SoftwareHandler => this;

        /// <inheritdoc/>
        public void Dispose()
        {
            Touch.Dispose();

            Pull.Dispose();
        }

        /// <inheritdoc/>
        IConsumption<Touch> ITriggerHardwareHandler.Touch => Touch;

        /// <inheritdoc/>
        IConsumption<Pull> ITriggerHardwareHandler.Pull => Pull;

        /// <inheritdoc/>
        IProduction<Touch> ITriggerSoftwareHandler.Touch => Touch;

        /// <inheritdoc/>
        IProduction<Pull> ITriggerSoftwareHandler.Pull => Pull;
    }
}
