using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Units;

namespace YggdrAshill.Nuadha
{
    /// <inheritdoc/>
    public sealed class PulsatedTriggerModule :
        IPulsatedTriggerHardwareHandler,
        IPulsatedTriggerSoftwareHandler,
        IModule<IPulsatedTriggerHardwareHandler, IPulsatedTriggerSoftwareHandler>
    {
        /// <summary>
        /// <see cref="PulsatedTriggerModule"/> without cache.
        /// </summary>
        /// <returns>
        /// <see cref="PulsatedTriggerModule"/> without cache.
        /// </returns>
        public static PulsatedTriggerModule WithoutCache()
        {
            return new PulsatedTriggerModule(Propagation.WithoutCache.Of<Pulse>(), Propagation.WithoutCache.Of<Pulse>());
        }

        /// <summary>
        /// <see cref="PulsatedTriggerModule"/> with latest cache.
        /// </summary>
        /// <returns>
        /// <see cref="PulsatedTriggerModule"/> with latest cache.
        /// </returns>
        public static PulsatedTriggerModule WithLatestCache()
        {
            return new PulsatedTriggerModule(Propagation.WithLatestCache.Of(Initialize.Pulse), Propagation.WithLatestCache.Of(Initialize.Pulse));
        }

        private readonly IPropagation<Pulse> touch;

        private readonly IPropagation<Pulse> pull;

        private PulsatedTriggerModule(IPropagation<Pulse> touch, IPropagation<Pulse> pull)
        {
            this.touch = touch;

            this.pull = pull;
        }

        /// <inheritdoc/>
        public IPulsatedTriggerHardwareHandler HardwareHandler => this;

        /// <inheritdoc/>
        public IPulsatedTriggerSoftwareHandler SoftwareHandler => this;

        /// <inheritdoc/>
        public void Dispose()
        {
            touch.Dispose();

            pull.Dispose();
        }

        /// <inheritdoc/>
        IConsumption<Pulse> IPulsatedTriggerHardwareHandler.Touch => touch;

        /// <inheritdoc/>
        IConsumption<Pulse> IPulsatedTriggerHardwareHandler.Pull => pull;

        /// <inheritdoc/>
        IProduction<Pulse> IPulsatedTriggerSoftwareHandler.Touch => touch;

        /// <inheritdoc/>
        IProduction<Pulse> IPulsatedTriggerSoftwareHandler.Pull => pull;
    }
}
