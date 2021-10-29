using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;
using YggdrAshill.Nuadha.Units;

namespace YggdrAshill.Nuadha
{
    /// Implementation of <see cref="IProtocol{THardware, TSoftware}"/> for <see cref="IPoseTrackerHardware"/> and <see cref="IPoseTrackerSoftware"/>.
    public sealed class PoseTracker :
        IPoseTrackerHardware,
        IPoseTrackerSoftware,
        IProtocol<IPoseTrackerHardware, IPoseTrackerSoftware>
    {
        /// <summary>
        /// <see cref="PoseTracker"/> without cache.
        /// </summary>
        /// <returns>
        /// <see cref="PoseTracker"/> without cache.
        /// </returns>
        public static PoseTracker WithoutCache()
        {
            return new PoseTracker(
                Propagate.WithoutCache<Space3D.Position>(),
                Propagate.WithoutCache<Space3D.Rotation>());
        }

        /// <summary>
        /// <see cref="PoseTracker"/> with latest cache.
        /// </summary>
        /// <returns>
        /// <see cref="PoseTracker"/> with latest cache.
        /// </returns>
        public static PoseTracker WithLatestCache()
        {
            return new PoseTracker(
                Propagate.WithLatestCache(Initialize.Space3D.Position),
                Propagate.WithLatestCache(Initialize.Space3D.Rotation));
        }

        internal IPropagation<Space3D.Position> Position { get; }

        internal IPropagation<Space3D.Rotation> Rotation { get; }

        private PoseTracker(IPropagation<Space3D.Position> position, IPropagation<Space3D.Rotation> rotation)
        {
            Position = position;

            Rotation = rotation;
        }

        /// <inheritdoc/>
        public IPoseTrackerHardware Hardware => this;

        /// <inheritdoc/>
        public IPoseTrackerSoftware Software => this;

        /// <inheritdoc/>
        public void Dispose()
        {
            Position.Dispose();

            Rotation.Dispose();
        }

        IProduction<Space3D.Position> IPoseTrackerHardware.Position => Position;

        IProduction<Space3D.Rotation> IPoseTrackerHardware.Rotation => Rotation;

        IConsumption<Space3D.Position> IPoseTrackerSoftware.Position => Position;

        IConsumption<Space3D.Rotation> IPoseTrackerSoftware.Rotation => Rotation;
    }
}
