using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Signals;
using YggdrAshill.Nuadha.Units;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Defines implementations of <see cref="IHeadTrackerModule"/>.
    /// </summary>
    public sealed class HeadTrackerModule :
        IHeadTrackerHardware,
        IHeadTrackerSoftware,
        IHeadTrackerModule
    {
        /// <summary>
        /// <see cref="IHeadTrackerModule"/> without cache.
        /// </summary>
        /// <returns>
        /// <see cref="IHeadTrackerModule"/> initialized.
        /// </returns>
        public static IHeadTrackerModule WithoutCache()
        {
            return new HeadTrackerModule(Propagate.WithoutCache<Battery>(), Propagate.WithoutCache<Space3D.Pose>());
        }

        /// <summary>
        /// <see cref="IHeadTrackerModule"/> with latest cache.
        /// </summary>
        /// <returns>
        /// <see cref="IHeadTrackerModule"/> initialized.
        /// </returns>
        public static IHeadTrackerModule WithLatestCache()
        {
            return new HeadTrackerModule(Propagate.WithLatestCache(Imitate.Battery), Propagate.WithLatestCache(Imitate.Pose));
        }

        private HeadTrackerModule(IPropagation<Battery> battery, IPropagation<Space3D.Pose> pose)
        {
            Battery = battery;

            Pose = pose;
        }

        /// <inheritdoc/>
        public IPropagation<Battery> Battery { get; }

        /// <inheritdoc/>
        public IPropagation<Space3D.Pose> Pose { get; }

        /// <inheritdoc/>
        public IHeadTrackerHardware Hardware => this;

        /// <inheritdoc/>
        public IHeadTrackerSoftware Software => this;

        /// <inheritdoc/>
        IProduction<Battery> IHeadTrackerHardware.Battery => Battery;

        /// <inheritdoc/>
        IProduction<Space3D.Pose> IHeadTrackerHardware.Pose => Pose;

        /// <inheritdoc/>
        IConsumption<Space3D.Pose> IHeadTrackerSoftware.Pose => Pose;

        /// <inheritdoc/>
        IConsumption<Battery> IHeadTrackerSoftware.Battery => Battery;

    }
}
