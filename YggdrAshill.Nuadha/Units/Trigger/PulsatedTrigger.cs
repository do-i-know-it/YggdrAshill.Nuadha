using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Units;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Implementation of <see cref="IProtocol{THardware, TSoftware}"/> for <see cref="IPulsatedTriggerHardware"/> and <see cref="IPulsatedTriggerSoftware"/>.
    /// </summary>
    public sealed class PulsatedTrigger :
        IPulsatedTriggerHardware,
        IPulsatedTriggerSoftware,
        IProtocol<IPulsatedTriggerHardware, IPulsatedTriggerSoftware>
    {
        /// <summary>
        /// <see cref="PulsatedTrigger"/> without cache.
        /// </summary>
        /// <returns>
        /// <see cref="PulsatedTrigger"/> without cache.
        /// </returns>
        public static PulsatedTrigger WithoutCache()
        {
            return new PulsatedTrigger(Propagate.WithoutCache<Pulse>(), Propagate.WithoutCache<Pulse>());
        }

        /// <summary>
        /// <see cref="PulsatedTrigger"/> with latest cache.
        /// </summary>
        /// <returns>
        /// <see cref="PulsatedTrigger"/> with latest cache.
        /// </returns>
        public static PulsatedTrigger WithLatestCache()
        {
            var generation = Generate.Signal(() => Pulse.IsDisabled);

            return new PulsatedTrigger(Propagate.WithLatestCache(generation), Propagate.WithLatestCache(generation));
        }

        private readonly IPropagation<Pulse> touch;

        private readonly IPropagation<Pulse> pull;

        private PulsatedTrigger(IPropagation<Pulse> touch, IPropagation<Pulse> pull)
        {
            this.touch = touch;

            this.pull = pull;
        }

        /// <inheritdoc/>
        public IPulsatedTriggerHardware Hardware => this;

        /// <inheritdoc/>
        public IPulsatedTriggerSoftware Software => this;

        /// <inheritdoc/>
        public void Dispose()
        {
            touch.Dispose();

            pull.Dispose();
        }

        IProduction<Pulse> IPulsatedTriggerHardware.Touch => touch;

        IProduction<Pulse> IPulsatedTriggerHardware.Pull => pull;

        IConsumption<Pulse> IPulsatedTriggerSoftware.Touch => touch;

        IConsumption<Pulse> IPulsatedTriggerSoftware.Pull => pull;
    }
}
