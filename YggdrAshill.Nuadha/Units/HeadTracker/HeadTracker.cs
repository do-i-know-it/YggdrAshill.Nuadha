using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;
using YggdrAshill.Nuadha.Units;

namespace YggdrAshill.Nuadha
{
    /// Implementation of <see cref="IProtocol{THardware, TSoftware}"/> for <see cref="IHeadTrackerHardware"/> and <see cref="IHeadTrackerSoftware"/>.
    public sealed class HeadTracker :
        IHeadTrackerHardware,
        IHeadTrackerSoftware,
        IProtocol<IHeadTrackerSoftware, IHeadTrackerHardware>
    {
        /// <summary>
        /// <see cref="HeadTracker"/> without cache.
        /// </summary>
        /// <returns>
        /// <see cref="HeadTracker"/> without cache.
        /// </returns>
        public static HeadTracker WithoutCache()
        {
            return new HeadTracker(PoseTracker.WithoutCache(), Propagate.WithoutCache<Space3D.Direction>());
        }

        /// <summary>
        /// <see cref="HeadTracker"/> with latest cache.
        /// </summary>
        /// <returns>
        /// <see cref="HeadTracker"/> with latest cache.
        /// </returns>
        public static HeadTracker WithLatestCache()
        {
            return new HeadTracker(PoseTracker.WithLatestCache(), Propagate.WithLatestCache(Initialize.Space3D.Direction));
        }

        internal PoseTracker Pose { get; }

        internal IPropagation<Space3D.Direction> Direction { get; }

        private HeadTracker(PoseTracker pose, IPropagation<Space3D.Direction> direction)
        {
            Pose = pose;

            Direction = direction;
        }

        /// <inheritdoc/>
        public IHeadTrackerSoftware Hardware => this;

        /// <inheritdoc/>
        public IHeadTrackerHardware Software => this;

        /// <inheritdoc/>
        public void Dispose()
        {
            Pose.Dispose();

            Direction.Dispose();
        }

        IPoseTrackerHardware IHeadTrackerHardware.Pose => Pose.Software;

        IProduction<Space3D.Direction> IHeadTrackerHardware.Direction => Direction;

        IPoseTrackerSoftware IHeadTrackerSoftware.Pose => Pose.Hardware;

        IConsumption<Space3D.Direction> IHeadTrackerSoftware.Direction => Direction;
    }
}
