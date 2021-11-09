using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;
using YggdrAshill.Nuadha.Units;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Implementation of <see cref="IProtocol{THardware, TSoftware}"/> for <see cref="ITriggerHardware"/> and <see cref="ITriggerSoftware"/>.
    /// </summary>
    public sealed class Trigger :
        ITriggerHardware,
        ITriggerSoftware,
        IProtocol<ITriggerHardware, ITriggerSoftware>
    {
        /// <summary>
        /// <see cref="Trigger"/> without cache.
        /// </summary>
        /// <returns>
        /// <see cref="Trigger"/> without cache.
        /// </returns>
        public static Trigger WithoutCache()
        {
            return new Trigger(Propagate.WithoutCache<Touch>(), Propagate.WithoutCache<Pull>());
        }

        /// <summary>
        /// <see cref="Trigger"/> with latest cache.
        /// </summary>
        /// <returns>
        /// <see cref="Trigger"/> with latest cache.
        /// </returns>
        public static Trigger WithLatestCache()
        {
            var configuration = ImitatedTrigger.Instance;

            return new Trigger(Propagate.WithLatestCache(configuration.Touch), Propagate.WithLatestCache(configuration.Pull));
        }

        internal IPropagation<Touch> Touch { get; }

        internal IPropagation<Pull> Pull { get; }

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

        IProduction<Touch> ITriggerHardware.Touch => Touch;

        IProduction<Pull> ITriggerHardware.Pull => Pull;

        IConsumption<Touch> ITriggerSoftware.Touch => Touch;

        IConsumption<Pull> ITriggerSoftware.Pull => Pull;
    }
}
