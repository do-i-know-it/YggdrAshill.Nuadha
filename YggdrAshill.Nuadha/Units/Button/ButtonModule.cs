using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;
using YggdrAshill.Nuadha.Units;

namespace YggdrAshill.Nuadha
{
    /// <inheritdoc/>
    public sealed class ButtonModule :
        IButtonHardwareHandler,
        IButtonSoftwareHandler,
        IModule<IButtonHardwareHandler, IButtonSoftwareHandler>
    {
        /// <summary>
        /// <see cref="ButtonModule"/> without cache.
        /// </summary>
        /// <returns>
        /// <see cref="ButtonModule"/> without cache.
        /// </returns>
        public static ButtonModule WithoutCache()
        {
            return new ButtonModule(Propagation.WithoutCache.Of<Touch>(), Propagation.WithoutCache.Of<Push>());
        }

        /// <summary>
        /// <see cref="ButtonModule"/> with latest cache.
        /// </summary>
        /// <returns>
        /// <see cref="ButtonModule"/> with latest cache.
        /// </returns>
        public static ButtonModule WithLatestCache()
        {
            return new ButtonModule(Propagation.WithLatestCache.Of(Initialize.Touch), Propagation.WithLatestCache.Of(Initialize.Push));
        }

        internal IPropagation<Touch> Touch { get; }

        internal IPropagation<Push> Push { get; }

        private ButtonModule(IPropagation<Touch> touch, IPropagation<Push> push)
        {
            Touch = touch;

            Push = push;
        }

        /// <inheritdoc/>
        public IButtonHardwareHandler HardwareHandler => this;

        /// <inheritdoc/>
        public IButtonSoftwareHandler SoftwareHandler => this;

        /// <inheritdoc/>
        public void Dispose()
        {
            Touch.Dispose();

            Push.Dispose();
        }

        /// <inheritdoc/>
        IConsumption<Touch> IButtonHardwareHandler.Touch => Touch;

        /// <inheritdoc/>
        IConsumption<Push> IButtonHardwareHandler.Push => Push;

        /// <inheritdoc/>
        IProduction<Touch> IButtonSoftwareHandler.Touch => Touch;

        /// <inheritdoc/>
        IProduction<Push> IButtonSoftwareHandler.Push => Push;
    }
}
