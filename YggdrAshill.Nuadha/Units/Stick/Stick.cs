using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Defines implementations of <see cref="IStickProtocol"/>.
    /// </summary>
    public sealed class Stick :
        IStickHardware,
        IStickSoftware,
        IStickProtocol
    {
        public static ITransmission<IStickSoftware> Transmit(IStickConfiguration configuration)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            return WithoutCache().Transmit(configuration);
        }

        /// <summary>
        /// <see cref="IStickProtocol"/> without cache.
        /// </summary>
        /// <returns>
        /// <see cref="IStickProtocol"/> initialized.
        /// </returns>
        public static IStickProtocol WithoutCache()
        {
            return new Stick(Propagate.WithoutCache<Touch>(), Propagate.WithoutCache<Tilt>());
        }

        /// <summary>
        /// <see cref="IStickProtocol"/> with latest cache.
        /// </summary>
        /// <param name="configuration">
        /// <see cref="IStickConfiguration"/> to initialize.
        /// </param>
        /// <returns>
        /// <see cref="IStickProtocol"/> initialized.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="configuration"/> is null.
        /// </exception>
        public static IStickProtocol WithLatestCache(IStickConfiguration configuration)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            return new Stick(Propagate.WithLatestCache(configuration.Touch), Propagate.WithLatestCache(configuration.Tilt));
        }

        /// <summary>
        /// <see cref="IStickProtocol"/> with latest cache.
        /// </summary>
        /// <returns>
        /// <see cref="IStickProtocol"/> initialized.
        /// </returns>
        public static IStickProtocol WithLatestCache()
        {
            return WithLatestCache(Imitate.Stick);
        }

        private Stick(IPropagation<Touch> touch, IPropagation<Tilt> tilt)
        {
            Touch = touch;

            Tilt = tilt;
        }

        /// <inheritdoc/>
        public IPropagation<Touch> Touch { get; }

        /// <inheritdoc/>
        public IPropagation<Tilt> Tilt { get; }

        /// <inheritdoc/>
        public IStickHardware Hardware => this;

        /// <inheritdoc/>
        public IStickSoftware Software => this;

        /// <inheritdoc/>
        IProduction<Touch> IStickHardware.Touch => Touch;

        /// <inheritdoc/>
        IProduction<Tilt> IStickHardware.Tilt => Tilt;

        /// <inheritdoc/>
        IConsumption<Touch> IStickSoftware.Touch => Touch;

        /// <inheritdoc/>
        IConsumption<Tilt> IStickSoftware.Tilt => Tilt;
    }
}
