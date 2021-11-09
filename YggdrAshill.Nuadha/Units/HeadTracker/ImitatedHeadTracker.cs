using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Imitation of <see cref="IHeadTrackerConfiguration"/>.
    /// </summary>
    public sealed class ImitatedHeadTracker :
        IHeadTrackerConfiguration
    {
        /// <summary>
        /// <see cref="ImitatedHeadTracker"/> singleton.
        /// </summary>
        public static ImitatedHeadTracker Instance { get; } = new ImitatedHeadTracker();

        private ImitatedHeadTracker()
        {

        }

        /// <inheritdoc/>
        public IPoseTrackerConfiguration Pose { get; } = ImitatedPoseTracker.Instance;

        /// <inheritdoc/>
        public IGeneration<Space3D.Direction> Direction { get; } = Generate.Signal(() => Space3D.Direction.Forward);
    }
}
