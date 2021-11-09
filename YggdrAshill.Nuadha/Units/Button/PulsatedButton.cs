using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Units;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Implementation of <see cref="IProtocol{THardware, TSoftware}"/> for <see cref="IPulsatedButtonHardware"/> and <see cref="IPulsatedButtonSoftware"/>.
    /// </summary>
    public sealed class PulsatedButton :
        IPulsatedButtonHardware,
        IPulsatedButtonSoftware,
        IProtocol<IPulsatedButtonHardware, IPulsatedButtonSoftware>
    {
        /// <summary>
        /// <see cref="PulsatedButton"/> without cache.
        /// </summary>
        /// <returns>
        /// <see cref="PulsatedButton"/> without cache.
        /// </returns>
        public static PulsatedButton WithoutCache()
        {
            return new PulsatedButton(Propagate.WithoutCache<Pulse>(), Propagate.WithoutCache<Pulse>());
        }

        /// <summary>
        /// <see cref="PulsatedButton"/> with latest cache.
        /// </summary>
        /// <returns>
        /// <see cref="PulsatedButton"/> with latest cache.
        /// </returns>
        public static PulsatedButton WithLatestCache()
        {
            var generation = Generate.Signal(() => Pulse.IsDisabled);

            return new PulsatedButton(Propagate.WithLatestCache(generation), Propagate.WithLatestCache(generation));
        }

        private readonly IPropagation<Pulse> touch;

        private readonly IPropagation<Pulse> push;

        private PulsatedButton(IPropagation<Pulse> touch, IPropagation<Pulse> push)
        {
            this.touch = touch;

            this.push = push;
        }

        /// <inheritdoc/>
        public IPulsatedButtonHardware Hardware => this;

        /// <inheritdoc/>
        public IPulsatedButtonSoftware Software => this;

        /// <inheritdoc/>
        public void Dispose()
        {
            touch.Dispose();

            push.Dispose();
        }

        IProduction<Pulse> IPulsatedButtonHardware.Touch => touch;

        IProduction<Pulse> IPulsatedButtonHardware.Push => push;

        IConsumption<Pulse> IPulsatedButtonSoftware.Touch => touch;

        IConsumption<Pulse> IPulsatedButtonSoftware.Push => push;
    }
}
