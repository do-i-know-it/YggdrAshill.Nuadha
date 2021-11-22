using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Units;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Defines implementations of <see cref="IPulsatedTriggerProtocol"/>.
    /// </summary>
    public sealed class PulsatedTrigger :
        IPulsatedTriggerHardware,
        IPulsatedTriggerSoftware,
        IPulsatedTriggerProtocol
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

        private PulsatedTrigger(IPropagation<Pulse> touch, IPropagation<Pulse> pull)
        {
            Touch = touch;

            Pull = pull;
        }

        /// <inheritdoc/>
        public IPropagation<Pulse> Touch { get; }

        /// <inheritdoc/>
        public IPropagation<Pulse> Pull { get; }

        /// <inheritdoc/>
        public IPulsatedTriggerHardware Hardware => this;

        /// <inheritdoc/>
        public IPulsatedTriggerSoftware Software => this;

        /// <inheritdoc/>
        IProduction<Pulse> IPulsatedTriggerHardware.Touch => Touch;

        /// <inheritdoc/>
        IProduction<Pulse> IPulsatedTriggerHardware.Pull => Pull;

        /// <inheritdoc/>
        IConsumption<Pulse> IPulsatedTriggerSoftware.Touch => Touch;

        /// <inheritdoc/>
        IConsumption<Pulse> IPulsatedTriggerSoftware.Pull => Pull;
    }
}
