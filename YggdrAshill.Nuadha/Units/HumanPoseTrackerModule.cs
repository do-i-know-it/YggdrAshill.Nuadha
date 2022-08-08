using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Conduction;
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
        public static IHumanPoseTrackerModule WithList()
        {
            return new HumanPoseTrackerModule(Propagate<Space3D.Pose>.WithList(), Propagate<Space3D.Pose>.WithList(), Propagate<Space3D.Pose>.WithList());
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
        public void Dispose()
        {
            head.Dispose();

            leftHand.Dispose();

            rightHand.Dispose();
        }

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
