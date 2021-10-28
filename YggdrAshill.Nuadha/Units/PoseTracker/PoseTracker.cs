using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;
using YggdrAshill.Nuadha.Units;

namespace YggdrAshill.Nuadha
{
    /// <inheritdoc/>
    public sealed class PoseTracker :
        IPoseTrackerSoftware,
        IPoseTrackerHardware,
        IProtocol<IPoseTrackerSoftware, IPoseTrackerHardware>
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
                Propagation.WithoutCache.Of<Space3D.Position>(),
                Propagation.WithoutCache.Of<Space3D.Rotation>());
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
                Propagation.WithLatestCache.Of(Initialize.Space3D.Position),
                Propagation.WithLatestCache.Of(Initialize.Space3D.Rotation));
        }

        internal IPropagation<Space3D.Position> Position { get; }

        internal IPropagation<Space3D.Rotation> Rotation { get; }

        private PoseTracker(IPropagation<Space3D.Position> position, IPropagation<Space3D.Rotation> rotation)
        {
            Position = position;

            Rotation = rotation;
        }

        /// <inheritdoc/>
        public IPoseTrackerSoftware Hardware => this;

        /// <inheritdoc/>
        public IPoseTrackerHardware Software => this;

        /// <inheritdoc/>
        public void Dispose()
        {
            Position.Dispose();

            Rotation.Dispose();
        }

        /// <inheritdoc/>
        IConsumption<Space3D.Position> IPoseTrackerSoftware.Position => Position;

        /// <inheritdoc/>
        IConsumption<Space3D.Rotation> IPoseTrackerSoftware.Rotation => Rotation;

        /// <inheritdoc/>
        IProduction<Space3D.Position> IPoseTrackerHardware.Position => Position;

        /// <inheritdoc/>
        IProduction<Space3D.Rotation> IPoseTrackerHardware.Rotation => Rotation;
    }
}
