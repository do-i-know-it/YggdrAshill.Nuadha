using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Conduction;
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
        public static IHeadTrackerModule WithList()
        {
            return new HeadTrackerModule(Propagate<Battery>.WithList(), Propagate<Space3D.Pose>.WithList());
        }

        private HeadTrackerModule(IPropagation<Battery> battery, IPropagation<Space3D.Pose> pose)
        {
            this.battery = battery;

            this.pose = pose;
        }

        private readonly IPropagation<Battery> battery;

        private readonly IPropagation<Space3D.Pose> pose;

        /// <inheritdoc/>
        public void Dispose()
        {
            battery.Dispose();

            pose.Dispose();
        }

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
