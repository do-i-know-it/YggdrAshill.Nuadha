using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Units;

namespace YggdrAshill.Nuadha
{
    /// <inheritdoc/>
    public sealed class PulsatedTrigger :
        IPulsatedTriggerSoftware,
        IPulsatedTriggerHardware,
        IProtocol<IPulsatedTriggerSoftware, IPulsatedTriggerHardware>
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
            return new PulsatedTrigger(Propagate.WithLatestCache(Initialize.Pulse), Propagate.WithLatestCache(Initialize.Pulse));
        }

        private readonly IPropagation<Pulse> touch;

        private readonly IPropagation<Pulse> pull;

        private PulsatedTrigger(IPropagation<Pulse> touch, IPropagation<Pulse> pull)
        {
            this.touch = touch;

            this.pull = pull;
        }

        /// <inheritdoc/>
        public IPulsatedTriggerSoftware Hardware => this;

        /// <inheritdoc/>
        public IPulsatedTriggerHardware Software => this;

        /// <inheritdoc/>
        public void Dispose()
        {
            touch.Dispose();

            pull.Dispose();
        }

        /// <inheritdoc/>
        IConsumption<Pulse> IPulsatedTriggerSoftware.Touch => touch;

        /// <inheritdoc/>
        IConsumption<Pulse> IPulsatedTriggerSoftware.Pull => pull;

        /// <inheritdoc/>
        IProduction<Pulse> IPulsatedTriggerHardware.Touch => touch;

        /// <inheritdoc/>
        IProduction<Pulse> IPulsatedTriggerHardware.Pull => pull;
    }
}
