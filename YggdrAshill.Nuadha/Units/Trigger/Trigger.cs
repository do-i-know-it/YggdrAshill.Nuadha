using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;
using YggdrAshill.Nuadha.Units;

namespace YggdrAshill.Nuadha
{
    /// <inheritdoc/>
    public sealed class Trigger :
        ITriggerSoftware,
        ITriggerHardware,
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
            return new Trigger(Propagation.WithoutCache.Of<Touch>(), Propagation.WithoutCache.Of<Pull>());
        }

        /// <summary>
        /// <see cref="Trigger"/> with latest cache.
        /// </summary>
        /// <returns>
        /// <see cref="Trigger"/> with latest cache.
        /// </returns>
        public static Trigger WithLatestCache()
        {
            return new Trigger(Propagation.WithLatestCache.Of(Initialize.Touch), Propagation.WithLatestCache.Of(Initialize.Pull));
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

        /// <inheritdoc/>
        IConsumption<Touch> ITriggerSoftware.Touch => Touch;

        /// <inheritdoc/>
        IConsumption<Pull> ITriggerSoftware.Pull => Pull;

        /// <inheritdoc/>
        IProduction<Touch> ITriggerHardware.Touch => Touch;

        /// <inheritdoc/>
        IProduction<Pull> ITriggerHardware.Pull => Pull;
    }
}
