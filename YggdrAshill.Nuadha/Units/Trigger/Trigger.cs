using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Signals;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Defines implementations of <see cref="ITriggerProtocol"/>.
    /// </summary>
    public sealed class Trigger :
        ITriggerHardware,
        ITriggerSoftware,
        ITriggerProtocol
    {
        /// <summary>
        /// Converts <see cref="ITriggerConfiguration"/> into <see cref="ITransmission{TModule}"/> for <see cref="ITriggerSoftware"/>.
        /// </summary>
        /// <param name="configuration">
        /// <see cref="ITriggerConfiguration"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="ITransmission{TModule}"/> for <see cref="ITriggerSoftware"/> converted from <see cref="ITriggerConfiguration"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="configuration"/> is null.
        /// </exception>
        public static ITransmission<ITriggerSoftware> Transmit(ITriggerConfiguration configuration)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            return WithoutCache().Transmit(configuration);
        }

        /// <summary>
        /// <see cref="ITriggerProtocol"/> without cache.
        /// </summary>
        /// <returns>
        /// <see cref="ITriggerProtocol"/> initialized.
        /// </returns>
        public static ITriggerProtocol WithoutCache()
        {
            return new Trigger(Propagate.WithoutCache<Touch>(), Propagate.WithoutCache<Pull>());
        }

        /// <summary>
        /// <see cref="ITriggerProtocol"/> with latest cache.
        /// </summary>
        /// <param name="configuration">
        /// <see cref="ITriggerConfiguration"/> to initialize.
        /// </param>
        /// <returns>
        /// <see cref="ITriggerProtocol"/> initialized.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="configuration"/> is null.
        /// </exception>
        public static ITriggerProtocol WithLatestCache(ITriggerConfiguration configuration)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            return new Trigger(Propagate.WithLatestCache(configuration.Touch), Propagate.WithLatestCache(configuration.Pull));
        }

        /// <summary>
        /// <see cref="ITriggerProtocol"/> with latest cache.
        /// </summary>
        /// <returns>
        /// <see cref="ITriggerProtocol"/> initialized.
        /// </returns>
        public static ITriggerProtocol WithLatestCache()
        {
            return WithLatestCache(Imitate.Trigger);
        }

        private Trigger(IPropagation<Touch> touch, IPropagation<Pull> pull)
        {
            Touch = touch;

            Pull = pull;
        }

        /// <inheritdoc/>
        public IPropagation<Touch> Touch { get; }

        /// <inheritdoc/>
        public IPropagation<Pull> Pull { get; }
        
        /// <inheritdoc/>
        public ITriggerHardware Hardware => this;

        /// <inheritdoc/>
        public ITriggerSoftware Software => this;

        /// <inheritdoc/>
        IProduction<Touch> ITriggerHardware.Touch => Touch;

        /// <inheritdoc/>
        IProduction<Pull> ITriggerHardware.Pull => Pull;

        /// <inheritdoc/>
        IConsumption<Touch> ITriggerSoftware.Touch => Touch;

        /// <inheritdoc/>
        IConsumption<Pull> ITriggerSoftware.Pull => Pull;
    }
}
