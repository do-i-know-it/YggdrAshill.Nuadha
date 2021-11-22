using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Signals;
using YggdrAshill.Nuadha.Units;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Defines implementations of <see cref="IHeadTrackerProtocol"/>.
    /// </summary>
    public sealed class HeadTracker :
        IHeadTrackerHardware,
        IHeadTrackerSoftware,
        IHeadTrackerProtocol
    {
        /// <summary>
        /// <see cref="IHeadTrackerProtocol"/> without cache.
        /// </summary>
        /// <returns>
        /// <see cref="IHeadTrackerProtocol"/> without cache.
        /// </returns>
        public static IHeadTrackerProtocol WithoutCache()
        {
            return new HeadTracker(PoseTracker.WithoutCache(), Propagate.WithoutCache<Space3D.Direction>());
        }

        /// <summary>
        /// <see cref="IHeadTrackerProtocol"/> with latest cache.
        /// </summary>
        /// <returns>
        /// <see cref="IHeadTrackerProtocol"/> with latest cache.
        /// </returns>
        public static IHeadTrackerProtocol WithLatestCache()
        {
            return new HeadTracker(PoseTracker.WithLatestCache(), Propagate.WithLatestCache(Imitate.Direction));
        }

        private HeadTracker(IPoseTrackerProtocol pose, IPropagation<Space3D.Direction> direction)
        {
            Pose = pose;

            Direction = direction;
        }

        /// <inheritdoc/>
        public IPoseTrackerProtocol Pose { get; }

        /// <inheritdoc/>
        public IPropagation<Space3D.Direction> Direction { get; }

        /// <inheritdoc/>
        public IHeadTrackerHardware Hardware => this;

        /// <inheritdoc/>
        public IHeadTrackerSoftware Software => this;

        /// <inheritdoc/>
        IPoseTrackerHardware IHeadTrackerHardware.Pose => Pose.Hardware;

        /// <inheritdoc/>
        IProduction<Space3D.Direction> IHeadTrackerHardware.Direction => Direction;

        /// <inheritdoc/>
        IPoseTrackerSoftware IHeadTrackerSoftware.Pose => Pose.Software;

        /// <inheritdoc/>
        IConsumption<Space3D.Direction> IHeadTrackerSoftware.Direction => Direction;
    }
}
