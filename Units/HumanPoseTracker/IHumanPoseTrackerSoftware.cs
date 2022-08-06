using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Units
{
    /// <summary>
    /// Defines <see cref="ISoftware"/> for human pose tracker.
    /// </summary>
    public interface IHumanPoseTrackerSoftware :
        ISoftware
    {
        /// <summary>
        /// Receives <see cref="Space3D.Pose"/> of head sent from <see cref="IHumanPoseTrackerHardware"/>.
        /// </summary>
        IConsumption<Space3D.Pose> Head { get; }

        /// <summary>
        /// Receives <see cref="Space3D.Pose"/> of left hand sent from <see cref="IHumanPoseTrackerHardware"/>.
        /// </summary>
        IConsumption<Space3D.Pose> LeftHand { get; }

        /// <summary>
        /// Receives <see cref="Space3D.Pose"/> of right hand sent from <see cref="IHumanPoseTrackerHardware"/>.
        /// </summary>
        IConsumption<Space3D.Pose> RightHand { get; }
    }
}
