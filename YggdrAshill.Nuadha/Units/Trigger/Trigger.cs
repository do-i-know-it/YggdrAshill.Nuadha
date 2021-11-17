using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Signals;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Implementation of <see cref="ITriggerProtocol"/>.
    /// </summary>
    public sealed class Trigger :
        ITriggerHardware,
        ITriggerSoftware,
        ITriggerProtocol
    {
        /// <summary>
        /// Creates <see cref="IIgnition{TModule}"/> for <see cref="ITriggerSoftware"/>.
        /// </summary>
        /// <param name="configuration">
        /// <see cref="ITriggerConfiguration"/> to ignite.
        /// </param>
        /// <returns>
        /// <see cref="IIgnition{TModule}"/> to ignite <see cref="ITriggerSoftware"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="configuration"/> is null.
        /// </exception>
        public static IIgnition<ITriggerSoftware> Ignite(ITriggerConfiguration configuration)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            return WithoutCache().Ignite(configuration);
        }

        /// <summary>
        /// <see cref="ITriggerProtocol"/> without cache.
        /// </summary>
        /// <returns>
        /// <see cref="ITriggerProtocol"/> without cache.
        /// </returns>
        public static ITriggerProtocol WithoutCache()
        {
            return new Trigger(Propagate.WithoutCache<Touch>(), Propagate.WithoutCache<Pull>());
        }

        /// <summary>
        /// <see cref="ITriggerProtocol"/> with latest cache.
        /// </summary>
        /// <returns>
        /// <see cref="ITriggerProtocol"/> with latest cache.
        /// </returns>
        public static ITriggerProtocol WithLatestCache()
        {
            var configuration = ImitatedTrigger.Instance;

            return new Trigger(Propagate.WithLatestCache(configuration.Touch), Propagate.WithLatestCache(configuration.Pull));
        }

        /// <inheritdoc/>
        public IPropagation<Touch> Touch { get; }

        /// <inheritdoc/>
        public IPropagation<Pull> Pull { get; }

        private Trigger(IPropagation<Touch> touch, IPropagation<Pull> pull)
        {
            Touch = touch;

            Pull = pull;
        }

        /// <inheritdoc/>
        public ITriggerHardware Hardware => this;

        /// <inheritdoc/>
        public ITriggerSoftware Software => this;

        /// <inheritdoc/>
        public void Dispose()
        {
            Touch.Dispose();

            Pull.Dispose();
        }

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
