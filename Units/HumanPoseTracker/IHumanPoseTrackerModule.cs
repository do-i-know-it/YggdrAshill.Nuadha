using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Units
{
    /// <summary>
    /// Defines <see cref="IModule{THardware, TSoftware}"/> for <see cref="IHumanPoseTrackerHardware"/> and <see cref="IHumanPoseTrackerSoftware"/>.
    /// </summary>
    public interface IHumanPoseTrackerModule :
        IModule<IHumanPoseTrackerHardware, IHumanPoseTrackerSoftware>
    {
        /// <summary>
        /// Propagates <see cref="Space3D.Pose"/> of head.
        /// </summary>
        IPropagation<Space3D.Pose> Head { get; }

        /// <summary>
        /// Propagates <see cref="Space3D.Pose"/> of left hand.
        /// </summary>
        IPropagation<Space3D.Pose> LeftHand { get; }

        /// <summary>
        /// Propagates <see cref="Space3D.Pose"/> of right hand.
        /// </summary>
        IPropagation<Space3D.Pose> RightHand { get; }
    }
}
