using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;
using YggdrAshill.Nuadha.Units;

namespace YggdrAshill.Nuadha
{
    /// <inheritdoc/>
    public sealed class HeadTracker :
        IHeadTrackerSoftware,
        IHeadTrackerHardware,
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
            return new HeadTracker(PoseTracker.WithoutCache(), Propagation.WithoutCache.Of<Space3D.Direction>());
        }

        /// <summary>
        /// <see cref="HeadTracker"/> with latest cache.
        /// </summary>
        /// <returns>
        /// <see cref="HeadTracker"/> with latest cache.
        /// </returns>
        public static HeadTracker WithLatestCache()
        {
            return new HeadTracker(PoseTracker.WithLatestCache(), Propagation.WithLatestCache.Of(Initialize.Space3D.Direction));
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

        /// <inheritdoc/>
        IPoseTrackerSoftware IHeadTrackerSoftware.Pose => Pose.Hardware;

        /// <inheritdoc/>
        IConsumption<Space3D.Direction> IHeadTrackerSoftware.Direction => Direction;

        /// <inheritdoc/>
        IPoseTrackerHardware IHeadTrackerHardware.Pose => Pose.Software;

        /// <inheritdoc/>
        IProduction<Space3D.Direction> IHeadTrackerHardware.Direction => Direction;
    }
}
