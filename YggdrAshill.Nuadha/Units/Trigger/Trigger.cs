using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Signals;
using YggdrAshill.Nuadha.Units;

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
            return new Trigger(Propagate.WithLatestCache(Imitate.Touch), Propagate.WithLatestCache(Imitate.Pull));
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
