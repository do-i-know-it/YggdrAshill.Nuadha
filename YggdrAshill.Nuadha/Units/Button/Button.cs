using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Signals;
using YggdrAshill.Nuadha.Units;
using System;

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
        /// Converts <see cref="IButtonConfiguration"/> into <see cref="ITransmission{TModule}"/> for <see cref="IButtonSoftware"/>.
        /// </summary>
        /// <param name="configuration">
        /// <see cref="IButtonConfiguration"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="ITransmission{TModule}"/> for <see cref="IButtonSoftware"/> converted from <see cref="IButtonConfiguration"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="configuration"/> is null.
        /// </exception>
        public static ITransmission<IButtonSoftware> Transmit(IButtonConfiguration configuration)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            return WithoutCache().Transmit(configuration);
        }

        /// <summary>
        /// <see cref="IButtonProtocol"/> without cache.
        /// </summary>
        /// <returns>
        /// <see cref="IButtonProtocol"/> initialized.
        /// </returns>
        public static IButtonProtocol WithoutCache()
        {
            return new Button(Propagate.WithoutCache<Touch>(), Propagate.WithoutCache<Push>());
        }

        /// <summary>
        /// <see cref="IButtonProtocol"/> with latest cache.
        /// </summary>
        /// <param name="configuration">
        /// <see cref="IButtonConfiguration"/> to initialize.
        /// </param>
        /// <returns>
        /// <see cref="IButtonProtocol"/> initialized.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="configuration"/> is null.
        /// </exception>
        public static IButtonProtocol WithLatestCache(IButtonConfiguration configuration)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            return new Button(Propagate.WithLatestCache(configuration.Touch), Propagate.WithLatestCache(configuration.Push));
        }

        /// <summary>
        /// <see cref="IButtonProtocol"/> with latest cache.
        /// </summary>
        /// <returns>
        /// <see cref="IButtonProtocol"/> initialized.
        /// </returns>
        public static IButtonProtocol WithLatestCache()
        {
            return WithLatestCache(Imitate.Button);
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
