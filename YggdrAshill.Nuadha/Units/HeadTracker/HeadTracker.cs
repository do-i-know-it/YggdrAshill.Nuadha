using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Signals;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Implementation of <see cref="IHeadTrackerProtocol"/>.
    /// </summary>
    public sealed class HeadTracker :
        IHeadTrackerHardware,
        IHeadTrackerSoftware,
        IHeadTrackerProtocol
    {
        /// <summary>
        /// Creates <see cref="IIgnition{TModule}"/> for <see cref="IHeadTrackerSoftware"/>.
        /// </summary>
        /// <param name="configuration">
        /// <see cref="IHeadTrackerConfiguration"/> to ignite.
        /// </param>
        /// <returns>
        /// <see cref="IIgnition{TModule}"/> to ignite <see cref="IHeadTrackerSoftware"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="configuration"/> is null.
        /// </exception>
        public static IIgnition<IHeadTrackerSoftware> Ignite(IHeadTrackerConfiguration configuration)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            return WithoutCache().Ignite(configuration);
        }

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
            return new HeadTracker(PoseTracker.WithLatestCache(), Propagate.WithLatestCache(ImitatedHeadTracker.Instance.Direction));
        }

        /// <inheritdoc/>
        public IPoseTrackerProtocol Pose { get; }

        /// <inheritdoc/>
        public IPropagation<Space3D.Direction> Direction { get; }

        private HeadTracker(IPoseTrackerProtocol pose, IPropagation<Space3D.Direction> direction)
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
