using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;
using YggdrAshill.Nuadha.Units;

namespace YggdrAshill.Nuadha
{
    /// Implementation of <see cref="IProtocol{THardware, TSoftware}"/> for <see cref="IButtonHardware"/> and <see cref="IButtonSoftware"/>.
    public sealed class Button :
        IButtonHardware,
        IButtonSoftware,
        IProtocol<IButtonHardware, IButtonSoftware>
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
        public IButtonHardware Hardware => this;

        /// <inheritdoc/>
        public IButtonSoftware Software => this;

        /// <inheritdoc/>
        public void Dispose()
        {
            Touch.Dispose();

            Push.Dispose();
        }

        IProduction<Touch> IButtonHardware.Touch => Touch;

        IProduction<Push> IButtonHardware.Push => Push;

        IConsumption<Touch> IButtonSoftware.Touch => Touch;

        IConsumption<Push> IButtonSoftware.Push => Push;
    }
}
