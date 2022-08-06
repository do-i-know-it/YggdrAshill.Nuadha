using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Defines configuration for human pose tracker.
    /// </summary>
    public interface IHumanPoseTracker
    {
        /// <summary>
        /// Generates <see cref="Space3D.Pose"/> of head to send.
        /// </summary>
        IGeneration<Space3D.Pose> Head { get; }

        /// <summary>
        /// Generates <see cref="Space3D.Pose"/> of left hand to send.
        /// </summary>
        IGeneration<Space3D.Pose> LeftHand { get; }

        /// <summary>
        /// Generates <see cref="Space3D.Pose"/> of right hand to send.
        /// </summary>
        IGeneration<Space3D.Pose> RightHand { get; }
    }
}
