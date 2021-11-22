using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Signals;
using YggdrAshill.Nuadha.Units;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Defines implementations of <see cref="IStickProtocol"/>.
    /// </summary>
    public sealed class Stick :
        IStickHardware,
        IStickSoftware,
        IStickProtocol
    {
        /// <summary>
        /// <see cref="IStickProtocol"/> without cache.
        /// </summary>
        /// <returns>
        /// <see cref="IStickProtocol"/> without cache.
        /// </returns>
        public static IStickProtocol WithoutCache()
        {
            return new Stick(Propagate.WithoutCache<Touch>(), Propagate.WithoutCache<Tilt>());
        }

        /// <summary>
        /// <see cref="IStickProtocol"/> with latest cache.
        /// </summary>
        /// <returns>
        /// <see cref="IStickProtocol"/> with latest cache.
        /// </returns>
        public static IStickProtocol WithLatestCache()
        {
            return new Stick(Propagate.WithLatestCache(Imitate.Touch), Propagate.WithLatestCache(Imitate.Tilt));
        }

        private Stick(IPropagation<Touch> touch, IPropagation<Tilt> tilt)
        {
            Touch = touch;

            Tilt = tilt;
        }

        /// <inheritdoc/>
        public IPropagation<Touch> Touch { get; }

        /// <inheritdoc/>
        public IPropagation<Tilt> Tilt { get; }

        /// <inheritdoc/>
        public IStickHardware Hardware => this;

        /// <inheritdoc/>
        public IStickSoftware Software => this;

        /// <inheritdoc/>
        IProduction<Touch> IStickHardware.Touch => Touch;

        /// <inheritdoc/>
        IProduction<Tilt> IStickHardware.Tilt => Tilt;

        /// <inheritdoc/>
        IConsumption<Touch> IStickSoftware.Touch => Touch;

        /// <inheritdoc/>
        IConsumption<Tilt> IStickSoftware.Tilt => Tilt;
    }
}
