using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;
using YggdrAshill.Nuadha.Units;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Implementation of <see cref="IProtocol{THardware, TSoftware}"/> for <see cref="IHeadTrackerHardware"/> and <see cref="IHeadTrackerSoftware"/>.
    /// </summary>
    public sealed class HeadTracker :
        IHeadTrackerHardware,
        IHeadTrackerSoftware,
        IProtocol<IHeadTrackerHardware, IHeadTrackerSoftware>
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
            return new HeadTracker(PoseTracker.WithLatestCache(), Propagate.WithLatestCache(ImitatedHeadTracker.Instance.Direction));
        }

        internal PoseTracker Pose { get; }

        internal IPropagation<Space3D.Direction> Direction { get; }

        private HeadTracker(PoseTracker pose, IPropagation<Space3D.Direction> direction)
        {
            Pose = pose;

            Direction = direction;
        }

        /// <inheritdoc/>
        public IHeadTrackerHardware Hardware => this;

        /// <inheritdoc/>
        public IHeadTrackerSoftware Software => this;

        /// <inheritdoc/>
        public void Dispose()
        {
            Pose.Dispose();

            Direction.Dispose();
        }

        IPoseTrackerHardware IHeadTrackerHardware.Pose => Pose.Hardware;

        IProduction<Space3D.Direction> IHeadTrackerHardware.Direction => Direction;

        IPoseTrackerSoftware IHeadTrackerSoftware.Pose => Pose.Software;

        IConsumption<Space3D.Direction> IHeadTrackerSoftware.Direction => Direction;
    }
}
