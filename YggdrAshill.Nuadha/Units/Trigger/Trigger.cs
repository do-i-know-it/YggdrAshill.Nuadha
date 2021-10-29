using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;
using YggdrAshill.Nuadha.Units;

namespace YggdrAshill.Nuadha
{
    /// Implementation of <see cref="IProtocol{THardware, TSoftware}"/> for <see cref="ITriggerHardware"/> and <see cref="ITriggerSoftware"/>.
    public sealed class Trigger :
        ITriggerHardware,
        ITriggerSoftware,
        IProtocol<ITriggerSoftware, ITriggerHardware>
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
            return new Trigger(Propagate.WithLatestCache(Initialize.Touch), Propagate.WithLatestCache(Initialize.Pull));
        }

        internal IPropagation<Touch> Touch { get; }

        internal IPropagation<Pull> Pull { get; }

        private Trigger(IPropagation<Touch> touch, IPropagation<Pull> pull)
        {
            Touch = touch;

            Pull = pull;
        }

        /// <inheritdoc/>
        public ITriggerSoftware Hardware => this;

        /// <inheritdoc/>
        public ITriggerHardware Software => this;

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
