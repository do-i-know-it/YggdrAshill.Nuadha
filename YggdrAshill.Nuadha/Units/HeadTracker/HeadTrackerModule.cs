using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;
using YggdrAshill.Nuadha.Units;

namespace YggdrAshill.Nuadha
{
    /// <inheritdoc/>
    public sealed class HeadTrackerModule :
        IHeadTrackerHardwareHandler,
        IHeadTrackerSoftwareHandler,
        IModule<IHeadTrackerHardwareHandler, IHeadTrackerSoftwareHandler>
    {
        /// <summary>
        /// <see cref="HeadTrackerModule"/> without cache.
        /// </summary>
        /// <returns>
        /// <see cref="HeadTrackerModule"/> without cache.
        /// </returns>
        public static HeadTrackerModule WithoutCache()
        {
            return new HeadTrackerModule(PoseTrackerModule.WithoutCache(), Propagation.WithoutCache.Of<Space3D.Direction>());
        }

        /// <summary>
        /// <see cref="HeadTrackerModule"/> with latest cache.
        /// </summary>
        /// <returns>
        /// <see cref="HeadTrackerModule"/> with latest cache.
        /// </returns>
        public static HeadTrackerModule WithLatestCache()
        {
            return new HeadTrackerModule(PoseTrackerModule.WithLatestCache(), Propagation.WithLatestCache.Of(Initialize.Space3D.Direction));
        }

        internal PoseTrackerModule Pose { get; }

        internal IPropagation<Space3D.Direction> Direction { get; }

        private HeadTrackerModule(PoseTrackerModule pose, IPropagation<Space3D.Direction> direction)
        {
            Pose = pose;

            Direction = direction;
        }

        /// <inheritdoc/>
        public IHeadTrackerHardwareHandler HardwareHandler => this;

        /// <inheritdoc/>
        public IHeadTrackerSoftwareHandler SoftwareHandler => this;

        /// <inheritdoc/>
        public void Dispose()
        {
            Pose.Dispose();

            Direction.Dispose();
        }

        /// <inheritdoc/>
        IPoseTrackerHardwareHandler IHeadTrackerHardwareHandler.Pose => Pose.HardwareHandler;

        /// <inheritdoc/>
        IConsumption<Space3D.Direction> IHeadTrackerHardwareHandler.Direction => Direction;

        /// <inheritdoc/>
        IPoseTrackerSoftwareHandler IHeadTrackerSoftwareHandler.Pose => Pose.SoftwareHandler;

        /// <inheritdoc/>
        IProduction<Space3D.Direction> IHeadTrackerSoftwareHandler.Direction => Direction;
    }
}
