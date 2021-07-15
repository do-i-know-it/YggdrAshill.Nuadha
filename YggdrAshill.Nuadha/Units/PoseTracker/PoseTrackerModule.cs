using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;
using YggdrAshill.Nuadha.Units;

namespace YggdrAshill.Nuadha
{
    /// <inheritdoc/>
    public sealed class PoseTrackerModule :
        IPoseTrackerHardwareHandler,
        IPoseTrackerSoftwareHandler,
        IModule<IPoseTrackerHardwareHandler, IPoseTrackerSoftwareHandler>
    {
        /// <summary>
        /// <see cref="PoseTrackerModule"/> without cache.
        /// </summary>
        /// <returns>
        /// <see cref="PoseTrackerModule"/> without cache.
        /// </returns>
        public static PoseTrackerModule WithoutCache()
        {
            return new PoseTrackerModule(
                Propagation.WithoutCache.Of<Space3D.Position>(),
                Propagation.WithoutCache.Of<Space3D.Rotation>());
        }

        /// <summary>
        /// <see cref="PoseTrackerModule"/> with latest cache.
        /// </summary>
        /// <returns>
        /// <see cref="PoseTrackerModule"/> with latest cache.
        /// </returns>
        public static PoseTrackerModule WithLatestCache()
        {
            return new PoseTrackerModule(
                Propagation.WithLatestCache.Of(Initialize.Space3D.Position),
                Propagation.WithLatestCache.Of(Initialize.Space3D.Rotation));
        }

        internal IPropagation<Space3D.Position> Position { get; }

        internal IPropagation<Space3D.Rotation> Rotation { get; }

        private PoseTrackerModule(IPropagation<Space3D.Position> position, IPropagation<Space3D.Rotation> rotation)
        {
            Position = position;

            Rotation = rotation;
        }

        /// <inheritdoc/>
        public IPoseTrackerHardwareHandler HardwareHandler => this;

        /// <inheritdoc/>
        public IPoseTrackerSoftwareHandler SoftwareHandler => this;

        /// <inheritdoc/>
        public void Dispose()
        {
            Position.Dispose();

            Rotation.Dispose();
        }

        /// <inheritdoc/>
        IConsumption<Space3D.Position> IPoseTrackerHardwareHandler.Position => Position;

        /// <inheritdoc/>
        IConsumption<Space3D.Rotation> IPoseTrackerHardwareHandler.Rotation => Rotation;

        /// <inheritdoc/>
        IProduction<Space3D.Position> IPoseTrackerSoftwareHandler.Position => Position;

        /// <inheritdoc/>
        IProduction<Space3D.Rotation> IPoseTrackerSoftwareHandler.Rotation => Rotation;
    }
}
