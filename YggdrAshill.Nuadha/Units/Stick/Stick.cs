using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;
using YggdrAshill.Nuadha.Units;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Implementation of <see cref="IProtocol{THardware, TSoftware}"/> for <see cref="IStickHardware"/> and <see cref="IStickHardware"/>.
    /// </summary>
    public sealed class Stick :
        IStickHardware,
        IStickSoftware,
        IProtocol<IStickHardware, IStickSoftware>
    {
        /// <summary>
        /// <see cref="Stick"/> without cache.
        /// </summary>
        /// <returns>
        /// <see cref="Stick"/> without cache.
        /// </returns>
        public static Stick WithoutCache()
        {
            return new Stick(Propagate.WithoutCache<Touch>(), Propagate.WithoutCache<Tilt>());
        }

        /// <summary>
        /// <see cref="Stick"/> with latest cache.
        /// </summary>
        /// <returns>
        /// <see cref="Stick"/> with latest cache.
        /// </returns>
        public static Stick WithLatestCache()
        {
            var configuration = ImitatedStick.Instance;

            return new Stick(Propagate.WithLatestCache(configuration.Touch), Propagate.WithLatestCache(configuration.Tilt));
        }

        internal IPropagation<Touch> Touch { get; }

        internal IPropagation<Tilt> Tilt { get; }

        private Stick(IPropagation<Touch> touch, IPropagation<Tilt> tilt)
        {
            Touch = touch;

            Tilt = tilt;
        }

        /// <inheritdoc/>
        public IStickHardware Hardware => this;

        /// <inheritdoc/>
        public IStickSoftware Software => this;

        /// <inheritdoc/>
        public void Dispose()
        {
            Touch.Dispose();

            Tilt.Dispose();
        }

        IProduction<Touch> IStickHardware.Touch => Touch;

        IProduction<Tilt> IStickHardware.Tilt => Tilt;

        IConsumption<Touch> IStickSoftware.Touch => Touch;

        IConsumption<Tilt> IStickSoftware.Tilt => Tilt;
    }
}
