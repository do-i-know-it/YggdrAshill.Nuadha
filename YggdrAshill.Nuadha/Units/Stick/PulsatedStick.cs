using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Units;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Defines implementations of <see cref="IPulsatedStickProtocol"/>.
    /// </summary>
    public sealed class PulsatedStick :
        IPulsatedStickHardware,
        IPulsatedStickSoftware,
        IPulsatedStickProtocol
    {
        /// <summary>
        /// <see cref="IPulsatedStickProtocol"/> without cache.
        /// </summary>
        /// <returns>
        /// <see cref="IPulsatedStickProtocol"/> initialized.
        /// </returns>
        public static IPulsatedStickProtocol WithoutCache()
        {
            return new PulsatedStick(Propagate.WithoutCache<Pulse>(), PulsatedTilt.WithoutCache());
        }

        /// <summary>
        /// <see cref="IPulsatedStickProtocol"/> with latest cache.
        /// </summary>
        /// <returns>
        /// <see cref="IPulsatedStickProtocol"/> initialized.
        /// </returns>
        public static IPulsatedStickProtocol WithLatestCache()
        {
            var generation = Generate.Signal(() => Pulse.IsDisabled);

            return new PulsatedStick(Propagate.WithLatestCache(generation), PulsatedTilt.WithLatestCache());
        }

        private PulsatedStick(IPropagation<Pulse> touch, IPulsatedTiltProtocol tilt)
        {
            Touch = touch;

            Tilt = tilt;
        }

        /// <inheritdoc/>
        public IPropagation<Pulse> Touch { get; }

        /// <inheritdoc/>
        public IPulsatedTiltProtocol Tilt { get; }

        /// <inheritdoc/>
        public IPulsatedStickHardware Hardware => this;

        /// <inheritdoc/>
        public IPulsatedStickSoftware Software => this;

        /// <inheritdoc/>
        IProduction<Pulse> IPulsatedStickHardware.Touch => Touch;

        /// <inheritdoc/>
        IPulsatedTiltHardware IPulsatedStickHardware.Tilt => Tilt.Hardware;

        /// <inheritdoc/>
        IConsumption<Pulse> IPulsatedStickSoftware.Touch => Touch;

        /// <inheritdoc/>
        IPulsatedTiltSoftware IPulsatedStickSoftware.Tilt => Tilt.Software;
    }
}
