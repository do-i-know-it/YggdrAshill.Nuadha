using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Units;

namespace YggdrAshill.Nuadha
{
    /// <inheritdoc/>
    public sealed class PulsatedButtonModule :
        IPulsatedButtonHardwareHandler,
        IPulsatedButtonSoftwareHandler,
        IModule<IPulsatedButtonHardwareHandler, IPulsatedButtonSoftwareHandler>
    {
        /// <summary>
        /// <see cref="PulsatedButtonModule"/> without cache.
        /// </summary>
        /// <returns>
        /// <see cref="PulsatedButtonModule"/> without cache.
        /// </returns>
        public static PulsatedButtonModule WithoutCache()
        {
            return new PulsatedButtonModule(Propagation.WithoutCache.Of<Pulse>(), Propagation.WithoutCache.Of<Pulse>());
        }

        /// <summary>
        /// <see cref="PulsatedButtonModule"/> with latest cache.
        /// </summary>
        /// <returns>
        /// <see cref="PulsatedButtonModule"/> with latest cache.
        /// </returns>
        public static PulsatedButtonModule WithLatestCache()
        {
            return new PulsatedButtonModule(Propagation.WithLatestCache.Of(Initialize.Pulse), Propagation.WithLatestCache.Of(Initialize.Pulse));
        }

        private readonly IPropagation<Pulse> touch;

        private readonly IPropagation<Pulse> push;

        private PulsatedButtonModule(IPropagation<Pulse> touch, IPropagation<Pulse> push)
        {
            this.touch = touch;

            this.push = push;
        }

        /// <inheritdoc/>
        public IPulsatedButtonHardwareHandler HardwareHandler => this;

        /// <inheritdoc/>
        public IPulsatedButtonSoftwareHandler SoftwareHandler => this;

        /// <inheritdoc/>
        public void Dispose()
        {
            touch.Dispose();

            push.Dispose();
        }

        /// <inheritdoc/>
        IConsumption<Pulse> IPulsatedButtonHardwareHandler.Touch => touch;

        /// <inheritdoc/>
        IConsumption<Pulse> IPulsatedButtonHardwareHandler.Push => push;

        /// <inheritdoc/>
        IProduction<Pulse> IPulsatedButtonSoftwareHandler.Touch => touch;

        /// <inheritdoc/>
        IProduction<Pulse> IPulsatedButtonSoftwareHandler.Push => push;
    }
}
