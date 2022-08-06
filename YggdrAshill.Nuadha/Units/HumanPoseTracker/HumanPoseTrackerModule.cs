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
            return new HumanPoseTrackerModule(Propagate.WithoutCache<Space3D.Pose>(), Propagate.WithoutCache<Space3D.Pose>(), Propagate.WithoutCache<Space3D.Pose>());
        }

        /// <summary>
        /// <see cref="IHumanPoseTrackerModule"/> with latest cache.
        /// </summary>
        /// <returns>
        /// <see cref="IHumanPoseTrackerModule"/> initialized.
        /// </returns>
        public static IHumanPoseTrackerModule WithLatestCache()
        {
            return new HumanPoseTrackerModule(Propagate.WithLatestCache(Imitate.Pose), Propagate.WithLatestCache(Imitate.Pose), Propagate.WithLatestCache(Imitate.Pose));
        }

        private HumanPoseTrackerModule(IPropagation<Space3D.Pose> head, IPropagation<Space3D.Pose> leftHand, IPropagation<Space3D.Pose> rightHand)
        {
            Head = head;

            LeftHand = leftHand;

            RightHand = rightHand;
        }

        /// <inheritdoc/>
        public IPropagation<Space3D.Pose> Head { get; }

        /// <inheritdoc/>
        public IPropagation<Space3D.Pose> LeftHand { get; }

        /// <inheritdoc/>
        public IPropagation<Space3D.Pose> RightHand { get; }

        /// <inheritdoc/>
        public IHumanPoseTrackerHardware Hardware => this;

        /// <inheritdoc/>
        public IHumanPoseTrackerSoftware Software => this;

        /// <inheritdoc/>
        IProduction<Space3D.Pose> IHumanPoseTrackerHardware.Head => Head;

        /// <inheritdoc/>
        IProduction<Space3D.Pose> IHumanPoseTrackerHardware.LeftHand => LeftHand;

        /// <inheritdoc/>
        IProduction<Space3D.Pose> IHumanPoseTrackerHardware.RightHand => RightHand;

        /// <inheritdoc/>
        IConsumption<Space3D.Pose> IHumanPoseTrackerSoftware.Head => Head;

        /// <inheritdoc/>
        IConsumption<Space3D.Pose> IHumanPoseTrackerSoftware.LeftHand => LeftHand;

        /// <inheritdoc/>
        IConsumption<Space3D.Pose> IHumanPoseTrackerSoftware.RightHand => RightHand;
    }
}
