using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Signals;
using YggdrAshill.Nuadha.Units;
using System;

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
        /// Converts <see cref="IHeadTrackerConfiguration"/> into <see cref="ITransmission{TModule}"/> for <see cref="IHeadTrackerSoftware"/>.
        /// </summary>
        /// <param name="configuration">
        /// <see cref="IHeadTrackerConfiguration"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="ITransmission{TModule}"/> for <see cref="IHeadTrackerSoftware"/> converted from <see cref="IHeadTrackerConfiguration"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="configuration"/> is null.
        /// </exception>
        public static ITransmission<IHeadTrackerSoftware> Transmit(IHeadTrackerConfiguration configuration)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            return WithoutCache().Transmit(configuration);
        }

        /// <summary>
        /// <see cref="IHeadTrackerProtocol"/> without cache.
        /// </summary>
        /// <returns>
        /// <see cref="IHeadTrackerProtocol"/> initialized.
        /// </returns>
        public static IHeadTrackerProtocol WithoutCache()
        {
            return new HeadTracker(Propagate.WithoutCache<Space3D.Pose>(), Propagate.WithoutCache<Space3D.Direction>());
        }

        /// <summary>
        /// <see cref="IHeadTrackerProtocol"/> with latest cache.
        /// </summary>
        /// <returns>
        /// <see cref="IHeadTrackerProtocol"/> initialized.
        /// </returns>
        public static IHeadTrackerProtocol WithLatestCache()
        {
            return new HeadTracker(Propagate.WithLatestCache(Imitate.Pose), Propagate.WithLatestCache(Imitate.Direction));
        }

        private HeadTracker(IPropagation<Space3D.Pose> pose, IPropagation<Space3D.Direction> direction)
        {
            Pose = pose;

            Direction = direction;
        }

        /// <inheritdoc/>
        public IPropagation<Space3D.Pose> Pose { get; }

        /// <inheritdoc/>
        public IPropagation<Space3D.Direction> Direction { get; }

        /// <inheritdoc/>
        public IHeadTrackerHardware Hardware => this;

        /// <inheritdoc/>
        public IHeadTrackerSoftware Software => this;

        /// <inheritdoc/>
        IProduction<Space3D.Pose> IHeadTrackerHardware.Pose => Pose;

        /// <inheritdoc/>
        IProduction<Space3D.Direction> IHeadTrackerHardware.Direction => Direction;

        /// <inheritdoc/>
        IConsumption<Space3D.Pose> IHeadTrackerSoftware.Pose => Pose;

        /// <inheritdoc/>
        IConsumption<Space3D.Direction> IHeadTrackerSoftware.Direction => Direction;
    }
}
