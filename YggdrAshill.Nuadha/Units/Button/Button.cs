using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Signals;
using YggdrAshill.Nuadha.Units;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Defines implementations of <see cref="IButtonProtocol"/>.
    /// </summary>
    public sealed class Button :
        IButtonHardware,
        IButtonSoftware,
        IButtonProtocol
    {
        /// <summary>
        /// <see cref="IButtonProtocol"/> without cache.
        /// </summary>
        /// <returns>
        /// <see cref="IButtonProtocol"/> without cache.
        /// </returns>
        public static IButtonProtocol WithoutCache()
        {
            return new Button(Propagate.WithoutCache<Touch>(), Propagate.WithoutCache<Push>());
        }

        /// <summary>
        /// <see cref="IButtonProtocol"/> with latest cache.
        /// </summary>
        /// <returns>
        /// <see cref="IButtonProtocol"/> with latest cache.
        /// </returns>
        public static IButtonProtocol WithLatestCache()
        {
            return new Button(Propagate.WithLatestCache(Imitate.Touch), Propagate.WithLatestCache(Imitate.Push));
        }

        private Button(IPropagation<Touch> touch, IPropagation<Push> push)
        {
            Touch = touch;

            Push = push;
        }

        /// <inheritdoc/>
        public IPropagation<Touch> Touch { get; }

        /// <inheritdoc/>
        public IPropagation<Push> Push { get; }

        /// <inheritdoc/>
        public IButtonHardware Hardware => this;

        /// <inheritdoc/>
        public IButtonSoftware Software => this;

        /// <inheritdoc/>
        IProduction<Touch> IButtonHardware.Touch => Touch;

        /// <inheritdoc/>
        IProduction<Push> IButtonHardware.Push => Push;

        /// <inheritdoc/>
        IConsumption<Touch> IButtonSoftware.Touch => Touch;

        /// <inheritdoc/>
        IConsumption<Push> IButtonSoftware.Push => Push;
    }
}
