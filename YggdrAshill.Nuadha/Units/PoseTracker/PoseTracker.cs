using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Signals;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Defines implementations of <see cref="IPoseTrackerProtocol"/>.
    /// </summary>
    public sealed class PoseTracker :
        IPoseTrackerHardware,
        IPoseTrackerSoftware,
        IPoseTrackerProtocol
    {
        /// <summary>
        /// Converts <see cref="IPoseTrackerConfiguration"/> into <see cref="ITransmission{TModule}"/> for <see cref="IPoseTrackerSoftware"/>.
        /// </summary>
        /// <param name="configuration">
        /// <see cref="IPoseTrackerConfiguration"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="ITransmission{TModule}"/> for <see cref="IPoseTrackerSoftware"/> converted from <see cref="IPoseTrackerConfiguration"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="configuration"/> is null.
        /// </exception>
        public static ITransmission<IPoseTrackerSoftware> Transmit(IPoseTrackerConfiguration configuration)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            return WithoutCache().Transmit(configuration);
        }

        /// <summary>
        /// <see cref="IPoseTrackerProtocol"/> without cache.
        /// </summary>
        /// <returns>
        /// <see cref="IPoseTrackerProtocol"/> initialized.
        /// </returns>
        public static IPoseTrackerProtocol WithoutCache()
        {
            return new PoseTracker(
                Propagate.WithoutCache<Space3D.Position>(),
                Propagate.WithoutCache<Space3D.Rotation>());
        }

        /// <summary>
        /// <see cref="IPoseTrackerProtocol"/> with latest cache.
        /// </summary>
        /// <param name="configuration">
        /// <see cref="IPoseTrackerConfiguration"/> to initialize.
        /// </param>
        /// <returns>
        /// <see cref="IPoseTrackerProtocol"/> initialized.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="configuration"/> is null.
        /// </exception>
        public static IPoseTrackerProtocol WithLatestCache(IPoseTrackerConfiguration configuration)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            return new PoseTracker(Propagate.WithLatestCache(configuration.Position), Propagate.WithLatestCache(configuration.Rotation));
        }

        /// <summary>
        /// <see cref="IPoseTrackerProtocol"/> with latest cache.
        /// </summary>
        /// <returns>
        /// <see cref="IPoseTrackerProtocol"/> initialized.
        /// </returns>
        public static IPoseTrackerProtocol WithLatestCache()
        {
            return WithLatestCache(Imitate.PoseTracker);
        }

        private PoseTracker(IPropagation<Space3D.Position> position, IPropagation<Space3D.Rotation> rotation)
        {
            Position = position;

            Rotation = rotation;
        }

        /// <inheritdoc/>
        public IPropagation<Space3D.Position> Position { get; }

        /// <inheritdoc/>
        public IPropagation<Space3D.Rotation> Rotation { get; }

        /// <inheritdoc/>
        public IPoseTrackerHardware Hardware => this;

        /// <inheritdoc/>
        public IPoseTrackerSoftware Software => this;

        /// <inheritdoc/>
        IProduction<Space3D.Position> IPoseTrackerHardware.Position => Position;

        /// <inheritdoc/>
        IProduction<Space3D.Rotation> IPoseTrackerHardware.Rotation => Rotation;

        /// <inheritdoc/>
        IConsumption<Space3D.Position> IPoseTrackerSoftware.Position => Position;

        /// <inheritdoc/>
        IConsumption<Space3D.Rotation> IPoseTrackerSoftware.Rotation => Rotation;
    }
}
