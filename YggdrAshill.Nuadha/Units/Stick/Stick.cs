using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;
using YggdrAshill.Nuadha.Units;

namespace YggdrAshill.Nuadha
{
    /// <inheritdoc/>
    public sealed class Stick :
        IStickSoftware,
        IStickHardware,
        IProtocol<IStickSoftware, IStickHardware>
    {
        /// <summary>
        /// <see cref="Stick"/> without cache.
        /// </summary>
        /// <returns>
        /// <see cref="Stick"/> without cache.
        /// </returns>
        public static Stick WithoutCache()
        {
            return new Stick(Propagation.WithoutCache.Of<Touch>(), Propagation.WithoutCache.Of<Tilt>());
        }

        /// <summary>
        /// <see cref="Stick"/> with latest cache.
        /// </summary>
        /// <returns>
        /// <see cref="Stick"/> with latest cache.
        /// </returns>
        public static Stick WithLatestCache()
        {
            return new Stick(Propagation.WithLatestCache.Of(Initialize.Touch), Propagation.WithLatestCache.Of(Initialize.Tilt));
        }

        internal IPropagation<Touch> Touch { get; }

        internal IPropagation<Tilt> Tilt { get; }

        private Stick(IPropagation<Touch> touch, IPropagation<Tilt> tilt)
        {
            Touch = touch;

            Tilt = tilt;
        }

        /// <inheritdoc/>
        public IStickSoftware Hardware => this;

        /// <inheritdoc/>
        public IStickHardware Software => this;

        /// <inheritdoc/>
        public void Dispose()
        {
            Touch.Dispose();

            Tilt.Dispose();
        }

        /// <inheritdoc/>
        IConsumption<Touch> IStickSoftware.Touch => Touch;

        /// <inheritdoc/>
        IConsumption<Tilt> IStickSoftware.Tilt => Tilt;

        /// <inheritdoc/>
        IProduction<Touch> IStickHardware.Touch => Touch;

        /// <inheritdoc/>
        IProduction<Tilt> IStickHardware.Tilt => Tilt;
    }
}
