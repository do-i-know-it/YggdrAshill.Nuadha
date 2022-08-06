using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Signals;
using YggdrAshill.Nuadha.Units;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Defines implementations of <see cref="IHumanPoseTrackerModule"/>.
    /// </summary>
    public sealed class HumanPoseTrackerModule :
        IHumanPoseTrackerHardware,
        IHumanPoseTrackerSoftware,
        IHumanPoseTrackerModule
    {
        /// <summary>
        /// <see cref="IHumanPoseTrackerModule"/> without cache.
        /// </summary>
        /// <returns>
        /// <see cref="IHumanPoseTrackerModule"/> initialized.
        /// </returns>
        public static IHumanPoseTrackerModule WithoutCache()
        {
            return new HumanPoseTrackerModule(Propagate<Space3D.Pose>.WithoutCache(), Propagate<Space3D.Pose>.WithoutCache(), Propagate<Space3D.Pose>.WithoutCache());
        }

        /// <summary>
        /// <see cref="IHumanPoseTrackerModule"/> with latest cache.
        /// </summary>
        /// <returns>
        /// <see cref="IHumanPoseTrackerModule"/> initialized.
        /// </returns>
        public static IHumanPoseTrackerModule WithLatestCache()
        {
            return new HumanPoseTrackerModule(
                Propagate<Space3D.Pose>.WithLatestCache(Space3D.Pose.Origin),
                Propagate<Space3D.Pose>.WithLatestCache(Space3D.Pose.Origin),
                Propagate<Space3D.Pose>.WithLatestCache(Space3D.Pose.Origin));
        }

        private HumanPoseTrackerModule(IPropagation<Space3D.Pose> head, IPropagation<Space3D.Pose> leftHand, IPropagation<Space3D.Pose> rightHand)
        {
            this.head = head;

            this.leftHand = leftHand;

            this.rightHand = rightHand;
        }

        private readonly IPropagation<Space3D.Pose> head;

        private readonly IPropagation<Space3D.Pose> leftHand;

        private readonly IPropagation<Space3D.Pose> rightHand;

        /// <inheritdoc/>
        public IHumanPoseTrackerHardware Hardware => this;

        /// <inheritdoc/>
        public IHumanPoseTrackerSoftware Software => this;

        /// <inheritdoc/>
        IProduction<Space3D.Pose> IHumanPoseTrackerHardware.Head => head;

        /// <inheritdoc/>
        IProduction<Space3D.Pose> IHumanPoseTrackerHardware.LeftHand => leftHand;

        /// <inheritdoc/>
        IProduction<Space3D.Pose> IHumanPoseTrackerHardware.RightHand => rightHand;

        /// <inheritdoc/>
        IConsumption<Space3D.Pose> IHumanPoseTrackerSoftware.Head => head;

        /// <inheritdoc/>
        IConsumption<Space3D.Pose> IHumanPoseTrackerSoftware.LeftHand => leftHand;

        /// <inheritdoc/>
        IConsumption<Space3D.Pose> IHumanPoseTrackerSoftware.RightHand => rightHand;
    }
}
