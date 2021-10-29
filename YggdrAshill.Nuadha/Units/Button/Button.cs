using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;
using YggdrAshill.Nuadha.Units;

namespace YggdrAshill.Nuadha
{
    /// <inheritdoc/>
    public sealed class Button :
        IButtonSoftware,
        IButtonHardware,
        IProtocol<IButtonSoftware, IButtonHardware>
    {
        /// <summary>
        /// <see cref="Button"/> without cache.
        /// </summary>
        /// <returns>
        /// <see cref="Button"/> without cache.
        /// </returns>
        public static Button WithoutCache()
        {
            return new Button(Propagate.WithoutCache<Touch>(), Propagate.WithoutCache<Push>());
        }

        /// <summary>
        /// <see cref="Button"/> with latest cache.
        /// </summary>
        /// <returns>
        /// <see cref="Button"/> with latest cache.
        /// </returns>
        public static Button WithLatestCache()
        {
            return new Button(Propagate.WithLatestCache(Initialize.Touch), Propagate.WithLatestCache(Initialize.Push));
        }

        internal IPropagation<Touch> Touch { get; }

        internal IPropagation<Push> Push { get; }

        private Button(IPropagation<Touch> touch, IPropagation<Push> push)
        {
            Touch = touch;

            Push = push;
        }

        /// <inheritdoc/>
        public IButtonSoftware Hardware => this;

        /// <inheritdoc/>
        public IButtonHardware Software => this;

        /// <inheritdoc/>
        public void Dispose()
        {
            Touch.Dispose();

            Push.Dispose();
        }

        /// <inheritdoc/>
        IConsumption<Touch> IButtonSoftware.Touch => Touch;

        /// <inheritdoc/>
        IConsumption<Push> IButtonSoftware.Push => Push;

        /// <inheritdoc/>
        IProduction<Touch> IButtonHardware.Touch => Touch;

        /// <inheritdoc/>
        IProduction<Push> IButtonHardware.Push => Push;
    }
}
