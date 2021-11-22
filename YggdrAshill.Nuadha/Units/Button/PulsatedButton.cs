using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Units;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Defines implementations of <see cref="IPulsatedButtonProtocol"/>.
    /// </summary>
    public sealed class PulsatedButton :
        IPulsatedButtonHardware,
        IPulsatedButtonSoftware,
        IPulsatedButtonProtocol
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

        private PulsatedButton(IPropagation<Pulse> touch, IPropagation<Pulse> push)
        {
            Touch = touch;

            Push = push;
        }

        /// <inheritdoc/>
        public IPropagation<Pulse> Touch { get; }

        /// <inheritdoc/>
        public IPropagation<Pulse> Push { get; }

        /// <inheritdoc/>
        public IPulsatedButtonHardware Hardware => this;

        /// <inheritdoc/>
        public IPulsatedButtonSoftware Software => this;

        /// <inheritdoc/>
        IProduction<Pulse> IPulsatedButtonHardware.Touch => Touch;

        /// <inheritdoc/>
        IProduction<Pulse> IPulsatedButtonHardware.Push => Push;

        /// <inheritdoc/>
        IConsumption<Pulse> IPulsatedButtonSoftware.Touch => Touch;

        /// <inheritdoc/>
        IConsumption<Pulse> IPulsatedButtonSoftware.Push => Push;
    }
}
