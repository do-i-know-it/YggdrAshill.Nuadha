using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Signals;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Implementation of <see cref="IButtonProtocol"/>.
    /// </summary>
    public sealed class Button :
        IButtonHardware,
        IButtonSoftware,
        IButtonProtocol
    {
        /// <summary>
        /// Creates <see cref="IIgnition{TModule}"/> for <see cref="IButtonSoftware"/>.
        /// </summary>
        /// <param name="configuration">
        /// <see cref="IButtonConfiguration"/> to ignite.
        /// </param>
        /// <returns>
        /// <see cref="IIgnition{TModule}"/> to ignite <see cref="IButtonSoftware"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="configuration"/> is null.
        /// </exception>
        public static IIgnition<IButtonSoftware> Ignite(IButtonConfiguration configuration)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            return WithoutCache().Ignite(configuration);
        }

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
            var configuration = ImitatedButton.Instance;

            return new Button(Propagate.WithLatestCache(configuration.Touch), Propagate.WithLatestCache(configuration.Push));
        }

        /// <inheritdoc/>
        public IPropagation<Touch> Touch { get; }

        /// <inheritdoc/>
        public IPropagation<Push> Push { get; }

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
