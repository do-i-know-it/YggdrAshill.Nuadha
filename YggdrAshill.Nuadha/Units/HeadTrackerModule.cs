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
            return new HeadTrackerModule(Propagate<Battery>.WithoutCache(), Propagate<Space3D.Pose>.WithoutCache());
        }

        /// <summary>
        /// <see cref="IHeadTrackerModule"/> with latest cache.
        /// </summary>
        /// <returns>
        /// <see cref="IHeadTrackerModule"/> initialized.
        /// </returns>
        public static IHeadTrackerModule WithLatestCache()
        {
            return new HeadTrackerModule(Propagate<Battery>.WithLatestCache(Battery.Full), Propagate<Space3D.Pose>.WithLatestCache(Space3D.Pose.Origin));
        }

        private HeadTrackerModule(IPropagation<Battery> battery, IPropagation<Space3D.Pose> pose)
        {
            this.battery = battery;

            this.pose = pose;
        }

        private readonly IPropagation<Battery> battery;

        private readonly IPropagation<Space3D.Pose> pose;

        /// <inheritdoc/>
        public IHeadTrackerHardware Hardware => this;

        /// <inheritdoc/>
        public IHeadTrackerSoftware Software => this;

        /// <inheritdoc/>
        IProduction<Battery> IHeadTrackerHardware.Battery => battery;

        /// <inheritdoc/>
        IProduction<Space3D.Pose> IHeadTrackerHardware.Pose => pose;

        /// <inheritdoc/>
        IConsumption<Space3D.Pose> IHeadTrackerSoftware.Pose => pose;

        /// <inheritdoc/>
        IConsumption<Battery> IHeadTrackerSoftware.Battery => battery;
    }
}
