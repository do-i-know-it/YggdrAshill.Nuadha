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
        /// <see cref="IPulsatedButtonProtocol"/> without cache.
        /// </summary>
        /// <returns>
        /// <see cref="IPulsatedButtonProtocol"/> initialized.
        /// </returns>
        public static IPulsatedButtonProtocol WithoutCache()
        {
            return new PulsatedButton(Propagate.WithoutCache<Pulse>(), Propagate.WithoutCache<Pulse>());
        }

        /// <summary>
        /// <see cref="IPulsatedButtonProtocol"/> with latest cache.
        /// </summary>
        /// <returns>
        /// <see cref="IPulsatedButtonProtocol"/> initialized.
        /// </returns>
        public static IPulsatedButtonProtocol WithLatestCache()
        {
            return new PulsatedButton(Propagate.WithLatestCache(Imitate.Pulse), Propagate.WithLatestCache(Imitate.Pulse));
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
