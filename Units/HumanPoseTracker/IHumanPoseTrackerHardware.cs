using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Units
{
    /// <summary>
    /// Defines <see cref="IHardware"/> for human pose tracker.
    /// </summary>
    public interface IHumanPoseTrackerHardware :
        IHardware
    {
        /// <summary>
        /// Sends <see cref="Space3D.Pose"/> of head to <see cref="IHumanPoseTrackerSoftware"/>.
        /// </summary>
        IProduction<Space3D.Pose> Head { get; }

        /// <summary>
        /// Sends <see cref="Space3D.Pose"/> of left hand to <see cref="IHumanPoseTrackerSoftware"/>.
        /// </summary>
        IProduction<Space3D.Pose> LeftHand { get; }

        /// <summary>
        /// Sends <see cref="Space3D.Pose"/> of right hand to <see cref="IHumanPoseTrackerSoftware"/>.
        /// </summary>
        IProduction<Space3D.Pose> RightHand { get; }
    }
}
