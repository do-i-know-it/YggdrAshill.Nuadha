using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Signals;
using YggdrAshill.Nuadha.Units;

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
        /// <see cref="IPoseTrackerProtocol"/> without cache.
        /// </summary>
        /// <returns>
        /// <see cref="IPoseTrackerProtocol"/> without cache.
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
        /// <returns>
        /// <see cref="IPoseTrackerProtocol"/> with latest cache.
        /// </returns>
        public static IPoseTrackerProtocol WithLatestCache()
        {
            return new PoseTracker(Propagate.WithLatestCache(Imitate.Position), Propagate.WithLatestCache(Imitate.Rotation));
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
